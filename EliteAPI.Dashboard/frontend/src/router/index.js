import {createRouter, createWebHistory} from "vue-router";
const routes = [
  {
    path: "/events",
    name: "Events",
    component: () =>
      import(/* webpackChunkName: "events" */ "../views/EventLog.vue"),
  },  {
    path: "/logs",
    name: "Logs",
    component: () =>
      import(/* webpackChunkName: "logs" */ "../views/MessageLog.vue"),
  },  {
    path: "/catchup",
    name: "Catchup",
    component: () =>
      import(/* webpackChunkName: "catchup" */ "../views/Catchup.vue"),
  }, {
    path: "/",
    name: "Home",
    component: () =>
      import(/* webpackChunkName: "home" */ "../views/Home.vue"),
  }, {
    path: "/integrations",
    name: "Plugins",
    component: () =>
        import(/* webpackChunkName: "plugins" */ "../views/Plugins/Home.vue"),
  }, {
    path: "/integrations/eliteva",
    name: "EliteVA",
    component: () =>
      import(/* webpackChunkName: "plugins-eliteva" */ "../views/Plugins/EliteVA/Home.vue"),
  }, {
    path: "/integrations/eliteva/install",
    name: "EliteVA-Install",
    component: () =>
        import(/* webpackChunkName: "plugins-eliteva" */ "../views/Plugins/EliteVA/Install.vue"),
  },{
    path: "/status/status",
    name: "Status",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Status.vue"),
  },{
    path: "/status/cargo",
    name: "Cargo",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Cargo.vue"),
  },{
    path: "/status/modules",
    name: "Modules",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Modules.vue"),
  },{
    path: "/status/market",
    name: "Market",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Market.vue"),
  },{
    path: "/status/outfitting",
    name: "Outfitting",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Outfitting.vue"),
  },{
    path: "/status/shipyard",
    name: "Shipyard",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Shipyard.vue"),
  },{
    path: "/status/navroute",
    name: "NavRoute",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/NavRoute.vue"),
  },{
    path: "/status/bindings",
    name: "Bindings",
    component: () =>
      import(/* webpackChunkName: "status" */ "../views/Status/Bindings.vue"),
  },{
    path: "/status/backpack",
    name: "Backpack",
    component: () =>
        import(/* webpackChunkName: "status" */ "../views/Status/Backpack.vue"),
  },{
    path: "/welcome",
    name: "Welcome",
    component: () =>
        import(/* webpackChunkName: "welcome" */ "../views/Welcome.vue"),
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
