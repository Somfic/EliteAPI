<template>
  <router-link :to="{name: 'MessageLog'}">EliteAPI logs</router-link>
  <router-link :to="{name: 'EventLog'}">Event logs</router-link>
</template>
<script>
export default {
  name: 'Home'
}
</script>