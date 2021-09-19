<template>
  <TitleBar title="Backpack" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.backpack" name="Backpack" />
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
      backpack: null
    };
  },
  async mounted() {
    this.setBackpack();

    setInterval(() => {
      this.setBackpack()
    }, 250)
  },

  methods: {
    setBackpack() {
      this.backpack = this.$store.state.backpack;
    }
  }
};
</script>