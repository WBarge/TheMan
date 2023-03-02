import { AttributeModel } from '../../models/products/attributeModel';
import { ObjectTyper } from '../../helpers/objectTyper';
import {GenericParser} from '../genericParser';


//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class AttributeModelParser {

    private static baseParser: GenericParser<AttributeModel> = new GenericParser<AttributeModel>(AttributeModel);

    //parse the response from the service into an array of Attributes
    public static parseResponseInToArray(res: object[]): AttributeModel[] {
        var returnValue: AttributeModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an Attribute
    public  static parseObjectIntoAttribute(obj: any): AttributeModel {
        var returnValue: AttributeModel = this.baseParser.parseObjectIntoAttribute(obj);
        return returnValue;
    }
}