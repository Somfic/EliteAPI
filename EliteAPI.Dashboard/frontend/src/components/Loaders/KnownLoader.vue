<template>
  <div class="loader-wrapper" :class="{hide: !imgLoaded, finished: finished }">
    <div class="loader">
      <div class="icon">
        <img :src="icon" alt="" @load="imgLoad">
      </div>
      <div class="text">
        <h1 class="primary">{{ text }}</h1>
        <div class="horizontal-loader">
          <LoadingIndicator />
          <ProgressBar :percentage="percentage" />
        </div>
        <h1 class="secondary">{{ subText }}</h1>
      </div>
    </div>
  </div>
</template>
<script>
import ProgressBar from "@/components/Loaders/ProgressBar";
import LoadingIndicator from "@/components/Loaders/LoadingIndicator";

export default {
  name: "KnownLoader",
  components: { LoadingIndicator, ProgressBar },
  data() {
    return {
      imgLoaded: false
    };
  },
  props: {
    text: String,
    subText: String,
    icon: String,
    percentage: Number,
    finished: Boolean
  },
  async mounted() {
    if (!this.icon) {
      this.imgLoaded = true;
      this.setAnimateIn();
    }
  },
  watch: {
    finished() {
      if (this.finished) {
        this.setAnimateOut();
      }
    }
  },

  methods: {
    setAnimateIn() {
      setTimeout(() => {
        this.$emit("animateIn");
      }, 1000);
    },

    setAnimateOut() {
      setTimeout(() => {
        this.$emit("animateOut");
      }, 1100);
    },

    imgLoad() {
      this.imgLoaded = true;
      this.setAnimateIn();
    }
  }
};
</script>
<style lang="scss" scoped>
.loader-wrapper {
  flex-grow: 1;
  display: flex;
  align-items: center;
  justify-content: center;

  &.hide {
    .icon {
      opacity: 0;
      transform: translateY(20px);
    }

    .progress-bar {
      max-width: 0 !important;
    }

    h1 {
      opacity: 0 !important;
      transform: translateX(-25px);
    }

    .loading-indicator {
      right: 1rem !important;
      opacity: 0 !important;
    }
  }

  &.finished {
    .icon {
      opacity: 0;
      transform: translateY(-20px);
    }

    .progress-bar {
      max-width: 0 !important;
      margin-left: auto;
    }

    h1 {
      opacity: 0 !important;
      transform: translateX(25px);
      transition-delay: 600ms;
    }

    .loading-indicator {
      right: -1rem !important;
      opacity: 0 !important;
    }
  }

  .loader {
    display: flex;
    align-items: center;

    .horizontal-loader {
      position: relative;

      .progress-bar {
        transition: 800ms ease-in-out;
        transition-delay: 200ms;
        max-width: 100%;
      }

      max-width: 1000px;

      .loading-indicator {
        opacity: 1;
        transition: 800ms ease;
        transition-delay: 650ms;
        position: absolute;
        bottom: .5rem;
        right: 0;
      }
    }

    .icon {
      transition: 600ms ease-out;

      img {
        max-height: 10rem;
        max-width: 10rem;
        filter: drop-shadow(0 0 5px transparentize($accent, 0.7));
      }
    }

    .text {
      display: flex;
      flex-direction: column;

      h1 {
        opacity: 1;
        transition: 800ms ease;
        margin: 0 3rem 0 0;
        line-height: 3rem;
        min-width: 300px;
        text-transform: uppercase;

        &.primary {
          filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
          color: $accent;
          transition-delay: 300ms;
        }

        &.secondary {
          filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
          color: $foreground;
          transition-delay: 450ms;
        }
      }
    }
  }
}
</style>