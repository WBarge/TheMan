import { ProductOptionModel } from '../../products/productOptionModel';
import { ProductModel } from '../../products/productModel';


export class ProductOptionsForProductRequest {
    public product: ProductModel;
    public options: ProductOptionModel[];

    constructor() {
        this.product = new ProductModel();
        this.options = new Array<ProductOptionModel>();
    }
}