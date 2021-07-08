<template>
  <TitleBar title="EliteVA" :to="{name: 'Home'}" />
  <Card><i class="muted">Still in development</i></Card>
</template>

<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";

export default {
  name: "EliteVA",
  components: { Card, TitleBar },
};
</script>