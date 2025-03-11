<script lang="ts">
  import Header from "./sections/Header.svelte";
  import Warp from "./sections/Warp.svelte";
  import { supercruise } from "$lib/store";
</script>

<main>
  <Header />
  <article></article>
</main>

<Warp show={true} />

<style lang="scss">
  @import url("https://fonts.googleapis.com/css2?family=Lexend:wght@100..900&display=swap");
  @import "$lib/theme.scss";

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
</style>
