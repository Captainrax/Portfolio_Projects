<template>
    <div id="app">
        <Home />
    </div>
</template>

<script>
    import Home from './components/Home.vue';

    export default {
        name: 'app',
        components: {
            Home
        }
    };
</script>

<style>
    html, body {
        margin: 0px;
        height: 100%;
        overflow: hidden;
    }

    #app {
        height: 100%;
    }
</style>

