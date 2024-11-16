<script lang="ts">
  export let percentage: number;
</script>

<div class="progress-bar">
  <div class="progress" style="width: {percentage}%"></div>
</div>

<style lang="scss">
  .progress-bar {
    top: 0;
    left: 0;
    width: 100%;
    height: 5px;
    background-color: rgba(255, 255, 255, 0.1);
    border-radius: 10px;

    .progress {
      height: 100%;
      background-color: rgb(229, 134, 62);
      box-shadow: 0 0 10px rgba(229, 134, 62, 0.5);
      transition: width 500ms ease;
      border-radius: 10px;
    }
  }
</style>
