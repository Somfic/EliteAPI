<template>
  <div class="title-bar">
    <Button icon="arrow-left" :to="to" v-if="to"/>
    <h1>{{ title }}</h1>
  </div>
</template>
<script>
import Button from "@/components/Button";
export default {
  name: "TitleBar",
  components: { Button },
  props: {
    canGoBack: Boolean,
    title: String,
    to: Object
  },
  methods: {
    goBack() {
      if(window.history.length > 2) {
        this.$router.back()
      } else {
        this.$router.push({name: 'Home.vue'})
      }
    }
  }
};
</script>
<style lang="scss">
.title-bar {
  display: flex;
  align-items: center;
  padding: 2rem 0;

  .fa {
    margin-right: 2rem;
  }

  .button {
    margin-left: 0;
    margin-right: 2rem;
  }

  h1 {
    margin: 0;
    color: $foreground;
    filter: drop-shadow(0 0 5px transparentize($foreground, 0.8));
  }
}
</style>