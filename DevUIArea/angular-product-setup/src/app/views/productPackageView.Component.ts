//*******************************************************************
//  This is the Package Product item on the Product Menu
//*******************************************************************
//framework
import { Component, OnInit } from '@angular/core';

//third party
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';

//services
import { ProductService } from '../../commonComponents/service/product.service';

//models
import { ProductModel } from '../../commonComponents/models/products/productModel';
import { ProductDropDown } from '../models/productDropDown';
import { ProductPricingModel } from '../../commonComponents/models/products/productPricingModel';
import {PackagedProductModel} from '../../commonComponents/models/products/packagedProductModel';


@Component({
    selector: 'productPackageView',
    templateUrl: './productPackageView.component.html',
    styleUrls: ['./productPackageView.component.css']
})
export class ProductPackageViewComponent {

    packagedProducts: PackagedProductModel[];
    selectedPackagedProduct: PackagedProductModel;
    currentTab: number;

    showPackageEditor:boolean;

    constructor(private messageService:MessageService, private dataService: ProductService) {
    }

    ngOnInit() {
        this.loadPackagedProducts();

        this.showPackageEditor = false;
    }

    //user clicked Create Product Package
    public clickCreatePackageProduct() {
        this.selectedPackagedProduct = new PackagedProductModel();
        this.setEditorTabsToFirstTab();
        this.showPackageEditor = true;
    }

    //user clicked the edit button in the grid
    public clickEditPackagedProductDialog(packagedProduct: PackagedProductModel) {
        this.selectedPackagedProduct = packagedProduct;
        this.setEditorTabsToFirstTab();
        this.showPackageEditor = true;
    }

    public clickNext() {
        this.currentTab = (this.currentTab === 5) ? 5 : this.currentTab + 1;
    }
    public clickPrev() {
        this.currentTab = (this.currentTab === 0) ? 0 : this.currentTab - 1;
    }
    public clickCancel() {
        this.showPackageEditor = false;
    }
    public tabChanged(event: any) {
        this.currentTab = event;
    }
    private setEditorTabsToFirstTab() {
        this.currentTab = 0;
    }

    private loadPackagedProducts() {
        this.dataService.getPackagedProducts()
            .subscribe( (packagedProducts: PackagedProductModel[]) => {
                 this.packagedProducts = packagedProducts;
            },
                error => this.handleError(error)
            );
    }


    private handleError(errorMsg: string) {
        this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }
}
