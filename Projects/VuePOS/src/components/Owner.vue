<template>
    <div class="owner-page">
        <div class="column">
            <div class="donttouchme">Create new shelf item: </div>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input v-model="input1" placeholder="name">
                        </td>
                        <td>
                            <input v-model="input2" placeholder="price">
                        </td>
                        <td>
                            <input v-model="input3" placeholder="description">
                        </td>
                        <td>
                            <button v-on:click="addNewItem">create</button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="tablecontainer">
                <table class="editTable">
                    <tbody>
                        <tr class="item" v-for="item in items" v-bind:key="item.string">
                            <td>Name:</td>
                            <td>
                                <input type="text" v-model="item.name">
                            </td>
                            <td>Price:</td>
                            <td id="tdprice">
                                <input class="tdprice" type="text" v-model="item.price">
                            </td>
                            <td>Description:</td>
                            <td>
                                <input type="text" v-model="item.description">
                            </td>
                            <td>
                                <button v-on:click="saveItem">Save</button>
                            </td>
                            <td>
                                <button v-on:click="removeItems(item)">Remove</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="column">
            <div class="donttouchme">Transaction History:</div>
            <div id="tablecontainer">
                <table class="historyTable">
                    <tbody>
                        <tr v-for="history in transactionHistory" v-bind:key="history.string">
                            <td>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Price</th>
                                            <th>Amount of items</th>
                                            <th>Total Price</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="item in history" v-bind:key="item.string">
                                            <td>
                                                {{item.item.name }}
                                            </td>
                                            <td>
                                                {{ item.item.price }}
                                            </td>
                                            <td>
                                                {{ item.numberOfItems }}
                                            </td>
                                            <td>
                                                {{ total(item).toFixed(2) }}
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState, mapActions } from "vuex";

    import Item from './Item.vue';
    import Items from './Items.vue';

    import { SaveItems } from '../PouchDB.js'

    export default {
        name: 'Owner',
        components: {
            Item,
            Items
        },
        computed: {
            ...mapState(
                [
                    "items",
                    "transactionHistory"
                ]
            )
        },
        data() {
            return {
                input1: "",
                input2: "",
                input3: ""
            }
        },
        methods: {
            ...mapActions([
                "addItem",
                "removeItem",
                "saveItems"
            ]),
            total: function (item) {
                var subtotal = (item.item.price * item.numberOfItems) * 1.065;
                return subtotal;
            },
            addNewItem: function () {
                let item = {
                    description: this.input3,
                    name: this.input1,
                    price: this.input2
                }
                this.addItem(item)
                SaveItems(this.items);
            },
            saveItem: function () {
                this.saveItems(this.items);
                SaveItems(this.items);
            },
            removeItems: function (item) {
                for (var idx in this.items) {
                    if (this.items[idx] === item) {
                        this.removeItem(idx)
                        SaveItems(this.items);
                        return;
                    }
                }
            },
        }
    }
</script>

<style scoped>
    .owner-page {
        display: flex;
    }

    .column {
        display: flex;
        flex-direction: column;
        flex: 1;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-bottom: 1rem;
        background-color: rgb(255,255,255);
    }

    .historyTable {
        height: 100%;
    }

    thead {
        width: 100%;
    }

    tbody {
        height: 100%;
        width: 100%;
    }

    tr {
        display: inline-flex;
        vertical-align: inherit;
        border-color: inherit;
        width: 100%;
    }

    td {
        display: table-cell;
        vertical-align: inherit;
    }

    thead tr {
        display: grid;
        grid-template-columns: 25% 25% 25% 25%;
        grid-auto-flow: column;
    }

    table th, table td {
        width: calc(100% - 1.5em);
        padding: 0.25rem;
        vertical-align: top;
        border-top: 1px solid #dee2e6;
        font-size: 14px;
    }

    #tablecontainer {
        height: 100%;
        overflow-y: scroll;
    }

    .tdprice {
        width: 4vw;
    }
</style>