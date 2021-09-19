<template>
  <TitleBar title="Modules" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.modules" name="Modules" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Modules",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      modules: null
    };
  },
  async mounted() {
    this.setModules();

    setInterval(() => {
      this.setModules()
    }, 250)
  },

  methods: {
    setModules() {
      this.modules = this.$store.state.modules;
    }
  }
};
</script>