import { PackagedProductDetailModel } from './packagedProductDetailModel';
import { PackagedProductOptionModel } from './packagedProductOptionModel';

export class PackagedProductModel {
    public id: string;
    public productId: string;
    public description:string;
    public price: number;
    public quantity:number;
    public details: PackagedProductDetailModel[];
    public options: PackagedProductOptionModel[];

}
