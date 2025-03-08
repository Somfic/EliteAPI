import { TrayIcon, type TrayIconOptions } from "@tauri-apps/api/tray";
import { defaultWindowIcon } from "@tauri-apps/api/app";
import {
  currentMonitor,
  getCurrentWindow,
  type Monitor,
  PhysicalPosition,
  Window,
} from "@tauri-apps/api/window";
import { commands, events } from "./bindings";
import { Menu, Submenu } from "@tauri-apps/api/menu";
import { get, type Writable, writable } from "svelte/store";
import { setCatchingUp, setError, setReady, setStopped } from "./state";
import { commander, system } from "./store";

export const currentEvent: Writable<any> = writable(null);

export default async () => {
  await setupTray();

  let earliestTimestamp = new Date();

  events.errorEvent.listen(async ({ payload }) => {
    let error = payload;
    console.error(error);

    setError(error);
  });

  events.journalEvent.listen(async ({ payload }) => {
    let event = JSON.parse(payload);
    const isLive = event["is_live"] as boolean;
    currentEvent.set(event);

    // Switch on event['kind']['JournalEvent'] vs ['kind']['StatusEvent'] vs ['kind']['DockedEvent']
    switch (Object.keys(event["kind"])[0]) {
      case "LogEvent":
        let journalEvent = event["kind"]["LogEvent"] as any;

        if (journalEvent == undefined) {
          console.warn("Journal Event is undefined", event);
        }

        if (journalEvent["event"] == "Commander") {
          commander.set(journalEvent["Name"]);
        }

        if (journalEvent["event"] == "Location") {
          system.set(journalEvent["StarSystem"]);
        }

        if (journalEvent["event"] == "FSDJump") {
          system.set(journalEvent["StarSystem"]);
        }

        console.log("Log Event", journalEvent);

        if (!isLive) {
          let eventTimeStamp = new Date(journalEvent["timestamp"]);
          if (eventTimeStamp < earliestTimestamp) {
            earliestTimestamp = eventTimeStamp;
          }

          let currentTimestamp = new Date();

          let totalTime = currentTimestamp.getTime() -
            earliestTimestamp.getTime();

          let eventTime = eventTimeStamp.getTime() -
            earliestTimestamp.getTime();

          let percentage = Math.round((eventTime / totalTime) * 100);

          setCatchingUp(percentage);
        }

        if (journalEvent["event"] == "Shutdown") {
          setStopped(!isLive);
        }

        break;
      case "StatusEvent":
        console.log("Status Event", event);
        const flags = event["kind"]["StatusEvent"]["Flags"] as number;
        const isSupercruise = (flags & 0b00010000) > 0;
        console.log("Supercruise", isSupercruise);
        break;
      default:
        console.log("Unknown Event", event);

        break;
    }

    if (isLive) {
      setReady();
    }
  });

  await commands.getEventBacklog();
};

async function setupTray() {
  while (await TrayIcon.getById("eliteapi")) {
    console.log("Removing existing tray icon");
    await TrayIcon.removeById("eliteapi");
  }

  console

  getCurrentWindow().onFocusChanged(async (event) => {
    if (!event.payload) {
      await hideWindow(getCurrentWindow());
    }
  });

  await TrayIcon.new({
    id: "eliteapi",
    icon: (await defaultWindowIcon()) ?? "",
    tooltip: "EliteAPI",
    async action(event) {
      switch (event.type) {
        case "Click": {
          let monitor = (await currentMonitor())!;
          let window = getCurrentWindow();
          await showWindow(window, monitor, event.position);
        }
      }
    },
  });
}

async function hideWindow(window: Window) {
  //await window.setAlwaysOnTop(false);
  //await window.hide();
}

async function showWindow(
  window: Window,
  monitor: Monitor,
  clickPosition: PhysicalPosition,
) {
  let windowSize = await window.innerSize();
  let monitorSize = monitor?.size;

  let x = Math.round(clickPosition.x - windowSize.width / 2);
  let y = Math.round(monitorSize.height - windowSize.height - 75);

  let position = new PhysicalPosition(x, y);

  await window.setPosition(position);
  await window.show();
  await window.setFocus();
  await window.setAlwaysOnTop(true);
}
