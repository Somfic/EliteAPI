<script lang="ts">
  import Pill from "$lib/components/Pill.svelte";
  import type { ReadyState } from "$lib/state";
  import { commander, system } from "$lib/store";

  export let state: ReadyState;
</script>

<Pill message="live" severity="success" icon="pulse" />

<p>CMDR {$commander}</p>
<p>{$system}</p>
