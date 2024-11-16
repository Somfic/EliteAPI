<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import type { CatchingUpState } from "$lib/state";
  import ProgressBar from "../components/ProgressBar.svelte";

  export let state: CatchingUpState;
</script>

<Pill message="connecting" icon="loading" severity="warning" />
<h1>Catching up</h1>

<ProgressBar percentage={state.percentage} />
