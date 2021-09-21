<template>
  <TitleBar title="EliteVA" :to="{name: 'Plugins'}"/>
  <div class="links-wrapper" v-if="installed">
    <div class="links" :class="{hidden: hidden}">
      <div class="link-wrapper big">
        <Card class="link" :to="{name: 'EliteVA-Install'}" @click="resetInstallProgress">
          <h1 v-if="installed">Update plugin</h1>
          <h1 v-else>Install</h1>
        </Card>
      </div>
      <div class="link-wrapper" v-if="installed">
        <Card class="link disabled">
          <h1>v{{ installedVersion }}</h1>
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
      hidden: true
    }
  },
  methods: {
    updateData() {
      this.installed = this.$store.state.userprofile['EliteVA']['IsInstalled'];
      this.installedVersion = this.$store.state.userprofile['EliteVA']['InstalledVersion'];
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