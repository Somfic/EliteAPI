<template>
  <div class="progress-bar">
    <div v-if="!indeterminate" class="progress" :style="'width: '+ percentage * 100 +'%'"></div>
    <div v-else class="progress indeterminate" :style="'width: 20%'"></div>
  </div>
</template>
<script>
export default {
  name: "ProgressBar",
  props: {
    percentage: Number,
    indeterminate: Boolean
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

    &.indeterminate {
      animation: indeterminate 1800ms ease-in infinite;
    }
  }
}

@keyframes indeterminate {
  0% {
    margin-left: 0;
    width: 0;
    opacity: 0;
  }

  10% {
    width: 20%;
    margin-left: 0;
    opacity: 0;
  }

  40% {
    opacity: 1;
  }


  70% {
    margin-left: 80%;
    width: 20%;
    opacity: 0;
  }

  80%, 100% {
    margin-left: 100%;
    width: 0;
    opacity: 0;
  }
}
</style>