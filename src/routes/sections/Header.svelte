<script>
  import { getVersion } from "@tauri-apps/api/app";
  import { onMount } from "svelte";

  onMount(async () => {
    version = await getVersion();
  });

  let version = "0.0.0";
</script>

<div class="header">
  <div class="title-bar">
    <img src="/eliteapi.png" alt="" />
    <div class="title">
      <h1>EliteAPI</h1>
      <h2>v{version}</h2>
    </div>
  </div>
</div>

<style lang="scss">
  .header {
    display: flex;
    background-color: rgba(15, 14, 24, 0.8);
    backdrop-filter: blur(10px) saturate(180%);
    height: 70px;
    padding: 10px 20px;
    border-bottom: 2px solid rgba(255, 255, 255, 0.1);
  }

  .title-bar {
    display: flex;
    align-items: center;
    gap: 1rem;

    img {
      width: 50px;
      height: 50px;
      border-radius: 100%;
    }

    .title {
      display: flex;
      flex-direction: column;
      gap: 0.1rem;

      h1 {
        font-size: 1.7rem;
        font-weight: bold;
        margin: 0;
      }

      h2 {
        font-size: 0.85rem;
        font-weight: bold;
        margin: 0;
        color: rgba(255, 255, 255, 0.5);
      }
    }
  }
</style>
