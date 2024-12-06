<script lang="ts">
  import { T } from "@threlte/core";
  import { useLoader } from "@threlte/core";
  import { BufferGeometry, PointsMaterial } from "three";
  import { OBJLoader } from "three/addons/loaders/OBJLoader.js";

  const geometry = useLoader(OBJLoader).load("krait phantom.obj");

  const particlesGeometry = new BufferGeometry();
  const particlesMaterial = new PointsMaterial({
    color: 0x888888,
    size: 0.1,
  });

  let points = new T.Points(particlesGeometry, particlesMaterial);

  for (let i = 0; i < 1000; i++) {
    const x = (Math.random() - 0.5) * 100;
    const y = (Math.random() - 0.5) * 100;
    const z = (Math.random() - 0.5) * 100;

    particlesGeometry.setFromPoints(x, y, z);
    particlesGeometry.vertices.push(particlesGeometry.position);
  }
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
