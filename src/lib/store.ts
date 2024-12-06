import { LazyStore, load } from "@tauri-apps/plugin-store";
import { writable } from "svelte/store";

export const preferences = new LazyStore("preferences", { autoSave: true });
export const supercruise = writable(false);
export const commander = writable("");
export const system = writable("");
