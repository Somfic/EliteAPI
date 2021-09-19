<template>
  <TitleBar title="Shipyard" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.shipyard" name="Shipyard" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Shipyard",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      shipyard: null
    };
  },
  async mounted() {
    this.setShipyard();

    setInterval(() => {
      this.setShipyard()
    }, 250)
  },

  methods: {
    setShipyard() {
      this.shipyard = this.$store.state.shipyard;
    }
  }
};
</script>