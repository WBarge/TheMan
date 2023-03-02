import { OptionPricingModel } from '../../models/products/optionPricingModel';

import { ProductOptionModelParser } from './productOptionModelParser';
import { PriceModelParser } from './priceModelParser';
import { PriceModel } from '../../models/products/priceModel';

export class OptionPricingModelParser {
    public static parseResponseInToArray(res: object[]): OptionPricingModel[] {
        let returnValue: OptionPricingModel[] = new Array<OptionPricingModel>();
        if (res != null) {
            const length = res.length;
            for (let sub = 0; sub < length; sub++) {
                let obj: any = res[sub];
                let tempValProductPricingModel: OptionPricingModel = OptionPricingModelParser.parseObjectIntoProductOptionPricing(obj);
                returnValue.push(tempValProductPricingModel);
            }
        }
        return returnValue;
    }

    public static parseObjectIntoProductOptionPricing(obj: any): OptionPricingModel {
        var returnValue: OptionPricingModel = new OptionPricingModel();
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop) && obj[prop] != null) {
                let objArray: any;
                let length: number;
                var sub: number;
                switch (prop) {
                    case 'option':
                        returnValue.option = ProductOptionModelParser.parseObjectIntoProductOption(obj[prop]);
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
                // product options currently do not support formulas
                //case 'formulaVariables':
                //    returnValue.formulaVariables = new Array<string>();
                //    objArray = obj[prop];
                //    length = objArray.length;
                //    for (sub = 0; sub < length; sub++) {
                //        let tempFormulaVarible: string = objArray[sub];
                //        returnValue.formulaVariables.push(tempFormulaVarible);
                //    }
                //break;
                default:
                    returnValue[prop] = obj[prop];
                }
            }
        }

        return returnValue;
    }
}