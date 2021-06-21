<template>
  <TitleBar title="Event logs" :to="{name: 'Home'}"/>
  <Loader :has-loaded="this.$store.state.events.length > 0">
    <EventEntry :entry="eliteEvent" v-for="eliteEvent in this.$store.state.events" :key="eliteEvent" />
  </Loader>
</template>

<script>
import EventEntry from "@/components/EventEntry";
import Loader from "@/components/Loader";
import TitleBar from "@/components/TitleBar";

export default {
  name: "EventLog",
  components: { TitleBar, Loader, EventEntry}
};
</script>
