import { ProductOptionModel } from '../../products/productOptionModel';

export class InitialProductOptionPriceRequest {
    public option:ProductOptionModel;
    public initialPrice: number;

    constructor() {
        this.option = null;
        this.initialPrice = 0;
    }
}