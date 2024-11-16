<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import type { ReadyState } from "$lib/state";

  export let state: ReadyState;
</script>

<Pill message="connected" severity="success" />
<p>Ready</p>
