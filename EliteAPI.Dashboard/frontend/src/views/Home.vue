<template>
  <div class="greeting">
    <div class="name">
      <h3>{{ greeting }},</h3>
      <h1>CMDR {{ name }}</h1>
    </div>
    <div class="status-wrapper">
      <!--      <div class="status" v-if="isPlaying">-->
      <!--        <h1>{{ currentCredits }} CR</h1>-->
      <!--        <h3>Credits</h3>-->
      <!--      </div>-->
      <div class="status" v-if="isDocked && !isInMainMenu && isPlaying">
        <h1>{{ currentDocked }}</h1>
        <h3>Docked at</h3>
      </div>
      <div class="status" v-if="isLanded && !isInMainMenu && isPlaying">
        <h1>{{ currentLanded }}</h1>
        <h3>Landed on</h3>
      </div>
      <div class="status" v-if="isInNormalSpace && !isDocked && !isLanded && !isInJump && !isInMainMenu && isPlaying">
        <h1>{{ currentBody }}</h1>
        <h3>Flying around</h3>
      </div>
      <div class="status" v-if="isInMainMenu && isPlaying">
        <h1>MAIN MENU</h1>
        <h3>currently in</h3>
      </div>
      <div class="status" v-if="isPlaying && !isInMainMenu">
        <h1>{{ currentSystem }}</h1>
        <h3>Current system</h3>
      </div>
      <div class="status">
        <h1>{{ playTime }}</h1>
        <h3 v-if="isPlaying">Playtime</h3>
        <h3 v-else>Last played</h3>
      </div>
    </div>
  </div>
  <div class="links">
    <CardLink :to="{name: 'EliteVA'}" text="VoiceAttack" big />
    <CardLink :to="{name: 'Logs'}" text="Logs" />
    <CardLink :to="{name: 'Events'}" text="Events" />
    <CardLink :to="{name: 'Home'}" text="Status" />
    <CardLink :to="{name: 'Home'}" text="Cargo" />
    <CardLink :to="{name: 'Home'}" text="Modules" />
    <CardLink :to="{name: 'Home'}" text="Market" />
    <CardLink :to="{name: 'Home'}" text="Outfitting" />
    <CardLink :to="{name: 'Home'}" text="Shipyard" />
    <CardLink :to="{name: 'Home'}" text="Nav route" />
    <CardLink :to="{name: 'Home'}" text="Bindings" />
  </div>
  <div class="footer">
    <p>EliteAPI v{{ eliteApiVersion }}</p>
  </div>
</template>
<script>
const moment = require("moment");
import CardLink from "@/components/Cards/CardLink";

export default {
  name: "Home",
  components: { CardLink },
  data() {
    return {
      greeting: "",
      name: "",
      state: "",
      isPlaying: false,
      playTime: null,

      isDocked: false,
      currentDocked: "",

      isLanded: false,
      currentLanded: "",

      isInNormalSpace: false,
      isInJump: false,
      currentBody: "",

      currentSystem: "",
      currentCredits: "",

      eliteApiVersion: this.$store.state.eliteapi["Version"],

      isInMainMenu: false
    };
  },
  async created() {
    setInterval(() => {
      this.updateData();
    }, 1000);

    this.updateData();
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
    },

    getPlaytime() {
      if (this.isPlaying) {
        let startedPlaying = moment(new Date(this.$store.state.sortedEvents["Fileheader"][0]["Timestamp"]));
        let stoppedPlaying = moment(new Date());
        return moment.duration(stoppedPlaying.diff(startedPlaying)).humanize(false);
      } else {
        let stoppedPlaying = moment(new Date(this.$store.state.sortedEvents["Shutdown"][0]["Timestamp"]));
        return stoppedPlaying.fromNow();
      }
    },

    getIsPlaying() {
      return !this.$store.state.sortedEvents["Shutdown"] || this.$store.state.sortedEvents["Fileheader"].length > this.$store.state.sortedEvents["Shutdown"].length;
    },

    updateData() {
      this.greeting = this.getGreeting();
      this.name = this.$store.state.sortedEvents["Commander"][0]["Name"];
      this.isPlaying = this.getIsPlaying();

      this.playTime = this.getPlaytime();
      this.isDocked = this.$store.state.status["Docked"];
      this.currentDocked = this.$store.state.status["Docked"] ? this.$store.state.sortedEvents["Docked"][0]["StationName"] : "";

      this.isLanded = this.$store.state.status["Landed"];
      this.currentLanded = this.$store.state.status["Landed"] ? this.$store.state.sortedEvents["Touchdown"][0]["Body"] : "";

      this.isInJump = this.$store.state.status["FsdJump"];

      this.currentSystem = this.$store.state.events.filter(x => x.StarSystem)[0]["StarSystem"];
      this.currentCredits = this.$store.state.sortedEvents["LoadGame"][0]["Credits"].toLocaleString();

      this.isInMainMenu = this.$store.state.sortedEvents["Music"][0]["MusicTrack"] === "MainMenu";

      this.isInNormalSpace = !this.$store.state.status["Supercruise"];
      this.currentBody = !this.$store.state.status["Supercruise"] ? this.$store.state.sortedEvents["SupercruiseExit"][0]["Body"] : "";
      if (this.currentBody === this.currentSystem) {
        this.currentBody = "empty space";
      }
    }
  }
};
</script>
<style lang="scss" scoped>
.greeting {
  display: flex;
  justify-content: space-between;
  align-items: center;

  .status-wrapper {
    display: flex;

    .status {
      display: flex;
      flex-direction: column;
      text-align: right;
      margin-left: 3rem;

      &:first-child {
        margin-left: 0;
      }

      h1 {
        font-size: 1.5rem;
        margin: 0;
        color: $foreground;
        line-height: 1.2rem;
        filter: drop-shadow(0 0 5px transparentize($foreground, 0.7));
        white-space: nowrap;
      }

      h3 {
        font-size: 1rem;
        margin: 0;
        line-height: 1.2rem;
        color: mix($foreground, $background);
        text-transform: lowercase;
        white-space: nowrap;
      }
    }
  }

  h1 {
    text-transform: uppercase;
    margin: 0 0 2rem;
    line-height: 2rem;
    color: $accent;
    filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
  }

  h3 {
    filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
    margin: 0;
    line-height: 1.8rem;
  }
}

.links {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 1rem;
}

.footer {
  flex-grow: 100;
  color: mix($foreground, $background);
  padding-top: 2rem;
  display: flex;
  align-items: flex-end;

  p {
    margin: 0;
    margin-left: auto;
  }
}
</style>