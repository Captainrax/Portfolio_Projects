<template>
    <div>
        <div class="text">
            <strong>{{ item.name }}</strong>
        </div>
        <div class="text">
            {{ item.price }},-
        </div>
        <div class="text">
            {{ item.description }}
        </div>
    </div>
</template>

<script>
    var item;

    export default {
        name: 'Item',
        props: {
            item
        }
    }
</script>

<style scoped>
    .text {
        display: inline-grid;
        height: 100%;
        width: 100%;
    }
</style>