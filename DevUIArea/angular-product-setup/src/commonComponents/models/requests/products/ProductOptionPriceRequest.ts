import { ProductOptionModel } from "../../products/productOptionModel";
import { PriceModel } from "../../products/priceModel";
import moment = require('moment');

export class ProductOptionPriceRequest {
    public option: ProductOptionModel;
    public price: PriceModel;

    constructor(prod: ProductOptionModel, pri: PriceModel) {
        this.option = new ProductOptionModel();
        this.option.id = prod.id;
        this.option.name = prod.name;
        this.option.description = prod.description;
        this.price = new PriceModel();
        this.price.id = pri.id;
        this.price.startDateTimeString = moment(pri.startDateTime).toISOString();
        this.price.endDateTimeString = moment(pri.endDateTime).toISOString();
        this.price.flatPrice = pri.flatPrice;
        this.price.formulaPrice = pri.formulaPrice;
    }

    private isDateMax(dat: Date): boolean {
        return (dat.toDateString() === 'Fri Dec 31 9999');
    }
}
