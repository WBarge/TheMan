import { ProductOptionModel } from './productOptionModel';
import { PriceModel } from './priceModel';

export class OptionPricingModel {
    public option: ProductOptionModel;
    public prices: PriceModel[];
}
