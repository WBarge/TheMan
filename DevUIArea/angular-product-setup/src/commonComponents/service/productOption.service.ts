import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';


import { Observable } from 'rxjs';
import {map,switchMap,catchError} from 'rxjs/operators';

import { ServiceLocatorService } from '../service/serviceLocator.service';
import { HttpErrorHandler } from '../helpers/HttpErrorHandler';
import { ServiceLocations } from '../models/ServiceLocations';
import { ProductOptionModel } from '../models/products/productOptionModel';
import { ProductModel } from '../models/products/productModel';
import { ProductOptionsForProductRequest } from "../models/requests/products/productOptionsForProductRequest";
import { ProductOptionModelParser } from '../parsers/productModels/productOptionModelParser';
import { AttributeModel } from '../models/products/attributeModel';
import { AttributeModelParser } from '../parsers/productModels/attributeModelParser';
import { AttributesForProductOptionRequest } from '../models/requests/products/attributesForProductOptionRequest';
import { ProductOptionAttributeValueModel } from '../models/products/productOptionAttributeValueModel';
import { ProductOptionAttributeValueModelParser } from '../parsers/productModels/productOptionAttributeValueModelParser';
import { AttributeValuesForProductOptionRequest } from '../models/requests/products/attributeValuesForProductOptionRequest';
import { OptionPricingModel } from '../models/products/optionPricingModel';
import { OptionPricingModelParser } from '../parsers/productModels/optionPricingModelParser';
import { InitialProductOptionPriceRequest } from '../models/requests/products/InitialProductOptionPriceRequest';
import { PriceModel } from '../models/products/priceModel';
import { ProductPriceRequest } from '../models/requests/products/productPriceRequest';
import { ProductOptionPriceRequest } from '../models/requests/products/ProductOptionPriceRequest';

@Injectable()
export class ProductOptionService {

    constructor(private http: HttpClient, private configService: ServiceLocatorService) { }

