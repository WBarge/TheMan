import { AttributeModel } from '../../products/attributeModel';
import { ProductModel } from '../../products/productModel';
import { ProductOptionModel } from '../../products/productOptionModel';
import { ProductOptionAttributeValueModel } from '../../products/productOptionAttributeValueModel';

export class AttributeValuesForProductOptionRequest {
    public product: ProductModel;
    public productOption: ProductOptionModel;
    public attribute: AttributeModel;
    public attributeValues: ProductOptionAttributeValueModel[];

    constructor() {
        this.product = new ProductModel();
        this.productOption = new ProductOptionModel();
        this.attribute = new AttributeModel();
        this.attributeValues = new Array<ProductOptionAttributeValueModel>();

    }
}