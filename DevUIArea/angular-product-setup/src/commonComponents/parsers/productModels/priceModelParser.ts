import { PriceModel } from '../../models/products/priceModel';
import { ObjectTyper } from '../../helpers/objectTyper';
import moment = require('moment');

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes


export class PriceModelParser {
    public static parseResponseInToArray(res: object[]): PriceModel[] {
        var returnValue: PriceModel[] = new Array<PriceModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: PriceModel = PriceModelParser.parseObjectIntoPrice(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Product
    public static parseObjectIntoPrice(obj: any): PriceModel {
        var returnValue: PriceModel = null;
        if (obj != null) {
            returnValue = new PriceModel();
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    switch (prop) {
                        case "endDateTimeString":
                            returnValue.endDateTime = moment(obj[prop]).toDate(); //moment will convert from utc to local time
                            returnValue[prop] = obj[prop];
                            break;
                        case "startDateTimeString":
                            returnValue.startDateTime = moment(obj[prop]).toDate(); //moment will convert from utc to local time
                            returnValue[prop] = obj[prop];
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