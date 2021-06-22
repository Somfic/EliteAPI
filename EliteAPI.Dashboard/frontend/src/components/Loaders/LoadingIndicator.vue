<template>
  <div class="loading-indicator">
    <div class="square"></div>
    <div class="square"></div>
    <div class="square"></div>
    <div class="square"></div>
  </div>
</template>
<script>
export default {
  name: 'LoadingIndicator'
}
</script>
<style lang="scss">
$size: .5rem;
$animationLength: 550ms;
$animationDelay: $animationLength / 5;

.loading-indicator {
  display: inline-grid;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 1fr 1fr;

  .square {
    filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
    margin: $size / 8;
    width: $size;
    height: $size;
    background-color: $accent;
    animation: pulse $animationLength infinite alternate;

    &:nth-child(1) {
      animation-delay: $animationDelay * 1;
    }

    &:nth-child(2) {
      animation-delay: $animationDelay * 2;
    }

    &:nth-child(3) {
      animation-delay: $animationDelay * 4;
    }

    &:nth-child(4) {
      animation-delay: $animationDelay * 3;
    }
  }
}

@keyframes pulse {
  0% {
    transform: scale(1);
    opacity: 1;
  }

  90%, 100% {
    transform: scale(.9);
    opacity: 0;
  }
}

</style>
