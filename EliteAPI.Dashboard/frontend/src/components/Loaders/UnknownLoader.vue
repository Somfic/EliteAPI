<template>
  <main>
    <div class="dank-ass-loader">
      <div class="row">
        <div class="arrow up outer outer-18"></div>
        <div class="arrow down outer outer-17"></div>
        <div class="arrow up outer outer-16"></div>
        <div class="arrow down outer outer-15"></div>
        <div class="arrow up outer outer-14"></div>
      </div>
      <div class="row">
        <div class="arrow up outer outer-1"></div>
        <div class="arrow down outer outer-2"></div>
        <div class="arrow up inner inner-6"></div>
        <div class="arrow down inner inner-5"></div>
        <div class="arrow up inner inner-4"></div>
        <div class="arrow down outer outer-13"></div>
        <div class="arrow up outer outer-12"></div>
      </div>
      <div class="row">
        <div class="arrow down outer outer-3"></div>
        <div class="arrow up outer outer-4"></div>
        <div class="arrow down inner inner-1"></div>
        <div class="arrow up inner inner-2"></div>
        <div class="arrow down inner inner-3"></div>
        <div class="arrow up outer outer-11"></div>
        <div class="arrow down outer outer-10"></div>
      </div>
      <div class="row">
        <div class="arrow down outer outer-5"></div>
        <div class="arrow up outer outer-6"></div>
        <div class="arrow down outer outer-7"></div>
        <div class="arrow up outer outer-8"></div>
        <div class="arrow down outer outer-9"></div>
      </div>
    </div>
  </main>
</template>
<script>
export default {
  name: "UnknownLoader"
};
</script>
<style lang="scss" scoped>
$color: #fd7000;
$size: 12px;
$time: 1;

main {
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background:  #090707;
}

.dank-ass-loader {
  display: flex;
  flex-direction: column;
  align-items: center;

  .row {
    display: flex;
  }
}

.arrow {
  width: 0;
  height: 0;
  margin: 0 (-$size / 2);
  border-left: $size solid transparent;
  border-right: $size solid transparent;
  border-bottom: ($size * 1.8) solid $color;
  animation: blink $time + s infinite;
  filter: drop-shadow(0 0 ($size * 1.5) $color);

  &.down {
    transform: rotate(180deg);
  }

  @for $i from 1 through 18 {
    &.outer-#{$i} {
      animation-delay: -($time / 18) * $i + s;
    }
  }

  @for $i from 1 through 6 {
    &.inner-#{$i} {
      animation-delay: -($time / 6) * $i + s;
    }
  }
}

@keyframes blink {
  0% { opacity: 0.1; }
  30% { opacity: 1; }
  100% { opacity: 0.1; }
}
</style>