<template>
  <TitleBar title="EliteAPI logs" :to="{name: 'Home'}"/>
  <Loader :has-loaded="this.$store.state.logs.length > 0">
    <LogEntry :log="log" v-for="log in this.$store.state.logs" :key="log" />
  </Loader>
</template>

<script>
import LogEntry from "@/components/LogEntry";
import Loader from "@/components/Loader";
import TitleBar from "@/components/TitleBar";

export default {
  name: "MessageLog",
  components: { TitleBar, Loader, LogEntry }
};
</script>
