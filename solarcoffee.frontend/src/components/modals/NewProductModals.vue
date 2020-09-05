<template>
    <solar-modal>
     <template v-slot:header>
Add New Product
     </template>
      <template v-slot:body>
          <ul>
              <li>
                  <label for="isTaxable">Is this product taxable?</label>
                  <input type="checkbox" id="isTaxable" v-model="newProduct.isTaxable">
              </li>
          </ul>
     </template>
      <template v-slot:footer>
     </template>
    </solar-modal>
</template>
<script lang="ts">
import {Component,Prop, Vue} from "vue-property-decorator";
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modals/SolarModal.vue";
import {IProduct,IProductInventory} from "@/types/Product";

@Component({
    name:'NewProductModal',
    components:{SolarButton, SolarModal}
})
export default class NewProductModal extends Vue{

    newProduct: IProduct={
        createdOn:new Date(),
        updatedOn:new Date(),
        id:0,
        description:"",
        isTaxable:false,
        name:"",
        price:0
    };
    close(){
        this.$emit("close");
    }

    save(){
        this.$emit("save:product", this.newProduct);
    }
}
</script>
<style scoped>

</style>