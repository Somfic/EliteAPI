<template>
  <KnownLoader icon="/img/eliteapi.svg" text="Initializing EliteAPI" sub-text="Greetings Commander"
               :indeterminate="this.$store.state.connection.state === 'connecting'"
               :is-loading="this.$store.state.connection.state !== 'closed'"
               @animateIn="this.$store.commit('connect')"
               @animateOut="this.$router.push({name: 'Home'})"
               :finished="this.$store.state.catchup.hasCaughtUp"
               :percentage=" this.$store.state.catchup.total === 0 ? 0 : this.$store.state.catchup.current / this.$store.state.catchup.total"
               :status="getStatus()"
  />
</template>
<script>
import KnownLoader from "@/components/Loaders/KnownLoader";

export default {
  name: "Catchup",
  components: { KnownLoader },
  data() {
    return {
      greeting: this.getGreeting(),
      state: "Hello world",
    };
  },
  methods: {
    getGreeting() {
      let today = new Date();
      let curHr = today.getHours();

      if (curHr < 12) {
        return "Good morning";
      } else if (curHr < 18) {
        return "Good afternoon";
      } else {
        return "Good evening";
      }
    },

    getStatus() {
      if(this.$store.state.connection.state === 'connecting') {
        return "Connecting to EliteAPI"
      }

      if(this.$store.state.connection.state === 'closed') {
        return "Could not connect to EliteAPI"
      }

      if(!this.$store.state.catchup.isCatchingUp && !this.$store.state.catchup.hasCaughtUp) {
        return 'Authenticating with EliteAPI'
      }

      if(this.$store.state.catchup.isCatchingUp && !this.$store.state.catchup.hasCaughtUp) {
        return "Catching up with past events in this session"
      }

      if(this.$store.state.catchup.hasCaughtUp) {
        return ""
      }
    }
  }
};
</script>
