// ReSharper disable once WrongRequireRelativePath
// ReSharper disable once StringLiteralWrongQuotes
import { AddressPanelModel } from "./addressPanelModel";
import { SelectItem } from 'primeng/primeng';


export class CustomerModel {

    public id: string;
    public firstName: string;
    public lastName: string;
    public customerNumber: string;
    public userName:string;
    public password: string;
    public active: boolean;
    public shippingIsSameAsBilling:boolean;
    public shippingAddress: AddressPanelModel;
    public billingAddress: AddressPanelModel;
    public email: string;
    public phoneNumberTypeValue: SelectItem;
    public phoneNumber:string;

    constructor() {
        this.id = '';
        this.firstName = '';
        this.lastName = '';
        this.customerNumber = '';
        this.userName = '';
        this.password = '';
        this.active = true;
        this.shippingIsSameAsBilling = false;
        this.shippingAddress = new AddressPanelModel();
        this.billingAddress = new AddressPanelModel();
        this.email = '';
        this.phoneNumberTypeValue = null;
        this.phoneNumber = '';
    }
}