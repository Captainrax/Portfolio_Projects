import { createApp } from 'vue'
import router from './router'
import App from './App.vue';
import store from "./store";

import { GetItems } from './PouchDB.js'

function getdata() {
    GetItems().then(function (items) {

        store.state.items = items;
    })
};

// css
// import './assets/stylesheets/navigation.css';
// import './assets/stylesheets/home.css';
// import './assets/stylesheets/upgrades.css';

createApp(App).use(store).use(router).use(getdata).mount('#app')