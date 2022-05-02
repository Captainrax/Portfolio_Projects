<template>
    <div class="transaction-page">
        <div id="transactionheadercontainer">
            <table class="table">
                <tr id="tableheader">
                    <th>Name</th>
                    <th>Number of Items</th>
                    <th>Price</th>
                    <th></th>
                </tr>
            </table>
        </div>
        <div id="transactioncontainer">
            <table class="table">
                <tbody class="itemsTable">
                    <tr v-if="items.length" v-for="item in items" v-bind:key="item.item.Name">
                        <td>{{ item.item.name }}</td>
                        <td class="numberOfItems">
                            <button v-on:click="decreaseItem(item)">-</button>
                            <span v-if="!item.editing">{{ item.numberOfItems }}</span>
                            <button v-on:click="increaseItem(item)">+</button>
                            <!--<input v-if="item.editing" v-on:blur="toggleEdit(item)" type="number" step="any" min="1" v-model="item.numberOfItems" />-->
                        </td>
                        <td class="price">{{ (item.numberOfItems * item.item.price).toFixed(2) }}</td>
                        <td><button class="fa fa-times" v-on:click="removeItem(item)">Remove</button></td>
                    </tr>
                    <tr v-if="!items.length">
                        <td style="grid-column: 1/5;">No items have been added.</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="table">
            <tbody class="priceTable">
                <tr>
                    <td class="priceText">Subtotal:</td>
                    <td>{{ subtotal.toFixed(2) }}</td>
                </tr>
                <tr>
                    <td class="priceText">Tax:</td>
                    <td>{{ tax.toFixed(2) }}</td>
                </tr>
                <tr>
                    <td class="priceText">Total:</td>
                    <td>{{ total.toFixed(2) }}</td>
                </tr>
            </tbody>
        </table>
        <div class="actions">
            <button class="confirm" v-on:click="confirm()">Confirm</button>
            <button class="clear" v-on:click="clear()">Clear</button>
        </div>
    </div>
</template>

<script>
    import Item from './Item.vue';

    export default {
        name: 'Transaction',
        props: {
            items: Array,
            edit: Function,
            remove: Function,
            confirm: Function
        },
        components: {
            Item
        },
        computed: {
            subtotal: function () {
                var subtotal = 0;
                this.items.forEach(function (item) {
                    subtotal += (item.item.price * item.numberOfItems);
                });

                return subtotal;
            },
            tax: function () {
                return this.subtotal * 0.065;
            },
            total: function () {
                return this.subtotal + this.tax;
            }
        },
        methods: {
            increaseItem: function (item) {
                item.numberOfItems++;
            },
            decreaseItem: function (item) {
                if (item.numberOfItems > 1) {
                    item.numberOfItems--;
                }
            },
            removeItem: function (item) {
                this.remove(item);
            },
            clear: function () {
                this.items = [];
            }
        }
    };
</script>

<style scoped>
    .transaction-page {
        width: 100%;
        height: 100%;
        display: flex;
        flex-direction: column;
        background-color: rgb(255,255,255);
    }

    table {
        border-collapse: collapse;
        margin-bottom: 0.3rem;
        background-color: rgb(255,255,255);
    }

    thead {
        width: 100%;
    }

    tbody {
        height: 100%;
        width: 100%;
    }

    tr {
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

    table th, .table td {
        width: calc(100% - 1.5em);
        padding: 0.75rem;
        vertical-align: top;
        border-top: 1px solid #dee2e6;
        font-size: 14px;
    }

    .itemsTable {
        height: 40vh;
        display: block;
    }

    #transactionheadercontainer {
        display: grid;
    }

    #transactioncontainer {
        flex: auto;
        display: grid;
        overflow-y: scroll;
        overflow-x: hidden;
    }

    #tableheader {
        display: grid;
        grid-template-columns: 25% 25% 25% 25%;
        grid-auto-flow: column;
    }

    .itemsTable tr {
        display: grid;
        grid-template-columns: 25% 25% 25% 25%;
    }

    .price {
        text-align: right;
    }

    .priceText {
        width: 15%;
    }

    .numberOfItems {
        display: flex;
        flex-direction: row;
        width: 90% !important;
    }

        .numberOfItems span {
            flex: 1;
            margin: 0 10px;
            text-align: right;
        }

    .actions {
        display: flex;
        height: 5vh;
    }

    .confirm {
        flex: auto;
        margin: 3px;
    }

    .clear {
        flex: auto;
        margin: 3px;
    }
</style>