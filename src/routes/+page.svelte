<script lang="ts">
  import SplashScreen from "$lib/screens/SplashScreen.svelte";
  import Header from "./sections/Header.svelte";

  import { listen } from "@tauri-apps/api/event";
  import { onMount } from "svelte";

  onMount(() => {
    listen("journal_event", (event) => {
      console.log("journal_event", event.payload);
    });

    listen("log", (event) => {
      console.log("log", event.payload);
    });
  });
</script>

<Header />

<SplashScreen />
