<template>
  <div id="root">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: "App",
  async mounted() {
    this.$store.commit("connect");
  }
};
</script>
<style lang="scss">
#root {
  font-size: 1rem;
}
</style>