<template>
  <TitleBar title="Outfitting" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.outfitting" name="Outfitting" />
  </Card>
  <Card><i class="muted">Still in development, this is a temporary view</i></Card>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";
import ObjectNode from "@/components/ObjectViewer/ObjectNode";

export default {
  name: "Outfitting",
  components: { ObjectNode, Card, TitleBar },
  data() {
    return {
      outfitting: null
    };
  },
  async mounted() {
    this.setOutfitting();

    setInterval(() => {
      this.setOutfitting()
    }, 250)
  },

  methods: {
    setOutfitting() {
      this.outfitting = this.$store.state.outfitting;
    }
  }
};
</script>