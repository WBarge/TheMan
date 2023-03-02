import { ProductModel } from '../../products/productModel';

export class InitialProductPriceRequest {
    public product: ProductModel;
    public initialPrice: number;

    constructor() {
        this.product = null;
        this.initialPrice = 0;
    }
}