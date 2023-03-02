//framework
import { Component, OnInit, Input } from '@angular/core';

//Third Party
import { MessageService } from 'primeng/api';
import { SelectItem } from 'primeng/api';

//models
import { CustomerModel } from '../../../commonComponents/models/customerModel';

//services
//import { ServiceLocatorService } from '../../../commonComponents/service/serviceLocator.service';
import { CustomerService } from '../../../commonComponents/service/customer.service';



@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

    @Input('CustomerData') data: CustomerModel;

    phoneNumberTypeList: SelectItem[];

    protected shippingAddressPanelHeading: string = 'Shipping';
    protected billingAddressPanelHeading: string = 'Billing';

    constructor(private messageService:MessageService,private dataService: CustomerService) {
    }

    public ngOnInit() {
        if (this.data === null)
        {
            this.data = new CustomerModel();
        }
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Number Types' });
        this.buildPhoneNumberTypeList();
    }

    private buildPhoneNumberTypeList() {
        this.dataService.getPhoneNumberTypes().subscribe((result: SelectItem[]) => {
            this.phoneNumberTypeList = result;
            this.messageService.clear();
        }, ex => this.handleError(ex));
    }

    //TODO ADDRESS ERROR HANDLING
    private handleError(errorMsg: string) {
        this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }


}
