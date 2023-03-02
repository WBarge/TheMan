import { SelectItem } from 'primeng/primeng';


export class PossibleValueModel implements IPossibleValueModel {
    id: string;
    label: string;
    value: any;

    constructor() {
        this.id = '';
        this.label = '';
        this.value = null;
    }

    public clone(): PossibleValueModel {
        var returnValue: PossibleValueModel = new PossibleValueModel();
        returnValue.id = this.id;
        returnValue.label = this.label;
        returnValue.value = this.value;
        return returnValue;
    }
}

export interface IPossibleValueModel extends SelectItem{
    id: string;
    label: string;
    value: any;
    clone(): PossibleValueModel;
}