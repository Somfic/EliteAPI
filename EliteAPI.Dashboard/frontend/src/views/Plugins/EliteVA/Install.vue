<template>
  <TitleBar title="Installing EliteVA"/>
  <KnownLoader icon="/img/eliteapi.svg" text="Installing EliteVA" sub-text="VoiceAttack plugin"
               :indeterminate="this.$store.state.eliteva.progress === 0 || this.$store.state.eliteva.progress === 100"
               :is-loading="this.$store.state.eliteva.inProgress"
               @animateIn="this.$store.commit('send', {type: 'eliteva.install'})"
               @animateOut="this.$router.push({name: 'EliteVA'})"
               :finished="this.$store.state.eliteva.progress === 100 && !this.$store.state.eliteva.inProgress"
               :percentage="this.$store.state.eliteva.progress / 100"
  />
</template>

<script>
import TitleBar from "@/components/TitleBar";
import KnownLoader from "@/components/Loaders/KnownLoader";

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