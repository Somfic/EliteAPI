<template>
  <KnownLoader icon="/img/logo.png" text="Initializing EliteAPI" sub-text="Testing stuff" :percentage="this.$store.state.catchup.current / this.$store.state.catchup.total" />
</template>
<script>
import KnownLoader from "@/components/Loaders/KnownLoader";
export default {
  name: 'Home',
  components: { KnownLoader },
  data() {
    return {
      greeting: this.getGreeting()
    }
  },
  methods: {
    getGreeting() {
      let today = new Date();
      let curHr = today.getHours();

      if (curHr < 12) {
        return 'Good morning'
      } else if (curHr < 18) {
        return 'Good afternoon'
      } else {
        return 'Good evening';
      }
    }
  }
}
</script>