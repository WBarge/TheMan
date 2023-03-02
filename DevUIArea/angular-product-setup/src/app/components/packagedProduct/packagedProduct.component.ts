//framework
import { Component, OnInit, Input ,Output, EventEmitter } from '@angular/core';

//Third Party
import { MessageService } from 'primeng/api';
import { SelectItem } from 'primeng/api';

//models
import { PackagedProductModel } from '../../../commonComponents/models/products/packagedProductModel';
import { PackagedProductDetailModel } from '../../../commonComponents/models/products/packagedProductDetailModel';
import { PackagedProductOptionModel } from '../../../commonComponents/models/products/packagedProductOptionModel';
import { PackagedProductOptionDetailModel } from '../../../commonComponents/models/products/packagedProductOptionDetailModel';
import { ProductPricingModel } from '../../../commonComponents/models/products/productPricingModel';
import { ProductDropDown } from '../../models/productDropDown';
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';
import { PropertyModel } from '../../../commonComponents/models/propertyBag/propertyModel';
import { AttributeModel } from '../../../commonComponents/models/products/attributeModel';
import { ProductAttributeValueModel } from '../../../commonComponents/models/products/productAttributeValueModel';
import { PossibleValueModel } from '../../../commonComponents/models/propertyBag/possibleValueModel';
import { ProductOptionDropDown } from '../../models/productOptionDropDown';
import { ProductOptionAttributeValueModel } from '../../../commonComponents/models/products/productOptionAttributeValueModel';

//services
import { ProductService } from '../../../commonComponents/service/product.service';
import { ProductOptionService } from '../../../commonComponents/service/productOption.service';
import { AttributeValueModel } from '../../../commonComponents/models/products/attributeValueModel';
import { IPossibleValueModel } from '../../../commonComponents/models/propertyBag/possibleValueModel';


@Component({
    selector: 'packagedProduct',
    templateUrl: './packagedProduct.component.html',
    styleUrls: ['./packagedProduct.component.css']
})
export class PackagedProduct implements OnInit {
    //vars
    @Input()
    set packagedProduct(value: PackagedProductModel) {
        this.incomingPackagedProduct = value;
        this.selectedProduct = null;
        if (this.productList != null) {

            this.productList.forEach((pricedProduct: ProductDropDown) => {
                if (this.incomingPackagedProduct.productId === pricedProduct.value.product.id) {
                    this.selectedProduct = pricedProduct.value;
                }
            });
            //TODO populate the rest of the object models for the controls
        }
    }
    get packagedProduct(): PackagedProductModel {
        return this.incomingPackagedProduct;
    }


    @Input()
    set tabNumber(value: number) {
        this.tabIndex = value;
        this.processTabChange(this.tabIndex);
    }
    get tabNumber(): number {
        return this.tabIndex;
    }

    @Output() tabChanged: EventEmitter<number> = new EventEmitter<number>();


    incomingPackagedProduct: PackagedProductModel;

    //tab control
    tabIndex: number =0;
    oldTabIndex: number=0;

    //consts
    // ReSharper disable InconsistentNaming
    private static readonly PRODUCT_TAB: number = 0;
    private static readonly OPTIONS_TAB: number = 1;
    private static readonly OPTIONS_DETAILS_TAB: number = 2;
    private static readonly PRODUCT_ATTRIBUTES_TAB: number = 3;
    private static readonly OPTIONS_ATTRIBUTES_TAB: number = 4;
    private static readonly PRICE_TAB: number = 5;

    //product tab
    productList: SelectItem[];
    selectedProduct: ProductPricingModel = null;
    validProducts: boolean = false;

    //option tab
    possibleProductOptions: ProductOptionModel[];
    selectedProductOptions: ProductOptionModel[];
    avaiableOptionHeader: string = "Avaiable Options";
    selectedOptionHeader: string = "Selected Options";

    //options Detail
    optionDetailTabProductOptionsList: SelectItem[];
    optionDetailTabSelectedProductOption: ProductOptionModel;//may not need this
    productOptionMarketingLingo: string = "";
    oldProductOption: ProductOptionModel;

