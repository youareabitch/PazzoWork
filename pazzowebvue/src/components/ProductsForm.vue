<template>
  <div>
    products form

    <div class="row">
      <div class="col d-flex justify-content-end">
        <button class="btn btn-primary" type="button" @click.prevent="save()">
          儲存
        </button>
        <button
          class="btn btn-danger ml-2"
          type="button"
          @click.prevent="back()"
        >
          取消
        </button>
      </div>
    </div>

    <b-form>
      <b-form-group
        label="ProductName:"
        label-for="ProductName"
        description="ProductName"
      >
        <b-form-input
          id="ProductName"
          v-model="formData.ProductName"
          type="text"
          required
          placeholder="ProductName"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="QuantityPerUnit:"
        label-for="QuantityPerUnit"
        description="QuantityPerUnit"
      >
        <b-form-input
          id="QuantityPerUnit"
          v-model="formData.QuantityPerUnit"
          type="text"
          required
          placeholder="QuantityPerUnit"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="UnitPrice:"
        label-for="UnitPrice"
        description="UnitPrice"
      >
        <b-form-input
          id="UnitPrice"
          v-model="formData.UnitPrice"
          type="number"
          required
          placeholder="UnitPrice"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="UnitsInStock:"
        label-for="UnitsInStock"
        description="UnitsInStock"
      >
        <b-form-input
          id="UnitsInStock"
          v-model="formData.UnitsInStock"
          type="number"
          required
          placeholder="UnitsInStock"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="UnitsOnOrder:"
        label-for="UnitsOnOrder"
        description="UnitsOnOrder"
      >
        <b-form-input
          id="UnitsOnOrder"
          v-model="formData.UnitsOnOrder"
          type="number"
          required
          placeholder="UnitsOnOrder"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="ReorderLevel:"
        label-for="ReorderLevel"
        description="ReorderLevel"
      >
        <b-form-input
          id="ReorderLevel"
          v-model="formData.ReorderLevel"
          type="number"
          required
          placeholder="ReorderLevel"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        label="Discontinued:"
        label-for="Discontinued"
        description="Discontinued"
      >
        <b-form-checkbox
          id="Discontinued"
          v-model="formData.Discontinued"
          name="Discontinued"
          :value="true"
          :unchecked-value="false"
        >
          Discontinued
        </b-form-checkbox>
      </b-form-group>
    </b-form>
  </div>
</template>

<script>
import { getProductById, addProduct, editProduct } from "../apis/products";

export default {
  name: "ProductsForm",
  props: {
    id: Number,
  },
  data() {
    return {
      formData: {},
    };
  },
  mounted() {
    if (this.id) {
      getProductById({ params: { id: this.id } }).then((x) => {
        this.formData = x.data;
      });
    } else {
      this.formData = {
        ProductID: 0,
        ProductName: "",
        SupplierID: null,
        CategoryID: null,
        QuantityPerUnit: "",
        UnitPrice: null,
        UnitsInStock: null,
        UnitsOnOrder: null,
        ReorderLevel: null,
        Discontinued: false,
      };
    }
  },
  methods: {
    back(isReload = false) {
      this.$emit("back", isReload);
    },
    save() {
      if (!this.id) {
        addProduct({ params: { bm: this.formData } })
          .then((x) => {
            if (x.data) this.back(true);
            else alert(x.statusText);
          })
          .catch((x) => {
            console.log(x);
            alert(x);
          });
      } else {
        editProduct({ params: { bm: this.formData } })
          .then((x) => {
            if (x.data) this.back(true);
            else alert(x.statusText);
          })
          .catch((x) => {
            console.log(x);
            alert(x);
          });
      }
    },
  },
};
</script>

<style lang="sass" scoped>

</style>