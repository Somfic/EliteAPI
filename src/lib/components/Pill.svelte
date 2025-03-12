<script lang="ts">
  export let message: string;
  export let icon: "loading" | "pulse" | undefined = undefined;
  export let severity: "success" | "warning" | "error" | "info" | "debug";
</script>

<div class={`pill ${severity}`}>
  {#if icon !== undefined}
    <div class={icon} />
  {/if}

  <span>{message}</span>
</div>

<style lang="scss">
  @use "sass:color";
  @import "$lib/theming.scss";

  .pill {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    margin: 0;
    width: auto;
    padding: 5px 12px;
    border-radius: 10px;
    gap: 8px;
    color: rgb(255, 255, 255);
    border: 2px solid;
    font-size: 14px;

    &.success {
      background-color: color.scale($success, $alpha: 50%);
      border-color: color.scale($success, $alpha: 50%);
    }

    &.warning {
      background-color: color.scale($warning, $alpha: 50%);
      border-color: color.scale($warning, $alpha: 50%);
    }

    &.error {
      background-color: color.scale($error, $alpha: 50%);
      border-color: color.scale($error, $alpha: 50%);
    }

    &.info {
      background-color: color.scale($info, $alpha: 50%);
      border-color: color.scale($info, $alpha: 50%);
    }

    &.debug {
      background-color: color.scale($debug, $alpha: 50%);
      border-color: color.scale($debug, $alpha: 50%);
    }
  }

  .loading {
    border: 3px solid rgba(255, 255, 255, 0.4);
    border-top: 3px solid rgba(255, 255, 255, 1);
    border-radius: 100%;
    width: 0.7em;
    height: 0.7em;
    animation: spin 1.25s linear infinite;
  }

  .pulse {
    width: 0.7em;
    height: 0.7em;
    animation: pulse 1s linear infinite;
    background-color: rgba(255, 255, 255);
    border-radius: 100%;
    animation: pulse 2s ease infinite;
  }

  @keyframes spin {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }

  @keyframes pulse {
    0% {
      transform: scale(1);
      opacity: 0.5;
    }
    50% {
      transform: scale(1.1);
      opacity: 0.8;
    }
    70% {
      transform: scale(1);
      opacity: 0.5;
    }

    100% {
      transform: scale(1);
      opacity: 0.5;
    }
  }
</style>
