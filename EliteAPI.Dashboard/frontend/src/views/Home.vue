<template>
  <h1>Greetings, CMDR {{this.$store.state.sortedEvents['Commander'][0]['Name']}}</h1>
  <router-link :to="{name: 'MessageLog'}">EliteAPI logs</router-link>
  <router-link :to="{name: 'EventLog'}">Event logs</router-link>
</template>
<script>
export default {
  name: 'Home',
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