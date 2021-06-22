<template>
  <div class="progress-bar">
    <div class="progress" :style="'width: '+ percentage * 100 +'%'"></div>
  </div>
</template>
<script>
export default {
  name: "ProgressBar",
  props: {
    percentage: Number
  },
  watch: {
    percentage() {

    }
  }
};
</script>
<style lang="scss" scoped>
.progress-bar {
  width: 100%;
  background-color: mix($background, $accent);
  border-radius: 10px;

  .progress {
    height: 2.2px;
    border-radius: 10px;
    background-color: $accent;
    transition: 800ms ease-in-out;
    filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
  }
}
</style>