//*******************************************************************
//  This is the Price Product item on the product menu
//*******************************************************************

//framework
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

//third party
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';

//services
import { ProductService } from '../../commonComponents/service/product.service';

//models
import { ProductModel } from '../../commonComponents/models/products/productModel';
import { ProductDropDown } from '../models/productDropDown';


@Component({
    selector: 'productPricingView',
    templateUrl: './productPricingView.component.html',
    styleUrls: ['./productPricingView.component.css']
})
export class ProductPricingViewComponent {

    someParam: any;

    showCreateInitialProductPricingDialog: boolean;

    productList: SelectItem[];
    selectedProduct: SelectItem = null;
    validProducts: boolean;

    newPricingInitialPrice:number;


    constructor(private messageService:MessageService,
        private dataService: ProductService,
        private route: ActivatedRoute,
        private router: Router) {
        this.validProducts = false;
    }

    ngOnInit() {
        this.route.params.subscribe((params: Params) => { this.someParam = params['testParameter']; });
        this.loadProductList();
        this.showCreateInitialProductPricingDialog = false;
    }

    //user clicked add pricing button
    //setup to create new predefined product
    public clickAddProductPricing() {
        this.newPricingInitialPrice = 10;
        this.showCreateInitialProductPricingDialog = true;
    }

    //user clicked create pricing on initial price dialog
    //create a new predefined product
    public createNewProductPricingDialogClick() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productToUpload: ProductModel = this.selectedProduct.value;
        this.dataService.createInitialProductPricing(productToUpload, this.newPricingInitialPrice).subscribe(
            () => {
                this.messageService.clear();
                this.loadProductList();
            },
            error => this.handleError(error)
        );
        this.showCreateInitialProductPricingDialog = false;
    }

    private loadProductList() {
        this.productList = new Array<SelectItem>();
        this.dataService.getProductsWithNoPrices()
            .subscribe((products: ProductModel[]) => {
                    this.validProducts = (products.length > 0);
                    products.forEach((product: ProductModel) => {
                        this.selectedProduct = new ProductDropDown();
                        this.selectedProduct.label = product.name;
                        this.selectedProduct.value = product;
                        this.productList.push(this.selectedProduct);
                    });
            },
            error => this.handleError(error));
    }


    private handleError(errorMsg: string) {
        this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
