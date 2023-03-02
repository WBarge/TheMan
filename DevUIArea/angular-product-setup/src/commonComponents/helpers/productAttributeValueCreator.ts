import { IValueCreator } from '../interfaces/IValueCreator';
import { ProductAttributeValueModel } from '../models/products/productAttributeValueModel';

export class ProductAttributeValueCreator implements IValueCreator{

    public createValueObject(value: string,desc:string): any {
        var returnValue: ProductAttributeValueModel = new ProductAttributeValueModel();
        returnValue.id = '';
        returnValue.valueName = value;
        returnValue.description = desc;
        return returnValue;
    }
}