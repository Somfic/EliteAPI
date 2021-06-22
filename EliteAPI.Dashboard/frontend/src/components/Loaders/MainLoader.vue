<template>
  <div class="loader-wrapper">
    <div class="loader">
      <div class="icon">

      </div>
      <div class="text">
        <h1 class="primary">Welcome to</h1>
        <ProgressBar percentage="50" />
        <h1 class="secondary">Hanseen Depot</h1>
      </div>
    </div>
  </div>
</template>
<script>
import ProgressBar from "@/components/Loaders/ProgressBar";

export default {
  name: "MainLoader",
  components: { ProgressBar }
};
</script>
<style lang="scss" scoped>
.loader-wrapper {
  flex-grow: 1;
  display: flex;
  align-items: center;
  justify-content: center;

  .loader {
    display: flex;
    align-items: center;

    .text {
      display: flex;
      flex-direction: column;

      h1 {
        margin: 0;
        text-transform: uppercase;

        &.primary {
          color: $accent;
        }
      }
    }
  }
}
</style>