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
  @import "../../styling/theming.scss";

  .status {
    width: 100px;
    height: 100px;
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
      background-color: transparentize($success, 0.8);
      border-color: transparentize($success, 0.8);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px transparentize($success, 0.2));
      }
    }

    &.busy {
      background-color: transparentize($warning, 0.5);
      border-color: transparentize($warning, 0.5);
      img {
        filter: brightness(1)
          drop-shadow(0 0 20px transparentize($warning, 0.2));
      }

      .indicator {
        border: 3px solid transparentize($warning, 0.4);
        box-sizing: border-box;
        border-top: 3px solid $warning;
        animation: spin 1s linear infinite;
      }
    }

    &.offline {
      background-color: transparentize(gray, 0.5);
      border-color: transparentize(gray, 0.5);
      img {
        filter: brightness(1) drop-shadow(0 0 20px transparentize(gray, 0.2))
          opacity(0.7);
      }

      .indicator {
        opacity: 0;
      }
    }

    &.error {
      background-color: transparentize($error, 0.5);
      border-color: transparentize($error, 0.5);
      img {
        filter: brightness(1) drop-shadow(0 0 20px transparentize($error, 0.2));
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
