import {AttributeModel} from './attributeModel';
import {AttributeValueModel} from './attributeValueModel';

export class PackagedProductDetailModel {
    public attribute: AttributeModel;
//    public possibleValues: AttributeValueModel[];
    public attributeValue: string;
    public attributeValueId:string;
}