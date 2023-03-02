import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import {map,switchMap,catchError} from 'rxjs/operators';

import { ServiceLocatorService } from '../service/serviceLocator.service';
import { HttpErrorHandler } from '../helpers/HttpErrorHandler';
import { ServiceLocations } from '../models/ServiceLocations';
import { ProductModel } from '../models/products/productModel';
import { AttributeModel } from '../models/products/attributeModel';
import { ProductModelParser } from '../parsers/productModels/productModelParser';
import { AttributeModelParser } from '../parsers/productModels/attributeModelParser';
import { ProductAttributeValueModelParser } from '../parsers/productModels/productAttributeValueModelParser';
import { AttributesForProductRequest } from '../models/requests/products/attributesForProductRequest';
import { ProductAttributeValueModel } from '../models/products/productAttributeValueModel';
import { AttributeValuesForProductRequest } from '../models/requests/products/attributeValuesForProductRequest';
import { InitialProductPriceRequest } from '../models/requests/products/initialProductPriceRequest';
import { ProductPricingModel } from '../models/products/productPricingModel';
import { ProductPricingModelParser } from '../parsers/productModels/productPricingModelParser';
import { PriceModel } from '../models/products/priceModel';
import { ProductPriceRequest } from '../models/requests/products/productPriceRequest';
import {PackagedProductModel} from '../models/products/packagedProductModel';
import {PackagedProductModelParser} from '../parsers/productModels/packagedProductModelParser';

@Injectable()
export class ProductService {

    constructor(private http: HttpClient, private configService: ServiceLocatorService) { }

    public setProduct(product: ProductModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) =>this.saveProduct(config, product)),
            catchError(err =>HttpErrorHandler.errorHandler(err))
        );
    }
    private saveProduct(locations: ServiceLocations, product: ProductModel) {
        return this.http.post(locations.productLocation, product).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }


    public getProducts(): Observable<ProductModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetProducts(config)),
            catchError(err =>HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProducts(conf: ServiceLocations): Observable<ProductModel[]> {
        return this.http.get(conf.productsLocation).pipe(
            map(this.handleGetProductsResult),
            catchError(err =>HttpErrorHandler.errorHandler(err))
        );
    }
    private handleGetProductsResult(res: object[]): ProductModel[] {
        var returnValue: ProductModel[] = ProductModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public getAttributesForProduct(product: ProductModel): Observable<AttributeModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetAttributesForProduct(config,product)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetAttributesForProduct(conf: ServiceLocations, product: ProductModel): Observable<AttributeModel[]> {
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
        let uri:string = conf.productLocation +"/"+product.id+"/Attributes"
        return this.http.get(conf.getProductAttributeLocation, { headers: headers }).pipe(
            map(this.handleGetProductAttributeResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetProductAttributeResult(res: object[]): AttributeModel[] {
        var returnValue: AttributeModel[] = AttributeModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public setAttributesForProduct(product: ProductModel, attributes: AttributeModel[]) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveAttributesForProduct(config, product, attributes)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveAttributesForProduct(locations: ServiceLocations,
        product: ProductModel,
        attributes: AttributeModel[]) {
        var request: AttributesForProductRequest = new AttributesForProductRequest();
        request.product = product;
        request.attributes = attributes;
        let uri:string = locations.productLocation +"/Attributes";
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getAttributeValuesForProduct(product: ProductModel, attribute: AttributeModel): Observable<ProductAttributeValueModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap(
                (config: ServiceLocations) => this.handleConfigurationResultForGetAttributeValuessForProduct(config,
                    product,
                    attribute)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetAttributeValuessForProduct(conf: ServiceLocations, product: ProductModel, attribute: AttributeModel): Observable<ProductAttributeValueModel[]> {
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
        let uri:string = conf.productLocation +"/"+ product.id+"/Attribute/"+attribute.id;
        return this.http.get(uri, { headers: headers }).pipe(
            map(this.handleGetProductAttributeValueResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetProductAttributeValueResult(res: object[]): ProductAttributeValueModel[] {
        var returnValue: ProductAttributeValueModel[] = ProductAttributeValueModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public setAttributeValuesForProduct(product: ProductModel, attribute: AttributeModel, values: ProductAttributeValueModel[]) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveAttributeValuesForProduct(config,
                product,
                attribute,
                values)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveAttributeValuesForProduct(locations: ServiceLocations,
        product: ProductModel,
        attribute: AttributeModel,
        values: ProductAttributeValueModel[]) {
        var request: AttributeValuesForProductRequest = new AttributeValuesForProductRequest();
        request.product = product;
        request.attribute = attribute;
        request.attributeValues = values;
        let uri:string = locations.productLocation +"/AttributeValues";
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public createInitialProductPricing(product: ProductModel, initialPrice: number) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveInitialProductPricing(config, product, initialPrice)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveInitialProductPricing(locations: ServiceLocations,product: ProductModel, initialPrice: number) {
        var request: InitialProductPriceRequest = new InitialProductPriceRequest();
        request.product = product;
        request.initialPrice = initialPrice;
        let uri:string = locations.productPricingLocation+"/NewProduct";
        return this.http.post(uri, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getProductsWithNoPrices(): Observable<ProductModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetProductsWithNoPrices(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProductsWithNoPrices(conf: ServiceLocations): Observable<ProductModel[]> {
      let uri:string = conf.productPricingLocation+"/Products";
      return this.http.get(uri).pipe(
            map(this.handleGetProductsResult),
            catchError(HttpErrorHandler.errorHandler)
        );

    }

    public getProductsWithPrices(): Observable<ProductPricingModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetProductsWithPrices(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetProductsWithPrices(conf: ServiceLocations): Observable<ProductPricingModel[]> {
        return this.http.get(conf.productPricingLocation).pipe(
            map(this.handlePricingForProductsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handlePricingForProductsResult(res: object[]): ProductPricingModel[] {
        var returnValue: ProductPricingModel[] = ProductPricingModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public setProductPrice(product: ProductModel, price: PriceModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveProductPrice(config, product, price)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveProductPrice(conf: ServiceLocations, product: ProductModel, price: PriceModel){
        var request: ProductPriceRequest = new ProductPriceRequest(product,price);
        return this.http.post(conf.productPricingLocation, request).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getPackagedProducts(): Observable<PackagedProductModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetPackagedProducts(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetPackagedProducts(conf: ServiceLocations): Observable<PackagedProductModel[]> {
        return this.http.get(conf.packagedProductsLocation).pipe(
            map(this.handleGetPackagedProductsResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetPackagedProductsResult(res: object[]): PackagedProductModel[] {
        var returnValue: PackagedProductModel[] = PackagedProductModelParser.parseResponseInToArray(res);
        return returnValue;
    }

}
