import {PackagedProductOptionDetailModel} from '../../models/products/packagedProductOptionDetailModel';
import {AttributeModelParser} from './attributeModelParser';
import {AttributeModel} from '../../models/products/attributeModel';
import {AttributeValueModelParser} from './attributeValueModelParser';

export class PackagedProductOptionDetailModelParser {
    //parse the response from the service into an array of PackagedProductOptionDetailModel
    public static parseResponseInToArray(res: object[]): PackagedProductOptionDetailModel[] {
        var returnValue: PackagedProductOptionDetailModel[] = new Array<PackagedProductOptionDetailModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: PackagedProductOptionDetailModel = this.parseObjectIntoProduct(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }

    //will parse an object into an PackagedProductOptionDetailModel
    public static parseObjectIntoProduct(obj: any): PackagedProductOptionDetailModel {
        var returnValue: PackagedProductOptionDetailModel = null;
        if (obj != null) {
            returnValue = new PackagedProductOptionDetailModel();
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