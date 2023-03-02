import { SelectItem } from 'primeng/primeng';

import { IPossibleValueModel } from './possibleValueModel';

export class PropertyModel implements IPropertyModel {
    id: string;
    name: string;
    selectedValue: any;
    possibleValues: IPossibleValueModel[];
    enteredValue: string;

    constructor() {
        this.id = '';
        this.name = '';
        this.selectedValue = null;
        this.possibleValues = null;
        this.enteredValue = null;
    }

    public clone(): PropertyModel{
        var returnValue: PropertyModel = new PropertyModel();
        returnValue.id = this.id;
        returnValue.name = this.name;
        if (this.selectedValue != null) {
            returnValue.selectedValue = this.selectedValue.clone();
        }
        else {
            returnValue.selectedValue = null;
        }
        if (this.possibleValues != null) {
            returnValue.possibleValues = new Array<IPossibleValueModel>();
            this.possibleValues.forEach((value: IPossibleValueModel) => {
                returnValue.possibleValues.push(value.clone());
            });
        }
        else {
            returnValue.possibleValues = null;
        }
        returnValue.enteredValue = this.enteredValue;
        return returnValue;
    }

}

export interface IPropertyModel {
    id: string;
    name: string;
    selectedValue: any;
    possibleValues: IPossibleValueModel[];
    enteredValue: string;
    clone(): PropertyModel;
}