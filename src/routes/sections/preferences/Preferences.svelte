<script lang="ts">
  import { preferences } from "$lib/store";
  import { onMount } from "svelte";

  let keys: string[] = [];

  let options: {
    key: string;
    type: boolean | string;
  }[] = [];

  onMount(async () => {
    const keys = await preferences.keys();
    keys.forEach(async (key) => {
      const type = await preferences.get(key);
      options.push({ key, type: typeof type });
    });
  });
</script>

{#each options as option}
  <p>{option.key}: {option.type}</p>
{/each}
