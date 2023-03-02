import { AttributeModel } from '../../products/attributeModel';
import { ProductModel } from '../../products/productModel';


export class AttributesForProductRequest {
    public product: ProductModel;
    public attributes: AttributeModel[];

    constructor() {
        this.product = new ProductModel();
        this.attributes = new Array<AttributeModel>();
    }
}