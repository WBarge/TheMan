import { AttributeModel } from '../../products/attributeModel';
import { ProductModel } from '../../products/productModel';
import { ProductOptionModel } from '../../products/productOptionModel';


export class AttributesForProductOptionRequest {
    public product: ProductModel;
    public productOption: ProductOptionModel;
    public attributes: AttributeModel[];

    constructor() {
        this.product = new ProductModel();
        this.productOption = new ProductOptionModel();
        this.attributes = new Array<AttributeModel>();
    }
}