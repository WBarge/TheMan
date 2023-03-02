import { AddressPanelModel } from '../models/addressPanelModel';
import { ObjectTyper } from '../helpers/objectTyper';
import {GenericParser} from './genericParser';

//This class is a holdover from when http was in angular/http - it is currently in angular/common/http
//The class has been left as a place holder to handle future changes

export class AddressPanelModelParser {

    private static baseParser: GenericParser<AddressPanelModel> = new GenericParser<AddressPanelModel>(AddressPanelModel);
    //parse the response from the service into an array of AddressPanels
    public static parseResponseInToArray(res: object[]): AddressPanelModel[] {
        var returnValue: AddressPanelModel[] = this.baseParser.parseResponseInToArray(res);
        return returnValue;
    }

    //common functionality of all parsing methods - will parse an object into an AddressPanel
    public  static parseObjectIntoAddressPanel(obj: any): AddressPanelModel {
        var returnValue: AddressPanelModel = this.baseParser.parseObjectIntoAttribute(obj);;
        return returnValue;
    }
}