    //product attributes
    productAttributes: PropertyModel[];

    //product option attributes
    selectedProductOptionsList: SelectItem[];
    selectedProductOption: ProductOptionModel;//may not need this
    productOptionAttributes: PropertyModel[];
    oldproductOption:ProductOptionModel;


    constructor(private messageService:MessageService, private productService: ProductService, private productOptionService: ProductOptionService) {
    }

    public ngOnInit(): void {
        this.loadProductList();
    }

    private loadProductList() {
        this.possibleProductOptions = new Array<ProductOptionModel>();
        this.selectedProductOptions = new Array<ProductOptionModel>();
        this.productList = new Array<SelectItem>();
        this.productService.getProductsWithPrices()
            .subscribe((products: ProductPricingModel[]) => {
                    this.validProducts = (products.length > 0);
                    products.forEach((pricedProduct: ProductPricingModel) => {
                        var tempProduct: ProductDropDown = new ProductDropDown();
                        tempProduct.label = pricedProduct.product.name;
                        tempProduct.value = pricedProduct;
                        this.productList.push(tempProduct);
                    });
                },
                error => this.handleError(error));
    }

    private loadProductOptions() {
        if (this.selectedProduct != null) {
            this.productOptionService.getOptionsForProduct(this.selectedProduct.product)
                .subscribe((incomingProductOptions: ProductOptionModel[]) => {

                    this.selectedProductOptions = new Array<ProductOptionModel>();
                    this.possibleProductOptions = new Array<ProductOptionModel>();
                    if (this.incomingPackagedProduct.options !== null && this.incomingPackagedProduct.options.length > 0) {
                        incomingProductOptions.forEach((incomingProductOption: ProductOptionModel) => {
                            if (this.optionWasSelected(incomingProductOption)) {
                                this.selectedProductOptions.push(incomingProductOption);
                            }
                            else{
                              this.possibleProductOptions.push(incomingProductOption);
                            }
                        });
                    } else {
                        this.possibleProductOptions = incomingProductOptions;
                    }
                },
                error => this.handleError(error));
        }
    }

    private optionWasSelected(incomingProductOptions: ProductOptionModel): boolean {
        var returnValue: boolean = false;
        if (this.incomingPackagedProduct !== null && this.incomingPackagedProduct.options != null) {
            this.incomingPackagedProduct.options.some((packagedOption: PackagedProductOptionModel) => {
                if (packagedOption.optionId === incomingProductOptions.id) {
                    returnValue = true;
                }
                return returnValue;
            });
        }
        return returnValue;
    }

