<script lang="ts">
  import { onMount } from "svelte";
  import { commands } from "../lib/bindings";
  import main, { currentEvent } from "$lib/main";
  import Header from "./sections/Header.svelte";
  import Warp from "./sections/Warp.svelte";
  import Ship from "./sections/Ship.svelte";
  import { Canvas } from "@threlte/core";
  import ProgressBar from "../lib/components/ProgressBar.svelte";
  import {
    CatchingUpState,
    ErrorState,
    ReadyState,
    state,
    StoppedState,
  } from "$lib/state";
  import CatchingUp from "$lib/state/CatchingUp.svelte";
  import Ready from "$lib/state/Ready.svelte";
  import Error from "$lib/state/Error.svelte";
  import Status from "$lib/components/Status.svelte";
  import Preferences from "./sections/preferences/Preferences.svelte";
  import { supercruise } from "$lib/store";
  import Stopped from "$lib/state/Stopped.svelte";
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

    <Preferences />

    <div class="modal">
      {#if $state instanceof CatchingUpState}
        <CatchingUp state={$state} />
      {:else if $state instanceof ReadyState}
        <Ready state={$state} />
      {:else if $state instanceof ErrorState}
        <Error state={$state} />
      {:else if $state instanceof StoppedState}
        <Stopped state={$state} />
      {/if}
    </div>
  </article>
</main>

<Warp hide={!$supercruise} />

<style lang="scss">
  @import url("https://fonts.googleapis.com/css2?family=Lexend:wght@100..900&display=swap");
  @import "../styling/theming.scss";

  :global(html, body, main) {
    margin: 0;
    padding: 0;
    background-color: rgb(4, 4, 13);
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
    gap: 20px;
  }

  .modal {
    margin-top: auto;
    background-color: $glass-background;
    backdrop-filter: $glass-filter;
    border: $glass-border;
    border-radius: $glass-border-radius;
    padding: 20px;
    display: inline-flex;
    flex-direction: column;
    gap: 20px;
  }
</style>
