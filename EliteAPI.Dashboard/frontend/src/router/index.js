import {createRouter, createWebHistory} from "vue-router";
const routes = [
  {
    path: "/events",
    name: "Events",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/EventLog.vue"),
  },  {
    path: "/logs",
    name: "Logs",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/MessageLog.vue"),
  },  {
    path: "/catchup",
    name: "Catchup",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/Catchup.vue"),
  }, {
    path: "/",
    name: "Home",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/Home.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
