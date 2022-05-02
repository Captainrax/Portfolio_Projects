<template>
    <div class="content">
        <button class="item" v-for="item in items" v-on:click="itemClicked(item)" v-bind:key="item.Name">
            <Item v-bind:item="item" />
        </button>
    </div>
</template>

<script>
    import Item from './Item.vue';

    export default {
        name: 'Items',
        props: {
            items: Array,
            add: Function
        },
        components: {
            Item
        },
        methods: {
            itemClicked: function (item) {
                this.add(item);
            }
        }
    };
</script>

<style scoped>
    .content {
        height: 100%;
        width: 100%;
        background: rgb(100, 100, 100);
    }

    .item {
        height: 60px;
        width: 150px;
        margin: 2px;
        background: rgb(97,204,115);
    }
</style>