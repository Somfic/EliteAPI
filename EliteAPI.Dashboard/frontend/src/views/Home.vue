<template>
  <div class="greeting" :class="{hidden: hidden}">
    <div class="name">
      <h3>{{ greeting }},</h3>
      <h1>CMDR {{ name }}</h1>
    </div>
    <div class="status-wrapper">
      <!--      <div class="status" v-if="isPlaying">-->
      <!--        <h1>{{ currentCredits }} CR</h1>-->
      <!--        <h3>Credits</h3>-->
      <!--      </div>-->
      <div class="status" v-if="isInMainMenu && isPlaying">
        <h1>MAIN MENU</h1>
        <h3>currently in</h3>
      </div>
      <div class="status" v-if="isPlaying && !isInMainMenu && currentSystem">
        <h1>{{ currentSystem }}</h1>
        <h3>Current system</h3>
      </div>
      <div class="status" v-if="isDocked && !isInMainMenu && isPlaying && currentDocked">
        <h1>{{ currentDocked }}</h1>
        <h3>Docked at</h3>
      </div>
      <div class="status" v-if="isLanded && !isInMainMenu && isPlaying && currentLanded">
        <h1>{{ currentLanded }}</h1>
        <h3>Landed on</h3>
      </div>
      <div class="status" v-if="isInNormalSpace && !isDocked && !isLanded && !isInJump && !isInMainMenu && isPlaying && currentBody">
        <h1>{{ currentBody }}</h1>
        <h3>Flying around</h3>
      </div>
      <div class="status">
        <h1>{{ playTime }}</h1>
        <h3 v-if="isPlaying">Playtime</h3>
        <h3 v-else>Last played</h3>
      </div>
    </div>
  </div>
  <div class="links" :class="{hidden: hidden}">
    <div class="link-wrapper big">
      <Card class="link" :to="{name: 'EliteVA'}">
        <h1>VoiceAttack</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Events'}">
        <h1>Events</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Logs'}">
        <h1>Logs</h1>
      </Card>
    </div>

    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Status'}" :class="{disabled: !status}">
        <h1>Status</h1>
      </Card>
    </div>

    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Cargo'}" :class="{disabled: !cargo}">
        <h1>Cargo</h1>
      </Card>
    </div>

    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Modules'}" :class="{disabled: !modules}">
        <h1>Modules</h1>
      </Card>
    </div>

    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Market'}" :class="{disabled: !market}">
        <h1>Market</h1>
      </Card>
    </div>

    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Outfitting'}" :class="{disabled: !outfitting}">
        <h1>Outfitting</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Shipyard'}" :class="{disabled: !shipyard}">
        <h1>Shipyard</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'NavRoute'}" :class="{disabled: !navRoute}">
        <h1>Nav route</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Bindings'}" :class="{disabled: !bindings}">
        <h1>Bindings</h1>
      </Card>
    </div>
    <div class="link-wrapper">
      <Card class="link" :to="{name: 'Backpack'}" :class="{disabled: !backpack}">
        <h1>Backpack</h1>
      </Card>
    </div>
  </div>
  <div class="footer">
    <div>
      <p>EliteAPI v<b>{{ eliteApiVersion }}</b></p>
      <p v-if="gameVersion">Elite: Dangerous v<b>{{ gameVersion }}</b></p>
      <p>Running on port #<b>{{port}}</b></p>
    </div>
  </div>
</template>
<script>
import Card from "@/components/Cards/Card";

const moment = require("moment");

