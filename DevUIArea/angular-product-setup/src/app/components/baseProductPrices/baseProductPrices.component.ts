//framework
import { Component, OnInit } from '@angular/core';

//Third Party
import { MessageService } from 'primeng/api';

//models
import { ProductPricingModel } from '../../../commonComponents/models/products/ProductPricingModel';
import { PriceModel } from '../../../commonComponents/models/products/priceModel';
import { ProductModel } from '../../../commonComponents/models/products/productModel';

//services
import { ProductService } from '../../../commonComponents/service/product.service';

@Component({
    selector: 'baseProductPrices',
    templateUrl: './baseProductPrices.component.html',
    styleUrls: ['./baseProductPrices.component.css']
})
export class BaseProductPricesComponent implements OnInit {
    //vars
    //data from the service
    productData: ProductPricingModel[];

    //create new product pricing dialog
    showNewProductPricingDialog: boolean;

    //edit product pricing dialog
    showEditProductPricingDialog: boolean;

    //shared price model for create and edit dialogs;
    priceDialogObject: PriceModel;
    selectedProductObject: ProductModel;

    constructor(private messageService:MessageService, private dataService: ProductService) {
    }

    public ngOnInit(): void {
        this.showNewProductPricingDialog = false;
        this.loadProducts();
    }

    private loadProducts() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.dataService.getProductsWithPrices().subscribe((dataSet: ProductPricingModel[]) => {
            this.productData = dataSet;
            this.messageService.clear();
        },
            ex => this.handleError(ex));
    }

    public clickNewProductPricing( productPrice: ProductPricingModel) {
        this.selectedProductObject = productPrice.product;
        this.priceDialogObject = new PriceModel();//the constructor will set the dates to today
        this.priceDialogObject.startDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
        this.priceDialogObject.endDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
        this.priceDialogObject.formulaVariables = productPrice.prices[0].formulaVariables; // an initial price had to been already created so there will always be at least one price
        this.showNewProductPricingDialog = true;
    }

    public clickEditProductPricing(product: ProductModel,price: PriceModel) {
        this.selectedProductObject = product;
        this.priceDialogObject = price;
        this.showEditProductPricingDialog = true;
    }

    public createNewProductPriceDialogClick() {
        //lets not let any fluff like time get in the way of the date comparison
        this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
        this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);
        if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
        } else {
            this.dataService.setProductPrice(this.selectedProductObject, this.priceDialogObject).subscribe(
                () => {
                    this.messageService.clear();
                    this.loadProducts();
                    this.showNewProductPricingDialog = false;
                },
                error => this.handleError(error)
            );
        }
    }

    public saveProductPriceDialogClick() {
        //lets not let any fluff like time get in the way of the date comparison
        this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
        this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);
        if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
        } else {
            this.dataService.setProductPrice(this.selectedProductObject, this.priceDialogObject).subscribe(
                () => {
                  this.messageService.clear();
                    this.loadProducts();
                    this.showEditProductPricingDialog = false;
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
