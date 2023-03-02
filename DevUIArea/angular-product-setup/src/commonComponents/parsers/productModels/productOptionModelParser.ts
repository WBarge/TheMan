import { ProductOptionModel } from '../../models/products/productOptionModel';
import { ObjectTyper } from '../../helpers/objectTyper';
import {GenericParser} from '../genericParser';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class ProductOptionModelParser {

    private static baseParser: GenericParser<ProductOptionModel> = new GenericParser<ProductOptionModel>(ProductOptionModel);

    //parse the response from the service into an array of Products
    public static parseResponseInToArray(res: object[]): ProductOptionModel[] {
        var returnValue: ProductOptionModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoProductOption(obj: any): ProductOptionModel {
        var returnValue: ProductOptionModel = this.baseParser.parseObjectIntoAttribute(obj);
        return returnValue;
    }
}