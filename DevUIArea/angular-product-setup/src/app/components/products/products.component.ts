//framework
import { Component, OnInit } from '@angular/core';

//Third Party
import {MessageService} from 'primeng/api';

//models
import { ProductModel } from '../../../commonComponents/models/products/productModel';
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';
import { AttributeModel } from '../../../commonComponents/models/products/attributeModel';

//services
import { ProductService } from '../../../commonComponents/service/product.service';
import { ProductOptionService } from '../../../commonComponents/service/productOption.service';
import { AttributeService } from '../../../commonComponents/service/attribute.service';

@Component({
    selector: 'products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
    //vars

    //data for the grid
    productData: ProductModel[];

    //create new product dialog
    showNewProductDialog: boolean;
    newProduct: ProductModel;

    //edit product dialog
    showProductDetailDialog: boolean;
    selectedProduct: ProductModel;

    //configure the product relationships
    showProductSetupDialog: boolean;
    trigerChange:number =0;

    //configure/assoicate options with the product
    showProductOptionsDialog: boolean;
    productOptionsSourceHeading: string = "Available Options";
    productOptionsTargerHeading: string = "Associated Options";
    allProductionOptions: ProductOptionModel[];
    productOptions: ProductOptionModel[];
    possibleProductionOptions: ProductOptionModel[];

    //configure/assoicate attributes with the product
    showProductAttributesDialog: boolean;
    productAttributeSourceHeading: string = "Available Attributes";
    productAttributeTargetHeader: string = "Associated Attributes";
    allAttributes: AttributeModel[];
    attributes: AttributeModel[];
    possibleAttributes: AttributeModel[];

    constructor(private messageService: MessageService,private dataService: ProductService, private prodOptionService: ProductOptionService, private attributeService: AttributeService) {
        this.productData = new Array<ProductModel>();
        this.prodOptionService.getProductOptions().subscribe((options: ProductOptionModel[]) => {
            this.allProductionOptions = options;
        });
        this.attributeService.getAttributes().subscribe((attributes: AttributeModel[]) => {
            this.allAttributes = attributes;
        });
    }

    public ngOnInit(): void {
        this.loadProducts();
    }

    private loadProducts() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.dataService.getProducts().subscribe((dataSet: ProductModel[]) => {
                this.productData = dataSet;
                this.messageService.clear();
            },
            ex => this.handleError(ex));
    }

    public clickNewProductDialog() {
        if (this.newProduct == null)
            this.newProduct = new ProductModel();
        this.showNewProductDialog = true;
    }
    public createNewProductDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productToUpload: ProductModel = this.newProduct;
        this.dataService.setProduct(productToUpload).subscribe(
            () => this.loadProducts(),
            error => this.handleError(error)
        );
        this.showNewProductDialog = false;
    }

    public clickDetailDialog(product:ProductModel) {
        this.selectedProduct = product;
        this.showProductDetailDialog = true;
    }
    public saveProductDetailDialogClick() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productToUpload: ProductModel = this.selectedProduct;
        this.dataService.setProduct(productToUpload).subscribe(
            () => { this.messageService.clear(); },
            error => this.handleError(error)
        );

        this.showProductDetailDialog = false;
    }

    public clickProductSetupDialog(product: ProductModel) {
        // this is a hack so ngOnChanges is fired  in the product setup component
        // and the product has not changed but any product-option relationship has
        this.trigerChange++;
        this.selectedProduct = product;
        this.showProductSetupDialog = true;
    }
    public onHideProductDetails(events: any) {

    }

    public clickSetOptionsDialog(product: ProductModel) {
        this.prodOptionService.getOptionsForProduct(product).subscribe((options: ProductOptionModel[]) => {
            //the stream is a one time hit
            this.selectedProduct = product;
            this.productOptions = options;
            this.possibleProductionOptions = new Array<ProductOptionModel>();
            this.allProductionOptions.forEach((prodOption: ProductOptionModel) => {
                if (this.isProductOptionAssociated(prodOption) == false) {
                    this.possibleProductionOptions.push(prodOption);
                }
            });
            this.showProductOptionsDialog = true;
        });
    }

    private isProductOptionAssociated(option: ProductOptionModel): boolean {
        var returnValue: boolean = false;
        for (var sub = 0; sub < this.productOptions.length; sub++) {
            var associatedOption = this.productOptions[sub];
            if (associatedOption.id == option.id) {
                returnValue = true;
                break;
            }
        }
        return returnValue;
    }
    public clickSaveProductOptions() {
        this.prodOptionService.setProductionOptionsForProduct(this.selectedProduct, this.productOptions ).subscribe(
            () => { this.messageService.clear(); },
            error => this.handleError(error)
        );
        this.showProductOptionsDialog = false;
    }

    public clickSetAttributessDialog(product: ProductModel) {
        this.dataService.getAttributesForProduct(product).subscribe((attributes: AttributeModel[]) => {
            this.selectedProduct = product;
            this.attributes = attributes;
            this.possibleAttributes = new Array<AttributeModel>();
            this.allAttributes.forEach((att: AttributeModel) => {
                if (this.isProductAttributeAssociated(att) == false) {
                    this.possibleAttributes.push(att);
                }
            });
        });
        this.showProductAttributesDialog = true;
    }
    private isProductAttributeAssociated(attribute: AttributeModel): boolean {
        var returnValue: boolean = false;
        for (var sub = 0; sub < this.attributes.length; sub++) {
            var associatedAttribute = this.attributes[sub];
            if (associatedAttribute.id == attribute.id) {
                returnValue = true;
                break;
            }
        }
        return returnValue;
    }
    public clickSaveProductAttributes() {
        this.dataService.setAttributesForProduct(this.selectedProduct, this.attributes).subscribe(
            () => { this.messageService.clear();},
            error => this.handleError(error)
        );
        this.showProductAttributesDialog = false;
    }

    private handleError(errorMsg: string) {
      this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
