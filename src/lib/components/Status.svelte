<script lang="ts">
  export let icon: string;
  export let status: "online" | "offline" | "busy" | "error" = "online";
</script>

<div class={`status ${status}`}>
  <div class="icon">
    <img src={icon} alt="status icon" />
  </div>
  <div class="indicator" />
</div>

<style lang="scss">
  @use "sass:color";
  @import "../../styling/theming.scss";

  .status {
    aspect-ratio: 1;
    background-color: $glass-background;
    backdrop-filter: $glass-filter;
    border: $glass-border;
    border-radius: $glass-border-radius;
    display: flex;
    justify-content: center;
    align-items: center;
    transition: all 1s ease-in-out;
    position: relative;

    .indicator {
      position: absolute;
      width: 0.6em;
      height: 0.6em;
      border-radius: 100%;
      background-color: transparent;
      right: 0;
      top: 0;
      margin: 8px;
    }

    &.online {
      background-color: color.scale($success, $alpha: 80%);
      border-color: color.scale($success, $alpha: 80%);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px color.scale($success, $alpha: 20%));
      }
    }

    &.busy {
      background-color: color.scale($warning, $alpha: 50%);
      border-color: color.scale($warning, $alpha: 50%);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px color.scale($warning, $alpha: 20%));
      }

      .indicator {
        border: 3px solid color.scale($warning, $alpha: 40%);
        box-sizing: border-box;
        border-top: 3px solid $warning;
        animation: spin 1s linear infinite;
      }
    }

    &.offline {
      background-color: color.scale(gray, $alpha: 50%);
      border-color: color.scale(gray, $alpha: 50%);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px color.scale(gray, $alpha: 20%)) opacity(0.7);
      }

      .indicator {
        opacity: 0;
      }
    }

    &.error {
      background-color: color.scale($error, $alpha: 50%);
      border-color: color.scale($error, $alpha: 50%);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px color.scale($error, $alpha: 20%));
      }

      .indicator {
        background-color: $error;
      }
    }
  }

  .icon {
    padding: 12px;
  }

  img {
    width: 100%;
    height: 100%;
    filter: brightness(0.8);
  }

  .loading {
    border-radius: 100%;
    width: 0.8em;
    height: 0.8em;
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
