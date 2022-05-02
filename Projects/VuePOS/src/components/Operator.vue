<template>
    <div class="operator-page">
        <div class="column">
            <Items v-bind:items="items" v-bind:add="onItemClick" />
        </div>
        <div class="column">
            <Transaction v-bind:items="transactionItems" v-bind:edit="toggleEdit" v-bind:remove="removeItem" v-bind:confirm="confirm" />
        </div>
    </div>
</template>

<script>
    import { mapState, mapActions } from 'vuex'

    import Items from './Items.vue';
    import Transaction from './Transaction.vue';

    export default {
        name: 'Operator',
        components: {
            Items,
            Transaction
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
                transactionItems: []
            }
        },
        methods: {
            ...mapActions([
                'addTransactionItem'
            ]),
            onItemClick: function (item) {
                var found = false;
                for (var i = 0; i < this.transactionItems.length; i++) {
                    if (this.transactionItems[i].item === item) {
                        this.transactionItems[i].numberOfItems++;
                        found = true;
                        break;
                    }
                }

                if (!found) {
                    this.transactionItems.push({ item: item, numberOfItems: 1, editing: false });
                }
            },
            toggleEdit: function (item) {
                item.editing = !item.editing;
            },
            removeItem: function (item) {
                for (var i = 0; i < this.transactionItems.length; i++) {
                    if (this.transactionItems[i] === item) {
                        this.transactionItems.splice(i, 1);
                        break;
                    }
                }
            },
            confirm: function () {
                this.addTransactionItem(this.transactionItems);
                this.transactionItems = [];
            }
        }
    }
</script>

<style scoped>
    .operator-page {
        display: flex;
        flex-wrap: wrap;
    }

    .column {
        display: flex;
        flex-direction: column;
        flex: 1;
    }
</style>