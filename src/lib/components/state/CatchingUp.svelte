<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import type { CatchingUpState } from "$lib/state";
  import ProgressBar from "../ProgressBar.svelte";

  export let state: CatchingUpState;
</script>

<Pill message="catching up" icon="loading" severity="debug" />
<ProgressBar percentage={state.percentage} />
