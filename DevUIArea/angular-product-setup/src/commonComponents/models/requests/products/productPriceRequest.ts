import { ProductModel } from '../../products/productModel';
import { PriceModel } from '../../products/priceModel';
import moment = require('moment');

export class ProductPriceRequest {

    public product: ProductModel;
    public price: PriceModel;


    constructor(prod: ProductModel,pri:PriceModel) {
        this.product = new ProductModel();
        this.product.id = prod.id;
        this.product.name = prod.name;
        this.product.description = prod.description;
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