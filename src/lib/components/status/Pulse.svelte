<div class="pulse"></div>

<style lang="scss">
  $color: rgb(207, 164, 84);

  .pulse {
    background: $color;
    border-radius: 50%;
    height: 10px;
    width: 10px;
    box-shadow: 0 0 0 0 $color;
    transform: scale(1);
    animation: pulse 2s infinite;
  }

  @keyframes pulse {
    0% {
      transform: scale(0.95);
      box-shadow: 0 0 0 0 transparentize($color, 0.3);
    }

    70% {
      transform: scale(1);
      box-shadow: 0 0 0 10px transparentize($color, 1);
    }

    100% {
      transform: scale(1);
      box-shadow: 0 0 0 10px transparentize($color, 1);
    }
  }
</style>
