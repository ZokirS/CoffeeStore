export interface IInventoryTimeLine{
    productInventorySnapshots: ISnapshot[];
    timeline: Date[];
}

export interface ISnapshot{
    productId:number;
    quantityOnHand: number[];
}