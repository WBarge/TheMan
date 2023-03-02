import {PackagedProductOptionModel} from '../../models/products/packagedProductOptionModel';
import {PackagedProductOptionDetailModelParser} from './packagedProductOptionDetailModelParser';

export class PackagedProductOptionModelParser {
    //parse the response from the service into an array of Products
    public static parseResponseInToArray(res: object[]): PackagedProductOptionModel[] {
        var returnValue: PackagedProductOptionModel[] = new Array<PackagedProductOptionModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: PackagedProductOptionModel = this.parseObjectIntoProduct(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoProduct(obj: any): PackagedProductOptionModel {
        var returnValue: PackagedProductOptionModel = null;
        if (obj != null) {
            returnValue = new PackagedProductOptionModel();
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    switch (prop) {
                        case 'details':
                            returnValue.details = PackagedProductOptionDetailModelParser.parseResponseInToArray(obj[prop]);
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