import {PackagedProductDetailModel} from '../../models/products/packagedProductDetailModel';
import {AttributeModelParser} from './attributeModelParser';
import {AttributeValueModelParser} from './attributeValueModelParser';

export class PackagedProductDetailModelParser {
    public static parseResponseInToArray(res: object[]): PackagedProductDetailModel[] {
        var returnValue: PackagedProductDetailModel[] = new Array<PackagedProductDetailModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: PackagedProductDetailModel = this.parseObjectIntoProduct(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoProduct(obj: any): PackagedProductDetailModel {
        var returnValue: PackagedProductDetailModel = null;
        if (obj != null) {
            returnValue = new PackagedProductDetailModel();
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    switch (prop) {
                        case 'attribute':
                            returnValue.attribute = AttributeModelParser.parseObjectIntoAttribute(obj[prop]);
                            break;
                        //case 'possibleValues':
                        //    returnValue.possibleValues = AttributeValueModelParser.parseResponseInToArray(obj[prop]);
                        //    break;
                        default:
                            returnValue[prop] = obj[prop];
                    }
                }
            }
        }
        return returnValue;
    }
}