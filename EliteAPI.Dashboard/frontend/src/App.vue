<template>
  <div id="root">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: "App",
  async mounted() {
    if(!this.$store.state.catchup.hasCaughtUp) {
      await this.$router.push({ name: 'Catchup' })
    }
  }
};
</script>
<style lang="scss">
#root {
  font-size: 1rem;
}
</style>