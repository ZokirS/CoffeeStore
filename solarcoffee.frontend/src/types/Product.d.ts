export interface IProduct{
    id:number;
    createdOn:Date;
    updatedOn:Date;
    name:string;
    description:string;
    price:number;
    isTaxable:boolean;
    isArchived:boolean;
}

export interface IProductInventory{
    id:number;
    product: IPoduct;
    quantityOnHand:number;
    idealQuantity:number;
}