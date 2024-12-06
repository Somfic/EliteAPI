<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import ProgressBar from "$lib/components/ProgressBar.svelte";
  import type { ErrorState, StoppedState } from "$lib/state";

  export let state: StoppedState;
</script>

{#if state.isWaitingForGameToStart}
  <Pill message="waiting for game" severity={"debug"} icon="loading" />
{:else}
  <Pill message="stopped" severity={"error"} />
{/if}
