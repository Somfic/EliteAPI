<template>
  <TitleBar title="Bindings" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.bindings" name="Bindings" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Bindings",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      bindings: null
    };
  },
  async mounted() {
    this.setBindings();

    setInterval(() => {
      this.setBindings()
    }, 250)
  },

  methods: {
    setBindings() {
      this.bindings = this.$store.state.bindings;
    }
  }
};
</script>