    private loadProductAttributes() {
        //todo merge the results from the server with the object model for the packaged product
        if (this.selectedProduct != null) {
            this.productAttributes = new Array<PropertyModel>();
            //we may need to change this to be one call to the server to get the attributes and there possible values instead of this loop with multiple calls to the server
            this.productService.getAttributesForProduct(this.selectedProduct.product)
                .subscribe((incomingAttributes: AttributeModel[]) => {
                    incomingAttributes.forEach((attribute: AttributeModel) => {
                        var previouslySelectedDetail: PackagedProductDetailModel = this.getProductAttributeIfPreviouslySeleted(attribute);

                        //set up the attribute for the UI controls
                        var tempPropertyModel: PropertyModel = new PropertyModel();
                        tempPropertyModel.id = attribute.id;
                        tempPropertyModel.name = attribute.name;

                        if (previouslySelectedDetail && previouslySelectedDetail.attributeValueId || null) {
                            tempPropertyModel.enteredValue = previouslySelectedDetail.attributeValue;
                        } else {
                            var tempPackageProductDetail: PackagedProductDetailModel = new PackagedProductDetailModel();
                            tempPackageProductDetail.attribute = attribute;
                            this.incomingPackagedProduct.details.push(tempPackageProductDetail);
                            previouslySelectedDetail = tempPackageProductDetail;
                        }

                        this.productService.getAttributeValuesForProduct(this.selectedProduct.product, attribute)
                            .subscribe((attributeValues: ProductAttributeValueModel[]) => {
                                if (attributeValues.length > 0) {
                                    //the attribute has values so a drop down should be showing and any previously selected value will be
                                    //a value in the drop down if the value matches on the attribute value description
                                    //this is the best that can be done since the selected attribute value is not saved
                                    //it is not saved so the value itself can be deleted by the user
                                    tempPropertyModel.enteredValue = null;
                                    tempPropertyModel.possibleValues = new Array<PossibleValueModel>();
                                    attributeValues.forEach((attributeValue: ProductAttributeValueModel) => {

                                        var tempPossibleValueModel: PossibleValueModel = new PossibleValueModel();
                                        tempPossibleValueModel.id = attributeValue.id;
                                        tempPossibleValueModel.label = attributeValue.description;
                                        tempPossibleValueModel.value = tempPossibleValueModel;
                                        tempPropertyModel.possibleValues.push(tempPossibleValueModel);

                                        if (previouslySelectedDetail !== null && previouslySelectedDetail.attributeValueId === attributeValue.id) {
                                            //the drop down has a previosly selected value and it matches
                                            tempPropertyModel.selectedValue = tempPossibleValueModel;
                                        } else if (attributeValue.isDefault) {
                                            //the drop down has a default value
                                            tempPropertyModel.selectedValue = tempPossibleValueModel;
                                        }
                                    });
                                }
                                this.productAttributes.push(tempPropertyModel);
                            },
                            error => this.handleError(error));
                    });
                },
                error => this.handleError(error));
        }
    }

    private getProductAttributeIfPreviouslySeleted(incomingAttribute: AttributeModel): PackagedProductDetailModel {
        var returnValue: PackagedProductDetailModel = null;
        if (this.incomingPackagedProduct !== null && this.incomingPackagedProduct.details != null) {
            this.incomingPackagedProduct.details.some((detail: PackagedProductDetailModel) => {
                if (detail.attribute.id === incomingAttribute.id) {
                    returnValue = detail;
                }
                return returnValue !== null;
            });
        }
        return returnValue;
    }

    //private getAttributeValueModelFromPackagedProductDetailModel(previouslySelectedDetail: PackagedProductDetailModel,
    //    attributeValue: ProductAttributeValueModel): AttributeValueModel {

    //    var returnValue: AttributeValueModel = null;
    //    if (previouslySelectedDetail.possibleValues != null) {
    //        previouslySelectedDetail.possibleValues.some((attribute: AttributeValueModel) => {
    //            if (attribute.id === attributeValue.id) {
    //                returnValue = attribute;
    //            }
    //            return returnValue !== null;
    //        });
    //    }
    //    return returnValue;
    //}

    public handleTabChange(e: any) {
        this.oldTabIndex = this.tabIndex;
        this.tabIndex = e.index;
        this.tabChanged.emit(this.tabIndex);
    }

