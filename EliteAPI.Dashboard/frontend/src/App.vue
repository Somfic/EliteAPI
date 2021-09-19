<template>
  <div class="ship-background-wrapper" :class="{hidden: !hasLoaded, swapping: isSwapping}">
    <img class="ship-background" :src="'/img/ships/cartoon/' + activeShip + '.svg'" alt="" @load="loaded">
  </div>
  <div id="root" :key="this.$route.name">
    <router-view />
  </div>
</template>

<script>
export default {
  name: "App",
  async mounted() {
    if (!this.$store.state.catchup.hasCaughtUp) {
      await this.$router.push({ name: "Catchup" });
    }

    setInterval(() => {
      this.setActiveShip();
    }, 500);
  },
  data() {
    return {
      activeShip: "",
      hasLoaded: false,
      isSwapping: false
    };
  },
  methods: {
    loaded() {
      this.hasLoaded = true;
    },

    setActiveShip() {
      if (this.$store.state.catchup.hasCaughtUp && this.$store.state.sortedEvents["Loadout"]) {
        let activeShip = this.$store.state.sortedEvents["Loadout"][0]["Ship"];

        if (activeShip !== this.activeShip && !this.isSwapping) {
          if (this.activeShip === "") {
            this.activeShip = activeShip;
          } else {
            this.isSwapping = true;

            setTimeout(() => {
              this.hasLoaded = false;
              this.activeShip = activeShip;
              this.isSwapping = false;
            }, 1000);
          }
        }
      }
    }
  }
};
</script>
<style lang="scss">
.ship-background-wrapper {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  overflow: hidden;
  pointer-events: none;
  z-index: -1;

  &.hidden {
    .ship-background {
      opacity: 0;
      transform: translate(-200px, -200px);
    }
  }

  &.swapping {
    .ship-background {
      opacity: 0;
      transform: translate(200px, 200px);
    }
  }
}

.ship-background {
  transition: 1000ms ease-out;
  width: 100%;
  height: auto;
  opacity: .2;
  filter: grayscale(0.7) drop-shadow(10px 10px 10px rgba(33, 32, 32, 0.57));
}
</style>