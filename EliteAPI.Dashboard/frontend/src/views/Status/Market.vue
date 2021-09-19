<template>
  <TitleBar title="Market" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.market" name="Market" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Market",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      market: null
    };
  },
  async mounted() {
    this.setMarket();

    setInterval(() => {
      this.setMarket()
    }, 250)
  },

  methods: {
    setMarket() {
      this.market = this.$store.state.market;
    }
  }
};
</script>