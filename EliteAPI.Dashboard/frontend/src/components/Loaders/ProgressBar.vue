<template>
  <div class="progress-bar">
    <div class="progress"></div>
  </div>
</template>
<script>
export default {
  name: 'ProgressBar',
  props: {
    percentage: Number
  },
  watch: {
    percentage() {

    }
  }
}
</script>