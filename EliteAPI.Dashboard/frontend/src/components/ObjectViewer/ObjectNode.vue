<template>
  <div class="object-node" v-if="type !== 'null'" v-on:click.stop.prevent="toggleExpand"
       :class="{primitive: primitive}">
    <div class="node" @mouseenter="mouseEnter" @mouseleave="mouseLeave"
         :class="{hover: isHovering, redundant: name === 'Timestamp' || name === 'Event'}">
      <p class="arrow" :class="{rotated: isExpanded, hide: !canExpand}">▼</p>
      <p class="name">{{ name }}</p>
      <p class="preview" :class="type" v-if="!isExpanded">
        <span
          v-if="type === 'object' && maxChildren < cleanChildren.length">{ {{ cleanChildren.slice(0, maxChildren).join(", ") }} and {{ cleanChildren.length - maxChildren
          }} more }</span>
        <span v-else-if="type === 'object' && cleanChildren.length === 0">{ no values }</span>
        <span v-else-if="type === 'object' && cleanChildren.length > 0">{ {{ cleanChildren.join(", ") }} }</span>
        <span v-else-if="type === 'array' && value.length === 0">no values</span>
        <span v-else-if="type === 'array' && value.length === 1">1 value</span>
        <span v-else-if="type === 'array' && value.length > 1">{{ value.length }} values</span>
        <span v-else-if="type === 'number'" :class="type">{{ value.toLocaleString() }}</span>
        <span v-else-if="type === 'boolean'" :class="type + ' ' + value">{{ value.toLocaleString() }}</span>
        <span v-else :class="type">{{ value }}</span>
      </p>
    </div>
    <div class="values" v-if="type === 'object' && isExpanded">
      <ObjectNode :value="value[child]" :name="child" v-for="child in children" :key="child"
                  @childMouseEnter="mouseEnter" @childMouseLeave="mouseLeave" />
    </div>
    <div class="values" v-else-if="type === 'array' && isExpanded">
      <ObjectNode :value="arrayValue" :name="'[' + index.toString() + ']'" v-for="(arrayValue, index) in value"
                  :key="arrayValue" @childMouseEnter="mouseEnter" @childMouseLeave="mouseLeave" />
    </div>
  </div>
</template>
<script>
export default {
  name: "ObjectNode",
  props: {
    value: [Object, Array, String, Number, Boolean, Date],
    name: String
  },
  data() {
    return {
      isHovering: false,
      maxChildren: 2,
      isExpanded: false
    };
  },
  computed: {
    type() {
      let _type = typeof (this.value);
      if (_type === "object") {
        if (this.value == null) {
          return "null";
        }
        if (Array.isArray(this.value)) {
          return "array";
        }
        return "object";
      }
      return _type;
    },
    primitive() {
      return !(this.type === "array" || this.type === "object");
    },
    canExpand() {
      if (this.primitive) {
        return false;
      } else return this.children.length !== 0;
    },
    children() {
      if (this.type === "array") {
        return this.value;
      }

      if (this.type === "object") {
        return Object.keys(this.value);
      }

      return null;
    },

    cleanChildren() {
      if (this.type === "object") {
        return this.children.filter(x => x !== "Timestamp" && x !== "Event");
      }

      return this.children;
    }
  },
  methods: {
    toggleExpand() {
      if (!this.canExpand)
        return;

      this.isExpanded = !this.isExpanded;
    },

    mouseEnter() {
      this.isHovering = true;
      this.$emit("childMouseEnter");
    },

    mouseLeave() {
      this.isHovering = false;
      this.$emit("childMouseLeave");
    }
  }
};
</script>
<style lang="scss" scoped>
.object-node .object-node {
  margin-left: 1.7rem;
}

.object-node {
  display: flex;
  flex-direction: column;
  cursor: pointer;

  .name {
    min-width: 2rem;
  }

  .node.redundant {
    .preview, .name {
      opacity: 0.6;
    }
  }

  .node {
    display: flex;
    align-items: center;

    transition: 80ms;

    &.hover {
      color: $accent !important;
    }

    .arrow {
      font-size: .7rem;
      transform: rotateZ(-90deg);
      color: $text-muted;

      &.rotated {
        transform: rotateZ(0deg);
      }

      &.hide {
        opacity: 0;
      }
    }

    p {
      margin: 0 1rem 0 0;
    }

    .preview {
      color: $text-muted;
      overflow: hidden;
      width: auto;
      cursor: text;

      &.object, &.array {
        cursor: pointer;
      }

      &.string {
        color: #68b9de
      }

      &.number {
        color: #a65cc1
      }

      &.boolean .false {
        color: #ea5461
      }

      &.boolean .true {
        color: #72c454
      }
    }
  }
}
</style>