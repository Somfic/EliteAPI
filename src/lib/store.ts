import { LazyStore, load } from "@tauri-apps/plugin-store";

export const preferences = new LazyStore("preferences", { autoSave: true });
