import { createRouter, createWebHistory } from 'vue-router'
import Operator from '../components/Operator.vue';
import Owner from '../components/Owner.vue';

const routes = [
  { path: '/', redirect: '/Operator' },
  { path: '/Operator', name: 'Operator', component: Operator },
  { path: '/Owner', name: 'Owner', component: Owner }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
