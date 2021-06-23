<template>
  <TitleBar title="Event logs" :to="{name: 'Home'}" />
    <div class="entries" :class="{hidden: hidden}">
      <EventEntry :entry="eliteEvent" v-for="eliteEvent in events" :key="eliteEvent" />
    </div>
</template>

<script>
import EventEntry from "@/components/EventEntry";
import TitleBar from "@/components/TitleBar";

export default {
  name: "EventLog",
  components: { TitleBar, EventEntry },
  data() {
    return {
      hidden: true,
      events: this.$store.state.events
    };
  },

  async mounted() {
   setTimeout(() => {
     this.hidden = false;
   }, 300)
  }
};
</script>
<style lang="scss" scoped>
.hidden {
  .event-entry {
    transform: translateY(20px);
    opacity: 0;
  }
}

.event-entry {
  transition: all 200ms ease;
  opacity: 1;
}

@for $i from 1 through 30 {
  .event-entry:nth-child(#{$i}) {
    transition-delay: $i * 50ms;
  }
}
</style>
