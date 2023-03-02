import { IValueCreator } from '../interfaces/IValueCreator';
import { ProductOptionAttributeValueModel } from '../models/products/productOptionAttributeValueModel';

export class ProductOptionAttributeValueCreator implements IValueCreator {

    public createValueObject(value: string,desc:string): any {
        var returnValue: ProductOptionAttributeValueModel = new ProductOptionAttributeValueModel();
        returnValue.id = '';
        returnValue.valueName = value;
        returnValue.description = desc;
        return returnValue;
    }
}