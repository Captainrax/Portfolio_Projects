// was upgraded from a Vue2 project, still using old code

// import Vue from "vue"
// import Vuex from "vuex"
import { createStore } from 'vuex'
import { GetItems } from './PouchDB.js'

const store = createStore({
  created: function () {
    var items = GetItems();
    Vue.set('items', items);
  },
  state: {
    items: [
      {
        "name": "Apple",
        "price": 2.40,
        "description": "It's a bloody apple"
      },
      {
        "name": "Orange",
        "price": 3.00,
        "description": "Nice and orange"
      },
      {
        "name": "Banana",
        "price": 2.00,
        "description": "Yea, you only get one"
      },
      {
        "name": "PineApple",
        "price": 5.00,
        "description": "Pine and Apple"
      }
    ],
    transactionHistory: [
    ]
  },
  getters: {

  },
  mutations: {
    ADD_ITEM: (state, item) => {
      state.items.push(item);
    },
    REMOVE_ITEM: (state, item) => {
      state.items.splice(item, 1);
    },
    ADD_TRANSACTION_ITEM: (state, item) => {
      state.transactionHistory.push(item);
    },
    SAVE_ITEMS: (state, items) => {
      Vue.set(state, 'items', items);
    }
  },
  actions: {
    addItem: (context, item) => {
      context.commit("ADD_ITEM", item);
    },
    removeItem: (context, item) => {
      context.commit("REMOVE_ITEM", item);
    },
    addTransactionItem: (context, item) => {
      context.commit("ADD_TRANSACTION_ITEM", item);
    },
    saveItems: (context, items) => {
      context.commit('SAVE_ITEMS', items);
    }
  }
});

export default store;