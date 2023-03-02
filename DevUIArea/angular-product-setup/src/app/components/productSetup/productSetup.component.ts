//framework
import { Component, OnChanges,SimpleChanges, Input } from '@angular/core';

//Third Party
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { FieldsetModule } from 'primeng/fieldset';

//models
import { ProductModel } from '../../../commonComponents/models/products/productModel';
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';
import { AttributeModel } from '../../../commonComponents/models/products/attributeModel';
import { ProductOptionDropDown } from '../../models/productOptionDropDown';
import { AttributeDropDown } from '../../models/attributeDropDown';
import { ProductAttributeValueModel } from '../../../commonComponents/models/products/productAttributeValueModel';
import { IValueCreator } from '../../../commonComponents/interfaces/IValueCreator';
import { ProductOptionAttributeValueModel } from '../../../commonComponents/models/products/productOptionAttributeValueModel';

//services
import { ProductService } from '../../../commonComponents/service/product.service';
import { ProductOptionService } from '../../../commonComponents/service/productOption.service';
import { AttributeService } from '../../../commonComponents/service/attribute.service';

//utilities
import { ProductModelParser } from '../../../commonComponents/parsers/productModels/productModelParser';
import { ProductAttributeValueCreator } from '../../../commonComponents/helpers/productAttributeValueCreator';
import { ProductOptionAttributeValueCreator } from '../../../commonComponents/helpers/productOptionAttributeValueCreator';

@Component({
    selector: 'productSetup',
    templateUrl: './productSetup.component.html',
    styleUrls: ['./productSetup.component.css']
})
export class ProductSetupComponent implements OnChanges {

    @Input('ProductData') product: ProductModel;
    // this is a hack so ngOnChanges is fired when this control is used in a dialog
    // and the product has not changed but any product-option relationship has
    @Input('ChangeTrigger') changeIt: number;
    //vars



    //option drop-down and opt in  button
    productOptionList: SelectItem[];
    selectedProductOption: any = null;
    productOptionAttributeSourceHeading: string = "Available Attributes";
    productOptionAttributeTargetHeader: string = "Associated Attributes";
    allAttributes: AttributeModel[];
    attributes: AttributeModel[];
    possibleAttributes: AttributeModel[];
    validProductOption: boolean = false;

    //product attribute values
    showPrductAttributeValues:boolean;
    productAttributeList: SelectItem[];
    selectedProductAttribute: any = null;
    productAttributeValueCreater: IValueCreator;
    productAttributeValues: SelectItem[];
    disableProductAttributeValue: boolean;
    defaultProductAttributeValue: ProductAttributeValueModel = null;

    //product option atttribute values
    showPrductOptionAttributeValues:boolean;
    productOptionForAttributeValueList: SelectItem[];
    selectedProductOptionForAttributeValue: any = null;
    showDetail: boolean;
    productOptionAttributeList: SelectItem[];
    selectedProductOptionAttribute: any = null;
    productOptionAttributeValues: SelectItem[];
    disableProductOptionAttributeValue: boolean;
    defaultProductOptionAttributeValue: ProductOptionAttributeValueModel = null;
    productOptionAttributeValueCreater: IValueCreator;

    constructor(private messageService:MessageService, private dataService: ProductService, private prodOptionService: ProductOptionService, private attributeService: AttributeService) {

        this.productAttributeValues = new Array<SelectItem>();
        this.productAttributeValueCreater = new ProductAttributeValueCreator();
        this.productOptionAttributeValueCreater = new ProductOptionAttributeValueCreator();
        this.disableProductAttributeValue = true;
        this.attributeService.getAttributes().subscribe((attributes: AttributeModel[]) => {
            this.allAttributes = attributes;
        });
    }

