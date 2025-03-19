<script lang="ts">
  export let show: boolean;
</script>

<div class="scene" class:show>
  <div class="wrap">
    <div class="wall wall-right"></div>
    <div class="wall wall-left"></div>
    <div class="wall wall-top"></div>
    <div class="wall wall-bottom"></div>
    <div class="wall wall-back"></div>
  </div>
  <div class="wrap">
    <div class="wall wall-right"></div>
    <div class="wall wall-left"></div>
    <div class="wall wall-top"></div>
    <div class="wall wall-bottom"></div>
    <div class="wall wall-back"></div>
  </div>
</div>

<style lang="scss">
  $speed: 5s;
  $size: 2000px;

  .wall {
    background: url("stars.webp");
    background-size: cover;
  }

  .scene {
    position: absolute;
    height: 100vh;
    width: 100vw;
    flex-grow: 1;
    display: inline-block;
    vertical-align: middle;
    overflow: hidden;
    pointer-events: none;
    opacity: 0;
    z-index: 0;
    animation: warp 60s infinite linear;

    &.show {
      opacity: 0.8;
    }

    transition: opacity 1s;
  }

  .wrap {
    position: absolute;
    width: $size;
    height: $size;
    left: calc($size / -2);
    top: calc($size / -2);
    transform-style: preserve-3d;
    animation: move $speed infinite linear;
    animation-fill-mode: forwards;
  }

  .wrap:nth-child(2) {
    animation: move $speed infinite linear;
    animation-delay: calc($speed / 2);
  }

  .wall {
    width: 100%;
    height: 100%;
    position: absolute;
    opacity: 0;
    animation: fade $speed infinite linear;
    animation-delay: 0;
  }

  .wrap:nth-child(2) .wall {
    animation-delay: calc($speed / 2);
  }

  .wall-right {
    transform: rotateY(90deg) translateZ(calc($size / 2));
  }

  .wall-left {
    transform: rotateY(-90deg) translateZ(calc($size / 2));
  }

  .wall-top {
    transform: rotateX(90deg) translateZ(calc($size / 2));
  }

  .wall-bottom {
    transform: rotateX(-90deg) translateZ(calc($size / 2));
  }

  .wall-back {
    transform: rotateX(180deg) translateZ(calc($size / 2));
  }

  @keyframes move {
    0% {
      transform: translateZ(calc($size / -2)) rotate(0deg);
    }
    100% {
      transform: translateZ(calc($size / 2)) rotate(0deg);
    }
  }

  @keyframes warp {
    0% {
      perspective: 8px;
    }
    50% {
      perspective: 10px;
    }
    100% {
      perspective: 8px;
    }
  }

  @keyframes fade {
    0% {
      opacity: 0;
    }
    25% {
      opacity: 1;
    }
    75% {
      opacity: 1;
    }
    100% {
      opacity: 0;
    }
  }
</style>
