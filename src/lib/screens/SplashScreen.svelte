<script lang="ts">
  import { getVersion } from "@tauri-apps/api/app";
  import { onMount } from "svelte";

  onMount(async () => {
    version = await getVersion();
  });

  let version = "0.0.0";
</script>

<div class="splash">
  <div id="icon">
    <img src="/eliteapi.png" alt="EliteAPI Logo" />
    <h1>EliteAPI</h1>
  </div>
  <h2 id="version">{version}</h2>
</div>

<style lang="scss">
  @import "$lib/theme.scss";

  .splash {
    top: 0;
    left: 0;
    display: flex;
    width: 100vw;
    height: 100vh;
    position: absolute;
    background-color: rgb(14, 17, 44);
    align-items: center;
    justify-content: center;
  }

  #icon {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 1rem;

    img {
      width: 200px;
      height: 200px;
      border-radius: 100%;
      user-select: none;
      pointer-events: none;
    }

    h1 {
      font-size: 2.5rem;
      font-weight: bold;
      margin: 0;
    }
  }

  #version {
    font-size: 1.5rem;
    font-weight: bold;
    margin: 0;
    color: $text;
    position: absolute;
    bottom: 0;
    padding: 1rem;
    color: $text-secondary;
  }
</style>
