import { ProductModel } from '../../models/products/productModel';
import { ObjectTyper } from '../../helpers/objectTyper';
import {GenericParser} from '../genericParser';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class ProductModelParser {

    private static baseParser: GenericParser<ProductModel> = new GenericParser<ProductModel>(ProductModel);

    //parse the response from the service into an array of Products
    public static parseResponseInToArray(res: object[]): ProductModel[] {
        var returnValue: ProductModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoProduct(obj: any): ProductModel {
        var returnValue: ProductModel = this.baseParser.parseObjectIntoAttribute(obj);;
        return returnValue;
    }
}
