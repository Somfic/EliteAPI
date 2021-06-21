import {createRouter, createWebHistory} from "vue-router";
const routes = [
  {
    path: "/events",
    name: "EventLog",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/EventLog.vue"),
  },  {
    path: "/logs",
    name: "MessageLog",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/MessageLog.vue"),
  },  {
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