export default {
  name: "Home",
  components: {Card},
  data() {
    return {
      greeting: "",
      name: "",
      state: "",
      isPlaying: false,
      playTime: null,

      port: window.location.port,

      isDocked: false,
      currentDocked: "",

      isLanded: false,
      currentLanded: "",

      isInNormalSpace: false,
      isInJump: false,
      currentBody: "",

      currentSystem: "",
      currentCredits: "",

      eliteApiVersion: "",
      gameVersion: "",

      isInMainMenu: false,

      hidden: true,

      status: false,
      cargo: false,
      modules: false,
      market: false,
      outfitting: false,
      shipyard: false,
      navRoute: false,
      bindings: false,
      backpack: false,

    };
  },
  async created() {
    setTimeout(() => {
      this.hidden = false;
    }, 10)

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
      this.status = !(this.$store.state.status == null);
      this.cargo = !(this.$store.state.cargo == null);
      this.modules = !(this.$store.state.modules == null);
      this.market = !(this.$store.state.market == null);
      this.outfitting = !(this.$store.state.outfitting == null);
      this.shipyard = !(this.$store.state.shipyard == null);
      this.navRoute = !(this.$store.state.navRoute == null);
      this.bindings = !(this.$store.state.bindings == null);
      this.backpack = !(this.$store.state.backpack == null);

      this.eliteApiVersion = this.$store.state.eliteapi["Version"];
      this.gameVersion = this.$store.state.sortedEvents["Fileheader"] ? this.$store.state.sortedEvents['Fileheader'][0]["Gameversion"] : "";

      this.greeting = this.getGreeting();
      this.name = this.$store.state.sortedEvents["Commander"] ? this.$store.state.sortedEvents["Commander"][0]["Name"] : 'o7';
      this.isPlaying = this.getIsPlaying();

      this.playTime = this.getPlaytime();
      this.isDocked = this.$store.state.status["Docked"];
      this.currentDocked = this.$store.state.sortedEvents["Docked"] ? this.$store.state.sortedEvents["Docked"][0]["StationName"] : "";

      this.isLanded = this.$store.state.status["Landed"];
      this.currentLanded = this.$store.state.status["Landed"] ? this.$store.state.sortedEvents["Touchdown"][0]["Body"] : "";

      this.isInJump = this.$store.state.status["FsdJump"];

      this.currentSystem = this.$store.state.events.filter(x => x.StarSystem).length > 0 ? this.$store.state.events.filter(x => x.StarSystem)[0]["StarSystem"] : "";
      this.currentCredits = this.$store.state.sortedEvents["LoadGame"] ? this.$store.state.sortedEvents["LoadGame"][0]["Credits"].toLocaleString() : "";

      this.isInMainMenu = this.$store.state.sortedEvents["Music"] ? this.$store.state.sortedEvents["Music"][0]["MusicTrack"] === "MainMenu" : true;

      this.isInNormalSpace = !this.$store.state.status["Supercruise"];
      this.currentBody = !this.$store.state.status["Supercruise"] ? this.$store.state.events.filter(x => x.Body)[0]["Body"].replace(this.currentSystem, '') : "";
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
  transition: 500ms;

  &.hidden {
    opacity: 0;
    transform: translateY(20px);
  }

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
  grid-template-columns: repeat(auto-fit, minmax(190px, 1fr));
  gap: 1rem;

  @for $i from 1 through 30 {
    .link-wrapper:nth-child(#{$i}) {
      transition-delay: $i * 50ms;
    }
  }

  &.hidden {
    .link-wrapper {
      opacity: 0;
      transform: translateY(10px);
    }
  }

  .link-wrapper {
    transition: 200ms;

    &.big {
      grid-column: span 2;
      grid-row: span 2;

      h1 {
        font-size: 3rem;
      }
    }
  }

  .link {
    display: flex;
    flex-direction: row;
    align-items: flex-end;
    position: relative;
    margin-bottom: 0;
    height: 100%;
    width: 100%;

    h1 {
      margin-top: auto;
      font-size: calc(3vw + 3vh);
      color: $foreground;
    }

    h1 {
      font-size: 1.6rem;
      filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
    }

    &:after {
      content: "";
      display: block;
      padding-bottom: 100%;
    }

    &.disabled {
      h1 {
        color: transparentize($foreground, .8)
      }

      pointer-events: none;
    }

    &:hover {
      h1 {
        color: $accent;
        filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
      }
    }
  }
}

.footer {
  flex-grow: 100;
  color: mix($foreground, $background);
  padding-top: 2rem;
  display: flex;
  align-items: flex-end;
  justify-content: space-between;
  line-height: 1rem;
  font-size: .8rem;

  p {
    margin: 0 0 0 auto;
    color: mix($foreground, $background, 70%);
  }

  b {
    color: mix($foreground, $background, 90%);
    font-family: $fontMono;
  }
}
</style>