import { SelectItem } from 'primeng/primeng';

export class AttributeDropDown implements SelectItem {
    public label: string;
    public value: any;

    constructor() {
        this.label = '';
        this.value = null;
    }
}