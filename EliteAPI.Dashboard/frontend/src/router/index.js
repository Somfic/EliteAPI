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
    path: "/eliteva",
    name: "EliteVA",
    component: () =>
      import(/* webpackChunkName: "eliteva" */ "../views/EliteVA.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
