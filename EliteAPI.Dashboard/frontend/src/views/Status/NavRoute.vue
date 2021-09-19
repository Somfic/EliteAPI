<template>
  <TitleBar title="Navigational route" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.navRoute" name="NavRoute" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "NavRoute",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      navRoute: null
    };
  },
  async mounted() {
    this.setNavRoute();

    setInterval(() => {
      this.setNavRoute()
    }, 250)
  },

  methods: {
    setNavRoute() {
      this.navRoute = this.$store.state.navRoute;
    }
  }
};
</script>