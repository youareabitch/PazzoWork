<template>
  <div class="products">
    <div v-if="pageState === 'index'">
      <p>products</p>

      <div class="row">
        <div class="col d-flex justify-content-end">
          <button class="btn btn-primary" type="button" @click.prevent="add()">
            新增
          </button>
        </div>
      </div>

      <b-table class="mt-2" striped hover :items="datas" :fields="cols">
        <template v-slot:cell(ProductName)="data">
          <!-- `data.value` is the value after formatted by the Formatter -->
          <a href="#" @click.prevent="edit(data.item.ProductID)">{{ data.value }}</a>
        </template>
      </b-table>
    </div>
    <ProductsForm v-if="pageState === 'form'" :id="editId" />
  </div>
</template>

<script>
import axios from "axios";
import ProductsForm from "@/components/ProductsForm.vue";

export default {
  name: "Products",
  components: {
    ProductsForm,
  },
  data() {
    return {
      datas: [],
      cols: [
        "ProductName",
        "QuantityPerUnit",
        "ReorderLevel",
        "UnitPrice",
        "UnitsInStock",
        "UnitsOnOrder",
        "Discontinued",
      ],
      pageState: "index",
      editId: 0,
    };
  },
  mounted() {
    axios.get("http://localhost:14884/api/Products/GetAll").then((x) => {
      this.datas = x.data;
    });
  },
  methods: {
    add() {
      this.editId = 0;
      this.pageState = "form";
    },
    edit(id) {
      this.editId = id;
      this.pageState = "form";
    },
  },
};
</script>

<style lang="sass" scoped>

</style>