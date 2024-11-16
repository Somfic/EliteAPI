<script lang="ts">
  import { onMount } from "svelte";
  import { commands } from "../lib/bindings";
  import main, { currentEvent } from "$lib/main";
  import Header from "./sections/Header.svelte";
  import Warp from "./sections/Warp.svelte";
  import Ship from "./sections/Ship.svelte";
  import { Canvas } from "@threlte/core";
  import ProgressBar from "../lib/components/ProgressBar.svelte";
  import { CatchingUpState, ErrorState, ReadyState, state } from "$lib/state";
  import CatchingUp from "$lib/state/CatchingUp.svelte";
  import Ready from "$lib/state/Ready.svelte";
  import Error from "$lib/state/Error.svelte";
  import Status from "$lib/components/Status.svelte";
  onMount(async () => {
    await main();
  });
</script>

<main>
  <Header />
  <article>
    <!-- <div class="canvas">
    <Canvas>
      <Ship />
    </Canvas>
  </div> -->
    <div class="status">
      <Status icon="voiceattack.svg" status="online" />
      <Status icon="voiceattack.svg" status="busy" />
      <Status icon="voiceattack.svg" status="offline" />
    </div>

    <div class="modal">
      {#if $state instanceof CatchingUpState}
        <CatchingUp state={$state} />
      {:else if $state instanceof ReadyState}
        <Ready state={$state} />
      {:else if $state instanceof ErrorState}
        <Error state={$state} />
      {/if}
    </div>
  </article>
</main>

<Warp hide={$currentEvent ? $currentEvent["is_live"] : false} />

<style lang="scss">
  @import url("https://fonts.googleapis.com/css2?family=Lexend:wght@100..900&display=swap");
  @import "../styling/theming.scss";

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
    font-family: "Lexend", sans-serif;
    font-optical-sizing: auto;
    font-style: normal;
  }

  main {
    z-index: 1;
    background: none;
    display: flex;
    flex-grow: 1;
  }

  article {
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    padding: 20px;
  }

  .canvas {
    flex-grow: 1;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .status {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
  }

  .modal {
    margin-top: auto;
    background-color: $glass-background;
    backdrop-filter: $glass-filter;
    border: $glass-border;
    border-radius: $glass-border-radius;
    padding: 20px;
  }
</style>
