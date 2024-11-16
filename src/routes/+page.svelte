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
  onMount(async () => {
    await main();
  });
</script>

<main>
  <Header />
  <!-- <div class="canvas">
    <Canvas>
      <Ship />
    </Canvas>
  </div> -->

  <div class="modal">
    {#if $state instanceof CatchingUpState}
      <CatchingUp state={$state} />
    {:else if $state instanceof ReadyState}
      <Ready state={$state} />
    {:else if $state instanceof ErrorState}
      <Error state={$state} />
    {/if}
  </div>
</main>

<Warp hide={$currentEvent ? $currentEvent["is_live"] : false} />

<style lang="scss">
  @import url("https://fonts.googleapis.com/css2?family=Lexend:wght@100..900&display=swap");

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
  }

  .canvas {
    flex-grow: 1;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .modal {
    margin: 20px;
    margin-top: auto;
    background-color: rgba(255, 255, 255, 0.1);
    backdrop-filter: blur(10px) saturate(180%);
    padding: 20px;
    border-radius: 15px;
  }
</style>
