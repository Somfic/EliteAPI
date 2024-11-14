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

export default async () => {
  await setupTray();

  events.journalEvent.listen(async ({ payload }) => {
    console.log("Journal Event", payload);
  });
};

async function setupTray() {
  await TrayIcon.removeById("eliteapi");

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

          if (!await window.isVisible()) {
            await showWindow(window, monitor, event.position);
          }
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
