<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import type { ErrorState } from "$lib/state";

  export let state: ErrorState;
</script>

<Pill message="error" severity={state.isFatal ? "error" : "warning"} />
<p>{state.error}</p>
