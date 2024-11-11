<script lang="ts">
  import { T } from "@threlte/core";
  import { useLoader } from "@threlte/core";
  import { OBJLoader } from "three/addons/loaders/OBJLoader.js";

  const model = useLoader(OBJLoader).load("krait phantom.obj");
</script>

<T.OrthographicCamera
  makeDefault
  position={[20, 20, 100]}
  zoom={10}
  on:create={({ ref }) => {
    ref.lookAt(0, -5, 0);
  }}
/>

<T.DirectionalLight position={[100, 100, 0]} castShadow />

{#if $model}
  <T
    is={$model}
    on:on:create={({ ref }) => {
      ref.scale = 100;
    }}
  />
{/if}
