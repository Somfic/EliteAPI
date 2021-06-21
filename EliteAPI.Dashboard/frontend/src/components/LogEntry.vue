<template>
  <div class="log-entry" :class="log['LogLevel'].toLowerCase()">
    <div class="message">
      <p>{{ log["Message"] }}</p>
      <p v-if="log['Exception']" class="exception">
        <span class="type">{{ log["ExceptionType"] }}</span> :
        {{ log["Exception"]["Message"] }}
      </p>
    </div>
    <div class="information">
      <span class="timestamp">{{ ago }}</span>
    </div>
  </div>
</template>
<script>
const moment = require("moment");

export default {
  name: "LogEntry",
  props: {
    log: Object,
  },
  data() {
    return {
      ago: this.getTimeAgo()
    }
  },
  async created() {
    setInterval(() => {
      this.ago = this.getTimeAgo();
    }, 5000);
  },
  methods: {
    getTimeAgo() {
      if (moment(this.log["Timestamp"]).isAfter()) {
        return moment(new Date()).fromNow();
      } else {
        return moment(this.log["Timestamp"]).fromNow();
      }
    }
  }
};
</script>
<style lang="scss" scoped>
.log-entry {
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

  .timestamp {
    color: $text-muted;
    white-space: nowrap;
  }

  .level {
    white-space: nowrap;
    opacity: 0.6;
    font-weight: $fontBold;
  }

  .exception {
    opacity: 0.6;

    .type {
      font-style: italic;
    }
  }

  .information {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: flex-end;
  }

  &.trace {
    color: mix($foreground, $background);
    display: none;
  }

  &.debug {
    color: mix($foreground, gray)
  }

  &.information {
    color: mix($foreground, #00a6ff)
  }

  &.warning {
    color: mix($foreground, yellow)
  }

  &.error {
    color: mix($foreground, red)
  }

  &.critical {
    color: mix($foreground, purple)
  }
}
</style>