    private processTabChange(tabIndex: number) {
      debugger

        //todo set the data from the old tab into the object model for the packaged product
        if (this.selectedProduct != null) {
            switch (this.oldTabIndex) {
                case PackagedProduct.PRODUCT_TAB:
                    if (this.selectedProduct.product.id !== this.incomingPackagedProduct.productId) {
                        //the product has changed
                        this.incomingPackagedProduct.productId = this.selectedProduct.product.id;
                        this.incomingPackagedProduct.details = new Array<PackagedProductDetailModel>();
                        this.incomingPackagedProduct.options = new Array<PackagedProductOptionModel>();
                    }
                    this.loadProductOptions();
                    this.loadProductAttributes();
                    break;
                case PackagedProduct.OPTIONS_TAB:
                    if (this.selectedProductOptions != null) {
                        this.incomingPackagedProduct.options = new Array<PackagedProductOptionModel>();
                        this.selectedProductOptions.forEach((option: ProductOptionModel) => {
                            var tempPackagedProductOption: PackagedProductOptionModel =
                                new PackagedProductOptionModel();
                            tempPackagedProductOption.optionId = option.id;
                            tempPackagedProductOption.details = new Array<PackagedProductOptionDetailModel>();
                            this.incomingPackagedProduct.options.push(tempPackagedProductOption);
                        });
                    }

                    break;
                case PackagedProduct.OPTIONS_DETAILS_TAB:
                    //todo take the currently selected product option and put the marketing lingo into the packaged object model
                    if (this.selectedProductOption != null) {
                        this.saveProductionOptionDetails(this.selectedProductOption);
                    }
                    break;
                case PackagedProduct.PRODUCT_ATTRIBUTES_TAB:
                    this.productAttributes.forEach((productAttribute: PropertyModel) => {
                        this.incomingPackagedProduct.details.some((detail: PackagedProductDetailModel) => {// it short circuits the loop as soon as one of element passes the test function. just like a break on a for look in c# so we stop the update as soon as we find the element we are looking for
                                var returnValue: boolean = false;
                                if (detail.attribute.id === productAttribute.id) {
                                    if (productAttribute.enteredValue != null) {
                                        detail.attributeValue = productAttribute.enteredValue;
                                    } else {
                                        var tempAttributeValue: any = productAttribute.selectedValue;
                                        detail.attributeValueId = tempAttributeValue.id;
                                    }

                                    returnValue = true;
                                }
                                return returnValue;
                            });
                    });
                    break;
                case PackagedProduct.OPTIONS_ATTRIBUTES_TAB:
                    this.updateOptionAttributeSettings(this.selectedProductOption);
                    break;
                case PackagedProduct.PRICE_TAB:
                    break;

            }//end of swith on old tab index
            this.oldTabIndex = tabIndex;
            switch (tabIndex) {
                case PackagedProduct.OPTIONS_DETAILS_TAB:
                  this.productOptionMarketingLingo = "";
                case PackagedProduct.OPTIONS_ATTRIBUTES_TAB:
                    if (this.selectedProduct != null && this.selectedProductOptions != null) {
                        //we hit the option attributes tab so we need to transform the data for the controls on the tab
                        this.productOptionAttributes = null;
                        this.selectedProductOption = null;
                        this.selectedProductOptionsList = null;
                        if (this.selectedProductOptions.length > 0) {
                            this.selectedProductOptionsList = new Array<SelectItem>();
                            this.selectedProductOptions.forEach((productOption: ProductOptionModel) => {
                                var tempProductOption: ProductOptionDropDown = new ProductOptionDropDown();
                                tempProductOption.label = productOption.name;
                                tempProductOption.value = productOption;
                                this.selectedProductOptionsList.push(tempProductOption);
                            });
                        }
                    }
                    break;
                }//end of switch on tab index
        }
    }

    private updateOptionAttributeSettings(productOption:ProductOptionModel){
      if (productOption != null) {
        this.incomingPackagedProduct.options.forEach((option:PackagedProductOptionModel)=>{
          if (productOption.id === option.optionId){
            this.productOptionAttributes.forEach((optionAttribute:PropertyModel)=>{
              option.details.some((detail:PackagedProductOptionDetailModel)=>{// it short circuits the loop as soon as one of element passes the test function. just like a break on a for look in c# so we stop the update as soon as we find the element we are looking for
                var returnValue: boolean = false;
                if (detail.attribute.id === optionAttribute.id) {
                  if (optionAttribute.enteredValue != null) {
                      detail.attributeValue = optionAttribute.enteredValue;
                  } else {
                      var tempAttributeValue: any = optionAttribute.selectedValue;
                      detail.attributeValueId = tempAttributeValue.id;
                  }
                  returnValue = true;
              }
              return returnValue;
              });
            });
          }
        });
      }
    }




    public handleProductOptionDropDownForOptionsDetailsTabChange(event: any) {
        //todo take the currently selected product option and put the marketing lingo into the packaged object model
        var productOption: ProductOptionModel = event.value;

        if (this.oldProductOption != null) {
            this.saveProductionOptionDetails(this.oldProductOption);
        }
        if (productOption != null) {
            this.oldProductOption = productOption;
            this.incomingPackagedProduct.options.some((option: PackagedProductOptionModel) => {
                var returnValue: boolean = false;
                if (option.optionId === productOption.id) {
                    this.productOptionMarketingLingo = option.description;
                    returnValue = true;
                }
                return returnValue;
            });
        }

    }

