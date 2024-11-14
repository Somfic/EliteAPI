<script lang="ts">
  import type { CatchingUpState } from "$lib/state";
  import ProgressBar from "../../routes/sections/ProgressBar.svelte";

  export let state: CatchingUpState;
</script>

<ProgressBar percentage={state.percentage} />
