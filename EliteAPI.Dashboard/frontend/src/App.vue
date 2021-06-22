<template>
  <div id="root">
    <MainLoader />
  </div>
</template>

<script>
import MainLoader from "@/components/Loaders/MainLoader";
export default {
  name: "App",
  components: { MainLoader },
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