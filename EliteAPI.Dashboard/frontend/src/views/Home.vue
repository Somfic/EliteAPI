<template>
  <div class="greeting">
    <h3>{{ greeting }},</h3>
    <h1>CMDR {{ name }}</h1>
    <router-link :to="{name: 'Logs'}">Logs</router-link>
    <router-link :to="{name: 'Events'}">Events</router-link>
  </div>
</template>
<script>
export default {
  name: "Home",
  data() {
    return {
      greeting: this.getGreeting(),
      name: this.$store.state.sortedEvents["Commander"][0]["Name"],
      state: ""
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
<style lang="scss" scoped>
.greeting {
  h1 {
    text-transform: uppercase;
    margin: 0;
    line-height: 1.5rem;
    color: $accent;
    filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
  }

  h3 {
    filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
    margin: 0;
  }
}
</style>