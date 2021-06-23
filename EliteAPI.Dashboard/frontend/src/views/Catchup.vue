<template>
  <p>{{state}}</p>
  <KnownLoader icon="/img/logo.png" text="Initializing EliteAPI" sub-text="Greetings Commander"
               @animateIn="this.$store.commit('connect')"
               @animateOut="this.$router.push({name: 'Home'})"
               :finished="this.$store.state.catchup.hasCaughtUp"
               :percentage=" this.$store.state.catchup.total === 0 ? 0 : this.$store.state.catchup.current / this.$store.state.catchup.total" />
</template>
<script>
import KnownLoader from "@/components/Loaders/KnownLoader";

export default {
  name: "Catchup",
  components: { KnownLoader },
  data() {
    return {
      greeting: this.getGreeting(),
      state: ''
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
    }
  }
};
</script>