    //part of the component lifecycle - called when changes to the input properties
    public ngOnChanges(changes: SimpleChanges) {
        //this commented code is for reference is case we need to get the current product from the changes
        //for (let propName in changes) {
        //    let chng = changes[propName];
        //    let cur = chng.currentValue;
        //    let prev = chng.previousValue;
        //    if (propName === 'product') {
        //        var obj = cur;
        //        this.product = ProductModelParser.parseObjectIntoProduct(obj);
        //    }
        //}
        this.productAttributeValues = new Array<SelectItem>();
        this.productAttributeList = new Array<SelectItem>();
        this.productOptionList = new Array<SelectItem>();
        this.productOptionForAttributeValueList = new Array<SelectItem>();
        this.selectedProductOptionForAttributeValue = null;
        this.showDetail = false;

        if (this.product != null) {
            //get the attributes for the product
            this.dataService.getAttributesForProduct(this.product)
                .subscribe((attributes: AttributeModel[]) => {
                        this.selectedProductAttribute = new AttributeDropDown();
                        if (attributes.length < 1) {
                            this.showPrductAttributeValues = false;
                            this.selectedProductAttribute.label = 'No Attributes associated with Product';
                        } else {
                            this.showPrductAttributeValues = true;
                            this.selectedProductAttribute.label = 'Select an Attribute';
                        }
                        this.productAttributeList.push(this.selectedProductAttribute);
                        attributes.forEach((attribute: AttributeModel) => {
                            var attributeDropDownItem: AttributeDropDown = new AttributeDropDown();
                            attributeDropDownItem.label = attribute.name;
                            attributeDropDownItem.value = attribute;
                            this.productAttributeList.push(attributeDropDownItem);
                        });
                    },
                    error => this.handleError(error));
            //get the options for the product
            this.prodOptionService.getOptionsForProduct(this.product)
                .subscribe((productOptions: ProductOptionModel[]) => {
                        this.selectedProductOption = new ProductOptionDropDown();
                        this.selectedProductOptionForAttributeValue = new ProductOptionDropDown();;
                        var defaultDisplayValue: string;
                        if (productOptions.length < 1) {
                            defaultDisplayValue = 'No Options associated with Product';
                        } else {
                            defaultDisplayValue = 'Select an Option';
                        }
                        this.selectedProductOption.label = defaultDisplayValue;
                        this.selectedProductOptionForAttributeValue.label = defaultDisplayValue;
                        this.productOptionList.push(this.selectedProductOption);
                        this.productOptionForAttributeValueList.push(this.selectedProductOption);
                        productOptions.forEach((productOption: ProductOptionModel) => {
                            var productOptionDropDownItem: ProductOptionDropDown = new ProductOptionDropDown();
                            productOptionDropDownItem.label = productOption.name;
                            productOptionDropDownItem.value = productOption;

                            this.productOptionList.push(productOptionDropDownItem);
                            this.productOptionForAttributeValueList.push(productOptionDropDownItem);
                        });
                    },
                    error => this.handleError(error));
        }
    }

    //associate attributes with product option
    public handleProductOptionChange(event:any) {
        this.attributes = new Array<AttributeModel>();
        this.possibleAttributes = new Array<AttributeModel>();
        this.validProductOption = false;
        if (this.selectedProductOption != null) {
            this.prodOptionService.getAttributesForProductOption(this.product, this.selectedProductOption).subscribe((attributes: AttributeModel[]) => {
                this.attributes = attributes;
                this.possibleAttributes = new Array<AttributeModel>();
                this.allAttributes.forEach((att: AttributeModel) => {
                    if (this.isProductAttributeAssociated(att) === false) {
                        this.possibleAttributes.push(att);
                    }
                });
                this.validProductOption = true;
            });
        }
    }
    private isProductAttributeAssociated(attribute: AttributeModel): boolean {
        var returnValue: boolean = false;
        for (var sub = 0; sub < this.attributes.length; sub++) {
            var associatedAttribute = this.attributes[sub];
            if (associatedAttribute.id === attribute.id) {
                returnValue = true;
                break;
            }
        }
        return returnValue;
    }
    public clickSaveAttributes() {
        this.prodOptionService.setAttributesForProductOption(this.product, this.selectedProductOption,this.attributes).subscribe(
            () => {
                this.messageService.clear();
                this.attributes = new Array<AttributeModel>();
                this.possibleAttributes = new Array<AttributeModel>();
                this.validProductOption = false;
                this.selectedProductOption = null;
                //reset the product option attribute values section
                this.selectedProductOptionForAttributeValue = null;
                this.productOptionAttributeValues = null;
                this.showDetail = false;
            },
            error => this.handleError(error)
        );
    }

    //set attribute values for the product
    public handleProductAttributeChange(event:any) {
        this.productAttributeValues = new Array<SelectItem>();
        this.disableProductAttributeValue = this.selectedProductAttribute == null;
        if (this.selectedProductAttribute != null) {
            this.dataService.getAttributeValuesForProduct(this.product, this.selectedProductAttribute)
                .subscribe((attributeValues: ProductAttributeValueModel[]) => {
                        var tempArray = new Array<SelectItem>();
                        attributeValues.forEach((attributeValue: ProductAttributeValueModel) => {
                            var item: SelectItem = { label: attributeValue.description, value: attributeValue }
                            tempArray.push(item);
                            if (attributeValue.isDefault) {
                                this.defaultProductAttributeValue = attributeValue;
                            }
                        });
                        this.productAttributeValues = tempArray;
                    },
                    error => this.handleError(error));
        }
    }
    public handleDefaultProductAttributeValueChange(event:any) {
        this.setdefaultProductAttributeValue();
    }
    public productAttributeValuesChanged(event: SelectItem[]) {
        this.productAttributeValues = event;
        if (event.length > 0) {
            this.defaultProductAttributeValue = event[0].value;
            this.setdefaultProductAttributeValue();
        }
    }
    public clickSaveProductAttributeValues() {
        var dataToSubmit: ProductAttributeValueModel[] = new Array<ProductAttributeValueModel>();
        this.productAttributeValues.forEach(selItem => dataToSubmit.push(selItem.value));
        this.dataService
            .setAttributeValuesForProduct(this.product, this.selectedProductAttribute, dataToSubmit)
            .subscribe(() => {
                this.messageService.clear();
                this.productAttributeValues = new Array();
                this.defaultProductAttributeValue = null;
                this.selectedProductAttribute = null;
                this.disableProductAttributeValue = true;
            }, error => this.handleError(error));
    }
    private setdefaultProductAttributeValue() {
        this.productAttributeValues.forEach((attributeValue) => {
            attributeValue.value.isDefault = false;
        });
        this.defaultProductAttributeValue.isDefault = true;
    }

