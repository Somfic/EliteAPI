<template>
  <div id="welcome">
    <div>
      <div class="welcome">
        <h1><span class="secondary">Welcome Commander</span> <span class="primary">{{ name }}</span></h1>
        <p>Please choose your preferred platform</p>
      </div>
      <div class="links">
        <div class="link-wrapper">
          <Card class="link" @click="setPreferred('voiceattack')">
            <h1>VoiceAttack</h1>
          </Card>
        </div>
        <div class="link-wrapper">
          <Card class="link disabled">
            <h1>VoiceMacro</h1>
          </Card>
        </div>
        <div class="link-wrapper">
          <Card class="link disabled">
            <h1>More coming soon</h1>
          </Card>
        </div>
      </div>

      <div class="skip">
        <Card @click="setPreferred('skip')">
          <p>Skip for now</p>
        </Card>
      </div>
    </div>
  </div>
</template>
<script>
import Card from "@/components/Cards/Card";
import router from "@/router";

export default {
  name: "Welcome",
  components: {Card},
  async created() {
    this.updateData();
    setInterval(() => {
      this.updateData();
    }, 1000);
  },
  data() {
    return {
      name: "",
    }
  },
  methods: {
    updateData() {
      this.name = this.$store.state.sortedEvents["Commander"] ? this.$store.state.sortedEvents["Commander"][0]["Name"] : 'o7';
    },

    setPreferred(preferred) {
      let userprofile = this.$store.state.userprofile;
      userprofile['FirstRun'] = false;
      this.$store.commit('send', {type: 'userprofile.set', value: userprofile});

      switch (preferred) {
        case 'voiceattack':
          router.push({name: "EliteVA"})
          break;

        default:
          router.push({name: "Home.vue"});
          break;
      }
    }
  }
}
</script>
<style lang="scss" scoped>
#welcome {
  flex-grow: 1;
  display: flex;
  align-items: center;
  justify-content: center;
}

.welcome {
  text-align: center;
  margin-bottom: 3rem;

  h1 {
    opacity: 1;
    transition: 800ms ease;
    margin: 0 0 1rem 0;
    line-height: 3rem;

    .primary {
      filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
      color: $accent;
      transition-delay: 300ms;
      text-transform: uppercase;
    }

    .secondary {
      filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
      color: $foreground;
      transition-delay: 450ms;
      text-transform: uppercase;
    }
  }

  p {
    color: mix($foreground, $background);
  }
}

.links {
  grid-template-columns: 1fr 1fr 1fr;
  margin-bottom: 2rem;
}

.skip {
  display: flex;
  justify-content: space-around;
  color: $text-muted;
}
</style>