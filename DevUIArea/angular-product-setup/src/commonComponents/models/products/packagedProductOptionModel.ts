import { PackagedProductOptionDetailModel } from './packagedProductOptionDetailModel';

export class PackagedProductOptionModel {
    public id: string;
    public optionId: string;
    public description: string;
    public details: PackagedProductOptionDetailModel[];
}