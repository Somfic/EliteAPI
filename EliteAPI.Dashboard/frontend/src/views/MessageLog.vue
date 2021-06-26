<template>
  <TitleBar title="EliteAPI log" :to="{name: 'Home'}" />
  <div class="entries" :class="{hidden: hidden}">
    <LogEntry :log="log" v-for="log in logs" :key="log" />
  </div>
</template>

<script>
import LogEntry from "@/components/LogEntry";
import TitleBar from "@/components/TitleBar";

export default {
  name: "MessageLog",
  components: { TitleBar, LogEntry },
  data() {
    return {
      hidden: true,
      logs: this.$store.state.logs
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
  .log-entry {
    transform: translateY(20px);
    opacity: 0;
  }
}

.log-entry {
  transition: all 200ms ease;
  opacity: 1;
}

@for $i from 1 through 30 {
  .log-entry:nth-child(#{$i}) {
    transition-delay: $i * 50ms;
  }
}
</style>