<script lang="ts">
  export let message: string;
  export let icon: "loading" | undefined = undefined;
  export let severity: "success" | "warning" | "error";
</script>

<div class={`pill ${severity}`}>
  {#if icon === "loading"}
    <div class="loading" />
  {/if}

  <span>{message}</span>
</div>

<style lang="scss">
  $success: rgb(62, 229, 76);
  $warning: rgb(229, 134, 62);
  $error: rgb(229, 62, 62);

  .pill {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    margin: 0;
    width: auto;
    padding: 5px 12px;
    border-radius: 10px;
    gap: 10px;
    color: rgb(255, 255, 255);
    border: 2px solid;
    font-size: 14px;

    &.success {
      background-color: transparentize($success, 0.5);
      border-color: transparentize($success, 0.5);
    }

    &.warning {
      background-color: transparentize($warning, 0.5);
      border-color: transparentize($warning, 0.5);
    }

    &.error {
      background-color: transparentize($error, 0.5);
      border-color: transparentize($error, 0.5);
    }
  }

  .loading {
    border: 3px solid rgba(255, 255, 255, 0.4);
    border-top: 3px solid rgba(255, 255, 255, 1);
    border-radius: 100%;
    width: 0.8em;
    height: 0.8em;
    animation: spin 1s linear infinite;
  }

  @keyframes spin {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }
</style>
