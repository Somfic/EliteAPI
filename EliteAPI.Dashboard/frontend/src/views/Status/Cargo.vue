<template>
  <TitleBar title="Cargo" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.cargo" name="Cargo" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Cargo",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      cargo: null
    };
  },
  async mounted() {
    this.setCargo();

    setInterval(() => {
      this.setCargo()
    }, 250)
  },

  methods: {
    setCargo() {
      this.cargo = this.$store.state.cargo;
    }
  }
};
</script>