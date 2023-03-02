//framework
import { Component, OnInit } from '@angular/core';

//Third Party
import { MessageService } from 'primeng/api';

//models
import { OptionPricingModel } from '../../../commonComponents/models/products/optionPricingModel';
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';
import { PriceModel } from '../../../commonComponents/models/products/priceModel';

//services
import { ProductOptionService } from '../../../commonComponents/service/productOption.service';

@Component({
    selector: 'baseOptionPrices',
    templateUrl: './baseOptionPrices.component.html',
    styleUrls: ['./baseOptionPrices.component.css']
})
export class BaseOptionPricesComponent implements OnInit {
    //vars
    //data from the service
    productOptionData: OptionPricingModel[];

    //create new product pricing dialog
    showNewOptionPricingDialog: boolean;

    //edit product pricing dialog
    showEditOptionPricingDialog: boolean;

    //shared price model for create and edit dialogs;
    priceDialogObject: PriceModel;
    selectedOptionObject: ProductOptionModel;

    constructor(private messageService:MessageService, private dataService: ProductOptionService) {
    }

    public ngOnInit(): void {
        this.showNewOptionPricingDialog = false;
        this.loadProductOptions();
    }

    private loadProductOptions() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.dataService.getProductOptionsWithPrices().subscribe((dataSet: OptionPricingModel[]) => {
            this.productOptionData = dataSet;
            this.messageService.clear();
        },
            ex => this.handleError(ex));
    }

    public clickNewProductPricing(optionPricing: OptionPricingModel) {
        this.selectedOptionObject = optionPricing.option;
        this.priceDialogObject = new PriceModel();//the constructor will set the dates to today
        this.priceDialogObject.startDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
        this.priceDialogObject.endDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
        this.priceDialogObject.formulaVariables = optionPricing.prices[0].formulaVariables; // an initial price had to been already created so there will always be at least one price
        this.showNewOptionPricingDialog = true;
    }

    public clickEditProductPricing(product: ProductOptionModel, price: PriceModel) {
        this.selectedOptionObject = product;
        this.priceDialogObject = price;
        this.showEditOptionPricingDialog = true;
    }

    public createNewProductOptionPriceDialogClick() {
        //lets not let any fluff like time get in the way of the date comparison
        this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
        this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);
        if (this.priceDialogObject.startDateTime.getDate() > this.priceDialogObject.endDateTime.getDate()) {
            this.handleError('The start date can not be after the end date!');
        }
        else {
            this.dataService.setProductOptionPrice(this.selectedOptionObject, this.priceDialogObject).subscribe(
                () => {
                    this.messageService.clear();
                    this.loadProductOptions();
                    this.showNewOptionPricingDialog = false;
                },
                error => this.handleError(error)
                );
        }
    }

    public saveProductOptionPriceDialogClick() {
        //lets not let any fluff like time get in the way of the date comparison
        this.priceDialogObject.startDateTime.setHours(0,0,0,0);
        this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);
        if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
        } else {
            this.dataService.setProductOptionPrice(this.selectedOptionObject, this.priceDialogObject).subscribe(
                () => {
                    this.messageService.clear();
                    this.loadProductOptions();
                    this.showEditOptionPricingDialog = false;
                },
                error => this.handleError(error)
            );
        }
    }

    private handleError(errorMsg: string) {
        this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
