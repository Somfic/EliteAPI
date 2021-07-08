<template>
  <TitleBar title="Status" :to="{name: 'Home'}" />
  <Card no-hover>
    <ObjectNode :value="this.status" name="Status" />
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
      status: null
    };
  },
  async mounted() {
    this.setStatus();

    setInterval(() => {
      this.setStatus()
    }, 250)
  },

  methods: {
    setStatus() {
      this.status = this.$store.state.status;
    }
  }
};
</script>