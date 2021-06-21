<template>
  <button v-if="!to"
          class="button"
          :class="{ 'only-icon': !text && icon, 'enabled': !disabled }"
          :disabled="disabled"
          @click="clicked"
  >
    <img v-if="image"
         :src="image"
    >
    <i v-if="icon"
       class="icon"
       :class="iconClass + ' fa-' + icon"
    />
    <span v-if="text"
          class="label">{{ text }}
    </span>
  </button>
  <router-link v-else-if="!to.toString().startsWith('http')"
               :to="to"
               class="button"
               :class="{ 'only-icon': !text && icon, 'enabled': !disabled  }"
  >
    <img v-if="image"
         :src="image"
    >
    <i v-if="icon"
       class="icon"
       :class="iconClass + ' fa-' + icon"/>
    <p v-if="text"
       class="label">{{ text }}
    </p>
  </router-link>
  <a v-else
     :href="to"
     class="button"
     :class="{ 'only-icon': !text && icon, 'enabled': !disabled  }"
  >
    <img v-if="image"
         :src="image"
    >
    <i v-if="icon"
       class="icon"
       :class="iconClass + ' fa-' + icon"/>
    <p v-if="text"
       class="label">{{ text }}
    </p>
  </a>
</template>
<script>
export default {
  name: "Button",
  props: {
    to: Object,
    icon: String,
    text: String,
    image: String,
    disabled: Boolean
  },
  data() {
    return {
      iconClass: this.getIconClass()
    }
  },
  methods: {
    clicked() {
      this.$emit('click')
    },

    getIconClass() {
      if(this.icon === 'github' || this.icon === 'discord') {
        return 'fab';
      }

      return 'fas'
    }
  }
};
</script>
<style lang="scss" scoped>
$size: 3rem;

.button {
  font-family: $fontMono;
  border: $neuBorder;
  height: $size;
  padding: 0 ($size / 2);
  background: $neuBackground;
  box-shadow: $neuShadowSmall;
  text-decoration: none;


  display: flex;
  align-items: center;
  justify-content: center;

  margin: 0 $size / 3;

  border-radius: $neuBorderRadius;

  color: based-background($background, $foreground, mix($foreground, $background));
  transition: 200ms ease;

  .icon {
    color: based-background($background, $foreground, mix($foreground, $background));
    transition: 200ms ease;
  }

  &.only-icon {
    padding: 0;
    width: $size;
    height: $size;
  }

  img {
    max-height: 85%;
    border-radius: 100px;
    margin-left: -1.25rem;
    margin-right: .5rem;
    opacity: based-background($background, 0.8, 0.6);
  }

  &:hover.enabled,
  &:active.enabled
  &:focus.enabled {
    color: based-background($background, $foreground, $accent);
    text-shadow: 0px 0px based-background($background, 0px, 10px) transparentize($accent, .5);

    .icon {
      color: based-background($background, $foreground, $accent);
      filter: drop-shadow(0px 0px based-background($background, 0px, 10px) transparentize($accent, .5));
    }

    text-decoration: none;
    outline: none;
    padding-bottom: 2px;
    margin-top: -2px;
  }

  &:active.enabled {
    background: $neuBackgroundPushed;
  }

  &:disabled .label,
  &:disabled .icon {
    color: mix($foreground, $background);
  }

  &:focus {
    outline: none
  }

  &.router-link-active {
    background: $neuBackgroundPushed;
  }

  .label {
    margin: 0;
  }

  .icon + .label {
    margin-left: 0.5rem;
  }
}
</style>