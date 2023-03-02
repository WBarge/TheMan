//*******************************************************************
//  This is the Price Option item on the product menu
//*******************************************************************

//framework
import { Component, OnInit } from '@angular/core';
//import { map } from 'rxjs/operators';
//import { Observable } from 'rxjs';
import { Router, ActivatedRoute, Params } from '@angular/router';

//third party
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';

//services
import { ProductOptionService } from '../../commonComponents/service/productOption.service';

//models
import { ProductOptionModel } from '../../commonComponents/models/products/productOptionModel';
import { ProductOptionDropDown } from '../models/productOptionDropDown';


@Component({
    selector: 'optionPricingView',
    templateUrl: './optionPricingView.component.html',
    styleUrls: ['./optionPricingView.component.css']
})
export class OptionPricingViewComponent {

    showCreateInitialProductOptionPricingDialog: boolean;

    productOptionList: SelectItem[];
    selectedProductOption: SelectItem = null;
    validProductOptions: boolean;

    newPricingInitialPrice: number;


    constructor(private messageService:MessageService,
        private dataService: ProductOptionService,
        private route: ActivatedRoute,
        private router: Router) {
        this.validProductOptions = false;
    }

    ngOnInit() {
        this.loadProductOptionList();
    }

    //user clicked add pricing button
    //setup to create new predefined product
    public clickAddProductPricing() {
        this.newPricingInitialPrice = 10;
        this.showCreateInitialProductOptionPricingDialog = true;
    }

    //user clicked create pricing
    //create a new predefined product
    public createNewProductPricingDialogClick() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productOption: ProductOptionModel = this.selectedProductOption.value;
        this.dataService.createInitialProductPricing(productOption, this.newPricingInitialPrice).subscribe(
            () => {
                this.messageService.clear();
                this.loadProductOptionList();
            },
            error => this.handleError(error)
        );
        this.showCreateInitialProductOptionPricingDialog = false;
    }

    private loadProductOptionList() {
        this.productOptionList = new Array<SelectItem>();
        this.dataService.getProductOptionsWithNoPrices()
            .subscribe((options: ProductOptionModel[]) => {
                this.validProductOptions = (options.length > 0);
                options.forEach((productOption: ProductOptionModel) => {
                    this.selectedProductOption = new ProductOptionDropDown();
                    this.selectedProductOption.label = productOption.name;
                    this.selectedProductOption.value = productOption;
                    this.productOptionList.push(this.selectedProductOption);
                });
            },
            error => this.handleError(error));
    }


    private handleError(errorMsg: string) {
      this.messageService.clear();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
