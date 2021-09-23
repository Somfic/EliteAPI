<template>
  <TitleBar title="EliteVA" :to="{name: 'Plugins'}"/>
  <div class="links-wrapper">
    <div class="links" :class="{hidden: hidden}">
      <div class="link-wrapper big">
        <Card class="link" :to="{name: 'EliteVA-Install'}" @click="resetInstallProgress" :notice="newestVersion + ' available'" :notice-if="newerAvailable">
          <h1 v-if="!installed">Install</h1>
          <h1 v-else-if="newerAvailable">Update plugin</h1>
          <h1 v-else-if="installed">v{{installedVersion}} installed</h1>
        </Card>
      </div>
      <div class="link-wrapper" v-if="installed">
        <Card class="link">
          <h1>Uninstall</h1>
        </Card>
      </div>
    </div>
  </div>
</template>

<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";

export default {
  name: "EliteVA",
  components: {Card, TitleBar},
  async created() {
    setInterval(() => {
      this.updateData();
    }, 1000);

    setTimeout(() => {
      this.hidden = false;
    }, 10)

    this.updateData();
  },
  data() {
    return {
      installed: false,
      installedVersion: null,
      installationDirectory: null,
      newestVersion: null,
      newerAvailable: false,
      hidden: true
    }
  },
  methods: {
    updateData() {
      this.installed = this.$store.state.userprofile['EliteVA']['IsInstalled'];
      this.installedVersion = this.$store.state.userprofile['EliteVA']['InstalledVersion'];
      this.newestVersion = this.$store.state.eliteva.newestVersion;
      this.newerAvailable = this.installedVersion !== this.newestVersion;
      this.installationDirectory = this.$store.state.userprofile['EliteVA']['InstallationDirectory'];
    },

    resetInstallProgress() {
      this.$store.state.eliteva.inProgress = false;
      this.$store.state.eliteva.progress = 0;
    }
  }
};
</script>
<style lang="scss" scoped>
</style>