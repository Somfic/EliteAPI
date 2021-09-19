<template>
  <router-link v-if="to" :to="to" class="card" :class="{hover: !noHover}">
    <slot />
  </router-link>
  <div v-else class="card">
    <slot />
  </div>
</template>
<script>
export default {
  name: "Card",
  props: {
    to: Object,
    noHover: Boolean
  }
};
</script>
<style lang="scss" scoped>
.card {
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

  &.hover:hover {
    transform: translateY(-5px);
    border-color: transparentize($accent, .4);
    background: transparentize(mix($foreground, $background, 3%), .2);
  }
}
</style>