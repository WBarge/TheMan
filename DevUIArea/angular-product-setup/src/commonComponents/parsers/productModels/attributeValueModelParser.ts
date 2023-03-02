import {AttributeValueModel} from '../../models/products/attributeValueModel';
import {GenericParser} from '../genericParser';

export class AttributeValueModelParser {

    private static baseParser: GenericParser<AttributeValueModel> = new GenericParser<AttributeValueModel>(AttributeValueModel);

    //parse the response from the service into an array of Attributes
    public static parseResponseInToArray(res: object[]): AttributeValueModel[] {
        var returnValue: AttributeValueModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Attribute
    public static parseObjectIntoAttribute(obj: any): AttributeValueModel {
        var returnValue: AttributeValueModel = this.baseParser.parseObjectIntoAttribute(obj);
        return returnValue;
    }

}