import { SelectItem } from 'primeng/primeng';

export class AddressPanelModel {
    public id:string;
    public address1: string;
    public address2: string;
    public city: string;
    public stateValue: SelectItem;
    public zip: string;

    constructor() {
        this.id = '';
        this.address1 = '';
        this.address2 = '';
        this.city = '';
        this.stateValue = null;
        this.zip = '';
    }
}