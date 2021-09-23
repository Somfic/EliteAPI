<template>
  <router-link v-if="to" :to="to" class="card" :class="{hover: !noHover}">
    <div class="notice" v-if="noticeIf">{{notice}}</div>
    <slot/>
  </router-link>
  <div v-else class="card" :class="{hover: !noHover}">
    <div class="notice" v-if="noticeIf">{{notice}}</div>
    <slot/>
  </div>
</template>
<script>
export default {
  name: "Card",
  props: {
    to: Object,
    noHover: Boolean,
    notice: String,
    noticeIf: Boolean
  }
};
</script>
<style lang="scss" scoped>
.card {
  position: relative;
  border: $neuBorder;
  border-radius: $neuBorderRadiusSmall;
  box-shadow: $neuShadowSmall;
  padding: 1rem 2rem;
  text-decoration: none;
  transition: 200ms;
  display: flex;
  flex-direction: column;
  background: transparentize($background, .2);
  backdrop-filter: blur(6px);
  margin-bottom: 1rem;
  color: mix($foreground, $background);

  .notice {
    position: absolute;
    top: 0;
    right: 0;
    margin: 20px;
    border: 2px solid $accent;
    border-radius: 200px;
    padding: .25rem 1rem;
    color: $accent;
    text-transform: uppercase;
    background-color: transparentize(mix($accent, $background), .9);
  }

  &.hover {
    cursor: pointer;
  }

  &.hover:hover {
    transform: translateY(-5px);
    border-color: transparentize($accent, .4);
    background: transparentize(mix($foreground, $background, 3%), .2);
    color: $accent;
  }
}
</style>