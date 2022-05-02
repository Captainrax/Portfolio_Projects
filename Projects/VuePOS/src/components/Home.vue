<template>
  <div class="page">
    <div class="tab">
      <router-link class="tabs" to="/Operator" tag="button"
        >Operator</router-link
      >
      <router-link class="tabs" to="/Owner" tag="button">Owner</router-link>
    </div>
    <router-view class="content"></router-view>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {},
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.page {
  background-color: black;
  height: 100%;
  width: 100%;
}

.tab {
  display: flex;
  flex-direction: row;
}

.tabs {
  width: 50%;
  height: 2em;
  background-color: rgb(191, 191, 191);
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  justify-content: center;
  display: grid;
  -ms-flex-line-pack: center;
  align-content: center;
  text-decoration: none;
  color: inherit;
  border-width: 2px;
  border-color: #a2a6ac #979aa1 #82858a;
  border-style: outset;
}
.tabs:active {
  border-style: inset;
}

.content {
  height: calc(100% - 2.5em);
  background-color: white;
}

/* testing  */

</style>

