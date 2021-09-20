<template>
  <TitleBar title="Installing EliteVA"/>
  <KnownLoader is-loading="true">

  </KnownLoader>
</template>

<script>
import TitleBar from "@/components/TitleBar";
import KnownLoader from "@/components/Loaders/KnownLoader";

export default {
  name: "EliteVA",
  components: {KnownLoader, TitleBar},
  async created() {
    this.$store.commit('send', {type: 'eliteva.install', value: null});

    setInterval(() => {
      this.updateData();
    }, 1000);

    this.updateData();
  },
  data() {
    return {
      installed: false,
      installedVersion: null,
      installationDirectory: null
    }
  },
  methods: {
    updateData() {
      this.installed = this.$store.state.userprofile['EliteVA']['IsInstalled'];
      this.installedVersion = this.$store.state.userprofile['EliteVA']['InstalledVersion'];
      this.installationDirectory = this.$store.state.userprofile['EliteVA']['InstallationDirectory'];
    }
  }
};
</script>
<style lang="scss" scoped>
.links {
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
}
</style>