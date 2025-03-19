<script lang="ts">
  import { events } from "$lib/bindings";
  import SplashScreen from "$lib/screens/SplashScreen.svelte";
  import Header from "./sections/Header.svelte";

  import { onMount } from "svelte";

  onMount(() => {
    events.variablesEvent.listen((event) => {
      console.log("variables", event.payload.variables);
    });
  });
</script>

<Header />

<SplashScreen />
