<script lang="ts">
  import { onMount } from "svelte";
  import { commands } from "../lib/bindings";
  import main from "$lib/main";
  import Header from "./sections/Header.svelte";
  import Warp from "./sections/Warp.svelte";

  onMount(async () => {
    await main();
  });

  let hidden = false;

  onMount(async () => {
    let directory = await commands.findDirectory();

    if (directory.status == "error") {
      greetMsg = directory.error;
    }
  });
</script>

<main>
  <Header />
  <Warp hide={hidden} />

  <button on:click={() => (hidden = !hidden)}>hide?</button>
</main>

<style lang="scss">
  :global(html, body, main) {
    margin: 0;
    padding: 0;
    background-color: black;
    color: white;
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    width: 100%;
    height: 100%;
  }
</style>
