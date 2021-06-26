<template>
  <router-link :to="to" class="card" :class="{big: big}">
    <h1>{{ text }}</h1>
  </router-link>
</template>
<script>
export default {
  name: "CardLink",
  props: {
    to: Object,
    text: String,
    big: Boolean
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
  align-items: flex-end;
  position: relative;

  h1 {
    margin-top: auto;
    font-size: calc(3vw + 3vh);
    color: $foreground;
  }

  &.big {
    grid-column: span 2;
    grid-row: span 2;

    h1 {
      font-size: 3rem;
    }
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

  &:hover {
    transform: translateY(-5px);
    border-color: $accent;

    h1 {
      color: $accent;
      filter: drop-shadow(0 0 5px transparentize($accent, 0.8));
    }
  }
}
</style>