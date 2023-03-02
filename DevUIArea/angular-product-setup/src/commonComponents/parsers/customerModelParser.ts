import { CustomerModel } from '../models/customerModel';
import { AddressPanelModelParser } from './addressPanelModelParser';
import { ObjectTyper } from '../helpers/objectTyper';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class CustomerModelParser {

    //parse the response from the service into an array of Customers
    public static parseResponseInToArray(res: object[]): CustomerModel[] {
        var returnValue: CustomerModel[] = new Array<CustomerModel>();
        if (res != null) {
            var length = res.length;
            for (var sub = 0; sub < length; sub++) {
                var obj = res[sub];
                var tempValPropertyModel: CustomerModel = this.parseObjectIntoCustomer(obj);
                returnValue.push(tempValPropertyModel);
            }
        }
        return returnValue;
    }
    //common functionality of all parsing methods - will parse an object into an Customer
    private static parseObjectIntoCustomer(obj: any): CustomerModel {
        var returnValue: CustomerModel = null;
        if (obj != null) {
            returnValue = new CustomerModel(); //this is not a model for the phoneNumberTypeValue yet
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    switch (prop) {
                        case "billingAddress":
                        case "shippingAddress":
                            returnValue[prop] = AddressPanelModelParser.parseObjectIntoAddressPanel(obj[prop]);
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