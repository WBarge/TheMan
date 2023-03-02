import { ProductAttributeValueModel } from '../../models/products/productAttributeValueModel';
import { ObjectTyper } from '../../helpers/objectTyper';
import {GenericParser} from '../genericParser';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes


export class ProductAttributeValueModelParser {

    private static baseParser: GenericParser<ProductAttributeValueModel> = new GenericParser<ProductAttributeValueModel>(ProductAttributeValueModel);

    //parse the response from the service into an array of Attributes
    public static parseResponseInToArray(res: object[]): ProductAttributeValueModel[] {
        var returnValue: ProductAttributeValueModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Attribute
    private static parseObjectIntoAttribute(obj: any): ProductAttributeValueModel {
        var returnValue: ProductAttributeValueModel = this.baseParser.parseObjectIntoAttribute(obj);;
        return returnValue;
    }
}