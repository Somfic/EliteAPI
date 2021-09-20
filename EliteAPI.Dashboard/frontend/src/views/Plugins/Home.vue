<template>
  <TitleBar title="Integrations" :to="{name: 'Home'}"/>
  <div class="select">
    <h2>Please select your EliteAPI platform</h2>
    <div class="links">
      <div class="link-wrapper">
        <Card class="link" :to="{name: 'EliteVA'}">
          <h1>VoiceAttack</h1>
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link disabled">
          <h1>VoiceMacro</h1>
        </Card>
      </div>
      <div class="link-wrapper">
        <Card class="link disabled">
          <h1>More coming soon</h1>
        </Card>
      </div>
    </div>
  </div>
</template>
<script>
import TitleBar from "@/components/TitleBar";
import Card from "@/components/Cards/Card";

export default {
  name: "Plugins",
  components: {Card, TitleBar},
};
</script>
<style lang="scss" scoped>
.links {
  grid-template-columns: repeat(3, 1fr);
  margin-bottom: 2rem;
}

.select {
  display: flex;
  flex-grow: 1;
  flex-direction: column;
  align-items: center;
  justify-content: center;

  h2 {
    margin-bottom: 1rem;
  }
}
</style>