    public setProductOption(productOption: ProductOptionModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveProductOption(config, productOption)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveProductOption(locations: ServiceLocations, productOption: ProductOptionModel) {
        return this.http.post(locations.productOptionLocation, productOption).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public setProductionOptionsForProduct(product: ProductModel, productOptions: ProductOptionModel[]) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveProductionOptionsForProduct(config,
                product,
                productOptions)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveProductionOptionsForProduct(locations: ServiceLocations,
        product: ProductModel,
        productOptions: ProductOptionModel[]) {
        var request: ProductOptionsForProductRequest = new ProductOptionsForProductRequest();
        request.product = product;
        request.options = productOptions;
        let uri:string =locations.productLocation = '/ProductOptions';
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getProductOptions(): Observable<ProductOptionModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetProductOptions(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProductOptions(conf: ServiceLocations): Observable<ProductOptionModel[]> {
        return this.http.get(conf.productOptionsLocation).pipe(
            map(this.handleGetProductOptionsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }

    public getOptionsForProduct(product:ProductModel): Observable<ProductOptionModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetOptionsForProduct(config,
                product)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetOptionsForProduct(conf: ServiceLocations, product: ProductModel): Observable<ProductOptionModel[]> {
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
        debugger
        //let search: HttpParams = new HttpParams();
        //search = search.append("productId", product.id);
        let uri: string = conf.getProductOptionsLocation + "/" + product.id + "/ProductOptions";
        return this.http.get(uri, { headers: headers }).pipe(
            map(this.handleGetProductOptionsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetProductOptionsResult(res: object[]): ProductOptionModel[] {
        var returnValue: ProductOptionModel[] = ProductOptionModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public getAttributesForProductOption(product:ProductModel, productOption: ProductOptionModel): Observable<AttributeModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap(
                (config: ServiceLocations) => this.handleConfigurationResultForGetAttributesForProductOption(config,
                    product,
                    productOption)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetAttributesForProductOption(conf: ServiceLocations, product: ProductModel,productOption: ProductOptionModel): Observable<AttributeModel[]> {
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
        // let search: HttpParams = new HttpParams();
        // search = search.append("productId", product.id);
        // search = search.append("productOptionId",productOption.id);
        let uri:string = conf.productLocation +"/"+product.id+"/ProductOption/"+productOption.id+"/Attributes";
        return this.http.get(uri, { headers: headers }).pipe(
            map(this.handleGetProductOptionAttributeResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetProductOptionAttributeResult(res: object[]): AttributeModel[] {
        var returnValue: AttributeModel[] = AttributeModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public setAttributesForProductOption(product: ProductModel, productOption: ProductOptionModel, attributes: AttributeModel[]) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveAttributesForProductOption(config,
                product,
                productOption,
                attributes)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveAttributesForProductOption(locations: ServiceLocations,
        product: ProductModel,
        productOption: ProductOptionModel,
        attributes: AttributeModel[]) {
        var request: AttributesForProductOptionRequest = new AttributesForProductOptionRequest();
        request.product = product;
        request.productOption = productOption;
        request.attributes = attributes;
        let uri:string = locations.productOptionLocation +"/Attributes";
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getAttributeValuesForProductOption(product: ProductModel,productOption: ProductOptionModel,attribute: AttributeModel): Observable<ProductOptionAttributeValueModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetAttributeValuesForProductOption(
                config,
                product,
                productOption,
                attribute)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );

    }
    private handleConfigurationResultForGetAttributeValuesForProductOption(conf: ServiceLocations, product: ProductModel, productOption: ProductOptionModel, attribute: AttributeModel): Observable<ProductOptionAttributeValueModel[]> {
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
        // let search: HttpParams = new HttpParams();
        // search = search.append("productId", product.id);
        // search = search.append("productOptionId", productOption.id);
        // search = search.append("attributeId",attribute.id);
        let uri:string= conf.productLocation +"/"+product.id+"/ProductOption/"+productOption.id+"/Attribute/"+attribute.id;
        return this.http.get(uri, { headers: headers }).pipe(
            map(this.handleGetProductOptionAttributeValuesResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetProductOptionAttributeValuesResult(res: object[]): ProductOptionAttributeValueModel[] {
        var returnValue: ProductOptionAttributeValueModel[] = ProductOptionAttributeValueModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public setAttributeValuesForProductOption(product: ProductModel, productOption: ProductOptionModel, attribute: AttributeModel, values: ProductOptionAttributeValueModel[]) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveAttributeValuesForProductOption(config,
                product,
                productOption,
                attribute,
                values)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveAttributeValuesForProductOption(locations: ServiceLocations,
        product: ProductModel,
        productOption: ProductOptionModel,
        attribute: AttributeModel,
        values: ProductOptionAttributeValueModel[]) {
        var request: AttributeValuesForProductOptionRequest = new AttributeValuesForProductOptionRequest();
        request.product = product;
        request.productOption = productOption;
        request.attribute = attribute;
        request.attributeValues = values;
        let uri:string = locations.productOptionLocation +"/AttributeValues"
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getProductOptionsWithPrices(): Observable<OptionPricingModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetProductOptionsWithPrices(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProductOptionsWithPrices(conf: ServiceLocations): Observable<OptionPricingModel[]> {
        return this.http.get(conf.productOptionPricingLocation).pipe(
            map(this.handlePricingForProductsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handlePricingForProductsResult(res: object[]): OptionPricingModel[] {
        var returnValue: OptionPricingModel[] = OptionPricingModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public getProductOptionsWithNoPrices(): Observable<ProductModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap(
                (config: ServiceLocations) => this.handleConfigurationResultForGetProductOptionssWithNoPrices(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProductOptionssWithNoPrices(conf: ServiceLocations): Observable<ProductModel[]> {
        let uri:string = conf.productOptionPricingLocation +"/ProductOptions"
        return this.http.get(uri).pipe(
            map(this.handleGetProductOptionsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }

    public createInitialProductPricing(productOption: ProductOptionModel, initialPrice: number) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveInitialProductPricing(config,
                productOption,
                initialPrice)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveInitialProductPricing(locations: ServiceLocations, productOption: ProductOptionModel, initialPrice: number) {
        var request: InitialProductOptionPriceRequest = new InitialProductOptionPriceRequest();
        request.option = productOption;
        request.initialPrice = initialPrice;
        let uri:string = locations.productOptionPricingLocation+"/NewProductOption"
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public setProductOptionPrice(option: ProductOptionModel, price: PriceModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveProductOptionPrice(config, option, price)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveProductOptionPrice(conf: ServiceLocations, option: ProductOptionModel, price: PriceModel) {
        var request: ProductOptionPriceRequest = new ProductOptionPriceRequest(option, price);
        return this.http.post(conf.productOptionPricingLocation, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
}
