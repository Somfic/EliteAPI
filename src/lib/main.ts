import { TrayIcon, type TrayIconOptions } from "@tauri-apps/api/tray";
import { defaultWindowIcon } from "@tauri-apps/api/app";
import {
  currentMonitor,
  getCurrentWindow,
  type Monitor,
  PhysicalPosition,
  Window,
} from "@tauri-apps/api/window";
import { commands } from "./bindings";
import { Menu, Submenu } from "@tauri-apps/api/menu";

export default async () => {
  if (await commands.tryInitialize()) {
    return;
  }

  // Hide the window when it loses focus
  getCurrentWindow().onFocusChanged(async (event) => {
    if (!event.payload) {
      await hideWindow(getCurrentWindow());
    }
  });

  const options: TrayIconOptions = {
    icon: (await defaultWindowIcon()) ?? "",
    async action(event) {
      switch (event.type) {
        case "Click": {
          let monitor = (await currentMonitor())!;
          let window = getCurrentWindow();

          if (!await window.isFocused()) {
            await showWindow(window, monitor, event.position);
          }
        }
      }
    },
  };

  const tray = await TrayIcon.new(options);

  tray.setTooltip("EliteAPI");
};

async function hideWindow(window: Window) {
  // await window.setAlwaysOnTop(false);
  // await window.hide();
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
