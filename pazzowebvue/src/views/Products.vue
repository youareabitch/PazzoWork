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
          <a href="#" @click.prevent="edit(data.item.ProductID)">{{
            data.value
          }}</a>
        </template>

        <template v-slot:cell(command)="data">
          <button
            class="btn btn-danger"
            type="button"
            @click.prevent="deleteData(data.item.ProductID)"
          >
            刪除
          </button>
        </template>
      </b-table>
    </div>
    <ProductsForm
      v-if="pageState === 'form'"
      :id="editId"
      @back="backToIndex"
    />
  </div>
</template>

<script>
import ProductsForm from "@/components/ProductsForm.vue";
import { getProductsAll, deleteProduct } from "../apis/products";

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
        "command",
      ],
      pageState: "index",
      editId: 0,
    };
  },
  mounted() {
    this.loadData();
  },
  methods: {
    loadData() {
      getProductsAll().then((x) => {
        this.datas = x.data;
      });
    },
    add() {
      this.editId = 0;
      this.pageState = "form";
    },
    edit(id) {
      this.editId = id;
      this.pageState = "form";
    },
    backToIndex(isReload = false) {
      if (isReload) {
        this.loadData();
      }
      this.pageState = "index";
    },
    deleteData(delId) {
      deleteProduct({ params: { id: delId } })
        .then((x) => {
          if (x.data) {
            alert("刪除成功");
            this.loadData();
          } else alert(x.statusText);
        })
        .catch((x) => {
          console.log(x);
          alert(x);
        });
    },
  },
};
</script>

<style lang="sass" scoped>

</style>