<template>
  <TitleBar title="EliteVA" :to="{name: 'Plugins'}"/>
  <div class="links-wrapper">
    <div class="links">
      <div class="link-wrapper big">
        <Card class="link" :to="{name: 'EliteVA-Install'}" :class="{disabled: installed}">
          <h1>Install</h1>
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link">
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link">
          <h1>Version: {{installedVersion}}</h1>
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link">
          <h1>Directory: {{installationDirectory}}</h1>
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link">
          <h1></h1>
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