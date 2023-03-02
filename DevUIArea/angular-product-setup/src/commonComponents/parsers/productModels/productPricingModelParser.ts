import { ProductPricingModel } from '../../models/products/productPricingModel';

import { ObjectTyper } from '../../helpers/objectTyper';
import { ProductModelParser } from './productModelParser';
import { PriceModelParser } from './priceModelParser';
import { PriceModel } from '../../models/products/priceModel';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class ProductPricingModelParser {
    public static parseResponseInToArray(res: object[]): ProductPricingModel[] {
        let returnValue: ProductPricingModel[] = new Array<ProductPricingModel>();
        if (res != null) {
            const length = res.length;
            for (let sub = 0; sub < length; sub++) {
                let obj: any = res[sub];
                let tempValProductPricingModel: ProductPricingModel = this.parseObjectIntoProductPricing(obj);
                returnValue.push(tempValProductPricingModel);
            }
        }
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an ProductPricing
    public static parseObjectIntoProductPricing(obj: any): ProductPricingModel {
        var returnValue: ProductPricingModel = new ProductPricingModel();
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop) && obj[prop] != null) {
                let objArray:any;
                let length:number;
                var sub: number;
                switch (prop) {
                    case 'product':
                        returnValue.product = ProductModelParser.parseObjectIntoProduct(obj[prop]);
                        break;
                    case 'prices':
                        returnValue.prices = new Array<PriceModel>();
                        objArray = obj[prop];
                        length = objArray.length;
                        for (sub = 0; sub < length; sub++) {
                            let obj: PriceModel = objArray[sub];
                            let tempValPriceModel: PriceModel = PriceModelParser.parseObjectIntoPrice(obj);
                            returnValue.prices.push(tempValPriceModel);
                        }
                        break;
                    case 'formulaVariables':
                        returnValue.formulaVariables = new Array<string>();
                        objArray = obj[prop];
                        length = objArray.length;
                        for (sub = 0; sub < length; sub++) {
                            let tempFormulaVarible: string = objArray[sub];
                            returnValue.formulaVariables.push(tempFormulaVarible);
                        }
                        break;
                default:
                    returnValue[prop] = obj[prop];
                }
            }
        }
        return returnValue;
    }


}