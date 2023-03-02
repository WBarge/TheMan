//framework
import { Component, OnInit } from '@angular/core';

//Third Party
import {MessageService} from 'primeng/api';

//models
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';

//services
import { ProductOptionService } from '../../../commonComponents/service/productOption.service';


@Component({
    selector: 'productOptions',
    templateUrl: './productOptions.component.html',
    styleUrls: ['./productOptions.component.css']
})
export class ProductOptionsComponent implements OnInit {
    //vars
    //messages to the user

    //data for the grid
    productOptionData: ProductOptionModel[];

    //create new product dialog
    showNewProductOptionDialog: boolean;
    newProductOption: ProductOptionModel;

    //edit product dialog
    showProductOptionDetailDialog: boolean;
    selectedProductOption: ProductOptionModel;

    constructor(private messageService: MessageService,private dataService: ProductOptionService) {
        this.productOptionData = new Array<ProductOptionModel>();
    }

    public ngOnInit(): void {
        this.loadProductOptions();
    }

    private loadProductOptions() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.dataService.getProductOptions().subscribe((dataSet: ProductOptionModel[]) => {
            this.productOptionData = dataSet;
            this.messageService.clear;
            },
            ex => this.handleError(ex));
    }

    public clickNewProductOptionDialog() {
        if (this.newProductOption == null)
            this.newProductOption = new ProductOptionModel();
        this.showNewProductOptionDialog = true;
    }
    public createNewProductOptionDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productOptionToUpload: ProductOptionModel = this.newProductOption;
        this.dataService.setProductOption(productOptionToUpload).subscribe(
            () => this.loadProductOptions(),
            error => this.handleError(error)
        );
        this.showNewProductOptionDialog = false;
    }

    public clickDetailOptionDialog(productOption: ProductOptionModel) {
        this.selectedProductOption = productOption;
        this.showProductOptionDetailDialog = true;
    }
    public saveProductOptionDetailDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productOptionToUpload: ProductOptionModel = this.selectedProductOption;
        this.dataService.setProductOption(productOptionToUpload).subscribe(
            () => { this.messageService.clear(); },
            error => this.handleError(error)
        );

        this.showProductOptionDetailDialog = false;
    }

    private handleError(errorMsg: string) {
      this.messageService.clear();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
