import { ProductModel } from './productModel';
import { PriceModel } from './priceModel';

export class ProductPricingModel {
    public product: ProductModel;
    public prices: PriceModel[];
    public formulaVariables:string[];
}