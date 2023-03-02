import { ProductAttributeValueModel } from '../../products/productAttributeValueModel';
import { AttributeModel } from '../../products/attributeModel';
import { ProductModel } from '../../products/productModel';


export class AttributeValuesForProductRequest {
    public product: ProductModel;
    public attribute: AttributeModel;
    public attributeValues: ProductAttributeValueModel[];

    constructor() {
        this.product = new ProductModel();
        this.attribute = new AttributeModel();
        this.attributeValues = new Array<ProductAttributeValueModel>()
    }
}