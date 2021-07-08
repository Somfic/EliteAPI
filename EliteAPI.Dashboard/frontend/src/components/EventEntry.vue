<template>
  <Card class="event-entry" no-hover>
    <div class="information">
      <ObjectViewer :value="entry" :name="entry['Event']" />
      <p class="timestamp">{{ ago }}</p>
    </div>
  </Card>
</template>
<script>
import ObjectViewer from "@/components/ObjectViewer/ObjectNode";
import Card from "@/components/Cards/Card";
const moment = require("moment");

export default {
  name: "EventEntry",
  components: { Card, ObjectViewer },
  props: {
    entry: Object
  },
  data() {
    return {
      ago: this.getTimeAgo()
    };
  },
  async created() {
    setInterval(() => {
      this.ago = this.getTimeAgo();
    }, 5000);
  },
  methods: {
    getTimeAgo() {
      if (moment(this.entry["Timestamp"]).isAfter()) {
        return moment(new Date()).fromNow();
      } else {
        return moment(this.entry["Timestamp"]).fromNow();
      }
    }
  }
};
</script>
<style lang="scss" scoped>
.event-entry {
  padding: .75rem 1rem;
  border: $neuBorder;
  border-radius: $neuBorderRadiusSmall;
  box-shadow: $neuShadowSmall;
  margin: .5rem 0;
  display: flex;
  justify-content: space-between;

  p {
    margin: 0;
    word-wrap: anywhere;
  }

  .information {
    width: 100%;
    display: flex;
    justify-content: space-between;

    .timestamp {
      color: $text-muted;
      white-space: nowrap;
    }
  }
}
</style>