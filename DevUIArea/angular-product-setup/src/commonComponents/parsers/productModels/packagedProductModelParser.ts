import { PackagedProductModel } from "../../models/products/packagedProductModel";
import {PackagedProductDetailModelParser} from './packagedProductDetailModelParser';
import {PackagedProductOptionModelParser} from './packagedProductOptionModelParser';

export class PackagedProductModelParser {
    //parse the response from the service into an array of Products
    public static parseResponseInToArray(res: object[]): PackagedProductModel[] {
        var returnValue: PackagedProductModel[] = new Array<PackagedProductModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: PackagedProductModel = this.parseObjectIntoProduct(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoProduct(obj: any): PackagedProductModel {
        var returnValue: PackagedProductModel = null;
        if (obj != null) {
            returnValue = new PackagedProductModel();
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    switch (prop) {
                    case 'details':
                        returnValue.details = PackagedProductDetailModelParser.parseResponseInToArray(obj[prop]);
                            break;
                    case 'options':
                        returnValue.options = PackagedProductOptionModelParser.parseResponseInToArray(obj[prop]);
                        break;
                    default:
                        returnValue[prop] = obj[prop];
                    }
                }
            }
        }
        return returnValue;
    }

}