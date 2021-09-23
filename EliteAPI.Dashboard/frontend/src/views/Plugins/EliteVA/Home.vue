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
<!--      <div class="link-wrapper" v-if="installed">-->
<!--        <Card class="link">-->
<!--          <h1>Uninstall</h1>-->
<!--        </Card>-->
<!--      </div>-->
    </div>
  </div>
  <div class="ui">
    <h3>Installation path</h3>
    <input id="path" class="input textbox" type="text" v-model="installationDirectory" @change="updatePath()">
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
      installationDirectory: this.$store.state.userprofile['EliteVA']['InstallationDirectory'],
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
    },

    resetInstallProgress() {
      this.$store.state.eliteva.inProgress = false;
      this.$store.state.eliteva.progress = 0;
    },

    updatePath() {
      let userprofile = this.$store.state.userprofile;
      userprofile['EliteVA']['InstallationDirectory'] = this.installationDirectory;
      this.$store.commit('send', {type: 'userprofile.set', value: userprofile});
    }
  }
};
</script>
<style lang="scss" scoped>
.ui {
  margin-top: 2rem;

  #path {
    min-width: 600px;
    width: 60%;
  }
}
</style>