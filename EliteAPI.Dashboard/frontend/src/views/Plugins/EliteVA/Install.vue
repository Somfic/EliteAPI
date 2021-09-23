<template>
  <TitleBar title="Installing EliteVA" :to="{name: 'EliteVA'}"/>
  <KnownLoader icon="/img/eliteapi.svg" text="Installing EliteVA" :sub-text="'Version ' + this.newestVersion"
               :indeterminate="!this.$store.state.eliteva.error && (this.$store.state.eliteva.progress === 0 || this.$store.state.eliteva.progress === 100)"
               :is-loading="this.$store.state.eliteva.inProgress"
               @animateIn="install"
               @animateOut="this.$router.push({name: 'EliteVA'})"
               :finished="this.$store.state.eliteva.progress === 100 && !this.$store.state.eliteva.inProgress"
               :percentage="this.$store.state.eliteva.progress / 100"
               :status="this.status"
  />
</template>

<script>
import TitleBar from "@/components/TitleBar";
import KnownLoader from "@/components/Loaders/KnownLoader";
import {nextTick} from "vue";

export default {
  name: "EliteVA",
  components: {KnownLoader, TitleBar},
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
      newestVersion: '',
      installationDirectory: null,
      status: null
    }
  },
  methods: {
    updateData() {
      this.installed = this.$store.state.userprofile['EliteVA']['IsInstalled'];
      this.installedVersion = this.$store.state.userprofile['EliteVA']['InstalledVersion'];
      this.newestVersion = this.$store.state.eliteva.newestVersion;
      this.installationDirectory = this.$store.state.userprofile['EliteVA']['InstallationDirectory'];

      this.status = this.$store.state.eliteva.task;
    },

    install() {
      nextTick(() => {
        this.$store.commit('send', {type: 'eliteva.install', value: 'just intsall please'});
      })
    }
  }
};
</script>