    //set attribute values for product options (only the options associated with the product)
    public handleProductOptionForAttributeValueChange(event:any) {
        this.showDetail = false;
        this.productOptionAttributeList = new Array<SelectItem>();
        if (this.selectedProductOptionForAttributeValue != null) {
            this.showDetail = true;
            this.prodOptionService.getAttributesForProductOption(this.product, this.selectedProductOptionForAttributeValue)
                .subscribe((attributes: AttributeModel[]) => {
                        this.selectedProductOptionAttribute = new AttributeDropDown();
                        if (attributes.length < 1) {
                            this.showPrductOptionAttributeValues = false;
                            this.selectedProductOptionAttribute.label = 'No Attributes associated with Product Option';
                        } else {
                            this.showPrductOptionAttributeValues = true;
                            this.selectedProductOptionAttribute.label = 'Select an Attribute';
                        }
                        this.productOptionAttributeList.push(this.selectedProductOptionAttribute);
                        attributes.forEach((attribute: AttributeModel) => {
                            var attributeDropDownItem: AttributeDropDown = new AttributeDropDown();
                            attributeDropDownItem.label = attribute.name;
                            attributeDropDownItem.value = attribute;
                            this.productOptionAttributeList.push(attributeDropDownItem);
                        });
                    },
                    error => this.handleError(error));
        }
    }
    public handleProductOptionAttributeChange(event:any) {
        this.productOptionAttributeValues = new Array();
        this.disableProductOptionAttributeValue = this.selectedProductOptionAttribute == null;
        if (this.selectedProductOptionAttribute != null) {
            this.prodOptionService.getAttributeValuesForProductOption(this.product,
                    this.selectedProductOptionForAttributeValue,
                    this.selectedProductOptionAttribute)
                .subscribe((poattValues: ProductOptionAttributeValueModel[]) => {
                    var tempArray = new Array<SelectItem>();
                    poattValues.forEach((attributeValue: ProductOptionAttributeValueModel) => {
                            var item: SelectItem = { label: attributeValue.description, value: attributeValue }
                            tempArray.push(item);
                            if (attributeValue.isDefault) {
                                this.defaultProductOptionAttributeValue = attributeValue;
                            }
                          });
                      this.productOptionAttributeValues = tempArray;
                    },
                    error => this.handleError(error));
        }
    }
    public handleDefaultProductOptionAttributeValueChange(event:any){
        this.setdefaultProductOptionAttributeValue();
    }
    public productOptionAttributeValuesChanged(event: SelectItem[]) {
        this.productOptionAttributeValues = event;
        if (event.length > 0) {
            this.defaultProductOptionAttributeValue = event[0].value;
            this.setdefaultProductOptionAttributeValue();
        }
    }
    private setdefaultProductOptionAttributeValue() {
        this.productOptionAttributeValues.forEach((attributeValue) => {
            attributeValue.value.isDefault = false;
        });
        this.defaultProductOptionAttributeValue.isDefault = true;
    }

    public clickSaveProductOptionAttributeValues() {
        var dataToSubmit: ProductOptionAttributeValueModel[] = new Array<ProductOptionAttributeValueModel>();
        this.productOptionAttributeValues.forEach(selItem => dataToSubmit.push(selItem.value));
        this.prodOptionService
            .setAttributeValuesForProductOption(this.product, this.selectedProductOptionForAttributeValue, this.selectedProductOptionAttribute, dataToSubmit)
            .subscribe(() => {
                this.messageService.clear();
                this.productOptionAttributeValues = new Array();
                this.defaultProductOptionAttributeValue = null;
                this.selectedProductOptionAttribute = null;
                this.disableProductOptionAttributeValue = true;
            }, error => this.handleError(error));

    }

    private handleError(errorMsg: string) {
        this.messageService.clear;
        this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