    private saveProductionOptionDetails(productOption: ProductOptionModel) {
        this.incomingPackagedProduct.options.some((option: PackagedProductOptionModel) => {
            var returnValue: boolean = false;
            if (option.optionId === productOption.id) {
                option.description = this.productOptionMarketingLingo;
                returnValue = true;
            }
            return returnValue;
        });
    }

    public handleProductOptionDropDownForOptionAttributesTabChange(event: any) {
        var productOption: ProductOptionModel = event.value;

        if (productOption != null) {
            if (this.oldproductOption != null && this.oldproductOption.id != productOption.id){
              this.updateOptionAttributeSettings(this.oldProductOption);
            }
            this.oldproductOption = productOption;
            var packagedProductOption: PackagedProductOptionModel;
            this.incomingPackagedProduct.options.some((option:PackagedProductOptionModel)=>{
              if (productOption.id === option.optionId){
                packagedProductOption = option;
                return;
              }
            });

            this.productOptionAttributes = new Array<PropertyModel>();
            //we may need to change this to be one call to the server to get the attributes and there possible values instead of this loop with multiple calls to the server
            this.productOptionService.getAttributesForProductOption(this.selectedProduct.product,productOption)
                .subscribe((incomingAttributes: AttributeModel[]) => {
                    incomingAttributes.forEach((attribute: AttributeModel) => {
                        //make sure we have a place to store the results of the user's settings
                        var packagedProductOptionDetail:PackagedProductOptionDetailModel = null;
                        packagedProductOption.details.some((detail:PackagedProductOptionDetailModel)=>{
                        if (detail.attribute.id === attribute.id)
                          packagedProductOptionDetail = detail;
                          return;
                        });
                        if (packagedProductOptionDetail==null){
                          packagedProductOptionDetail = new PackagedProductOptionDetailModel();
                          packagedProductOptionDetail.attribute = attribute;
                          packagedProductOptionDetail.attributeValue = null;
                          packagedProductOptionDetail.attributeValueId = null;
                          packagedProductOption.details.push(packagedProductOptionDetail);
                        }
                        //set up the settings
                        var tempPropertyModel: PropertyModel = new PropertyModel();
                        tempPropertyModel.id = attribute.id;
                        tempPropertyModel.name = attribute.name;
                        this.productOptionService.getAttributeValuesForProductOption(this.selectedProduct.product,productOption,attribute)
                            .subscribe((attributeValues: ProductOptionAttributeValueModel[]) => {
                                var found:boolean = false;
                                if (attributeValues.length > 0) {
                                    tempPropertyModel.possibleValues = new Array<PossibleValueModel>();
                                    attributeValues.forEach((attributeValue: ProductOptionAttributeValueModel) => {
                                        var tempPossibleValueModel: PossibleValueModel = new PossibleValueModel();
                                        tempPossibleValueModel.id = attributeValue.id;
                                        tempPossibleValueModel.label = attributeValue.description;
                                        tempPossibleValueModel.value = attributeValue;
                                        tempPropertyModel.possibleValues.push(tempPossibleValueModel);
                                        if (tempPropertyModel.selectedValue == null && (attributeValue.isDefault || attributeValue.id === packagedProductOptionDetail.attributeValueId)) {
                                            tempPropertyModel.selectedValue = tempPossibleValueModel;
                                        }
                                    });
                                }else if (packagedProductOptionDetail.attributeValue !== null){
                                  tempPropertyModel.enteredValue = packagedProductOptionDetail.attributeValue;
                                }
                                this.productOptionAttributes.push(tempPropertyModel);
                            },
                            error => this.handleError(error));
                    });
                },
                error => this.handleError(error));
        }
    }


    private handleError(errorMsg: string) {
        this.messageService.clear();
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
