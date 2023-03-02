import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { ServiceLocations } from '../models/ServiceLocations';

@Injectable()
export class ServiceLocatorService{

    private localUrl: string;

    constructor(private http: HttpClient) { }

    public setUrl(url: string) {
        this.localUrl = url;
    }

    public getServiceLocation(): Observable<ServiceLocations> {

        const hostLocation: string = this.localUrl;
        const bannerfileUploadPath: string = '/systemdata/BannerFileUpload';
        const bannerFileListPath: string = '/systemdata/GetBannerFiles';
        const footerfileUploadPath: string = '/systemdata/FooterFileUpload';
        const footerFileListPath: string = '/systemdata/GetFooterFiles';
        const getSystemConfigurationPath: string = '/systemdata/GetSystemConfiguration';
        const setSystemConfigurationPath: string = '/systemdata/SetSystemConfiguration';
        const userServicePath: string = '/systemdata/GetUsers';
        const addUserServicePath: string = '/systemdata/AddNewUser';
        const rolesServicePath: string = '/systemdata/GetRoles';
        const setUserRolesPath: string = '/systemdata/SetUserRoles';

        const getCustomersPath: string = '/People/GetCustomers';
        const setCustomerPath: string = '/People/SetCustomer';
        const getStatesPath: string = '/People/GetStates';
        const getPhoneNumberTypesPath: string = '/People/GetPhoneNumberTypes';

        const customerPath:string ='/Customer';
        const customersPath:string ='/Customers';
        const statesPath:string ='/States';
        const phoneNumberTypesPath:string='/PhoneNumberTypes';

        const productPath:string = '/Product';
        const productsPath:string = '/Products';
        const productOptionPath:string= '/ProductOption';
        const productOptionsPath:string= '/ProductOptions';
        const attributePath:string= '/Attribute';
        const attributesPath:string= '/Attributes';
        const productPricingPath:string = '/ProductPricing';
        const productOptionPricingPath:string = '/ProductOptionPricing';
        const packagedProductsPath:string = '/PackagedProducts';


        //const getProductsPath: string = '/Products';
        //const productPath: string = '/Product';

        const getProductOptionsPath: string = '/ProductOptions';
        const setProductOptionPath: string = '/ProductOption';

        const getAttributePath: string = '/Attributes';
        const setAttributePath: string = '/Attribute';

        const setProductOptionsForProductPath: string = '/Product/ProductOptions'
        const getGetOptionsForProductPath: string = '/ProductOptions';

        const getProductAttributePath: string = '/Product/Attributes';
        const setAttributesForProductPath: string = '/Product/Attributes';

        const getAttributesForProductOptionPath: string = '/OriginalProduct/GetAttributesForProductOption';
        const setAttributesForProductOptionPath: string = '/OriginalProduct/SetAttributesForProductOption';

        const getAttributeValuesForProductPath: string = '/OriginalProduct/GetAttributeValuesForProduct';
        const setAttributeValuesForProductPath: string = '/OriginalProduct/SetAttributeValuesForProduct';

        const getProductOptionAttributeValuesPath: string = '/OriginalProduct/GetAttributeValuesForProductOption';
        const setProductOptionAttributeValuesPath: string = '/OriginalProduct/SetAttributeValuesForProductOption';

        const createInitialProductPricingPath: string = '/OriginalProduct/CreateInitialProductPrice';
        const getProductsWithNoPricesPath: string = '/OriginalProduct/GetProductsWithNoPrices';
        const getPricingForProductsPath: string = '/OriginalProduct/GetPricingForProducts';
        const setProductPricePath: string = '/OriginalProduct/SetProductPrice';

        const getProductOptionsWithPricesPath: string = '/OriginalProduct/GetPricingFromProductOptions';
        const getProductOptionsWithNoPricesPath: string = '/OriginalProduct/GetProductOptionsWithNoPrices';
        const createInitialOptionPricePath: string = '/OriginalProduct/CreateInitialOptionPrice';
        const setProductOptionPricePath: string = '/OriginalProduct/SetProductOptionPrice';
        const getPackagedProductsPath: string = '/OriginalProduct/GetPackagedProducts';

        var returnValue: ServiceLocations = new ServiceLocations();
        returnValue.bannerFileUploadServiceLocation = hostLocation + bannerfileUploadPath;
        returnValue.bannerFileListServiceLocation = hostLocation + bannerFileListPath;
        returnValue.footerFileUploadServiceLocation = hostLocation + footerfileUploadPath;
        returnValue.footerFileListServiceLocation = hostLocation + footerFileListPath;
        returnValue.getSystemConfigurationServiceLocation = hostLocation + getSystemConfigurationPath;
        returnValue.setSystemConfigurationServiceLocation = hostLocation + setSystemConfigurationPath;
        returnValue.usersServiceLocation = hostLocation + userServicePath;
        returnValue.addUserServiceLocation = hostLocation + addUserServicePath;
        returnValue.rolesServiceLocation = hostLocation + rolesServicePath;
        returnValue.setUserRolesLocation = hostLocation + setUserRolesPath;




        // returnValue.getCustomersLocation = hostLocation + getCustomersPath;
        // returnValue.setCustomerLocation = hostLocation + setCustomerPath;
        // returnValue.getStatesLocation = hostLocation + getStatesPath;
        // returnValue.getPhoneNumberTypesLocation = hostLocation + getPhoneNumberTypesPath;

        returnValue.customerLocation = hostLocation + customerPath;
        returnValue.customersLocation = hostLocation + customersPath;
        returnValue.statesLocation = hostLocation + statesPath;
        returnValue.phoneNumberTypesLocation = hostLocation + phoneNumberTypesPath;




        returnValue.productLocation = hostLocation + productPath;
        returnValue.productsLocation = hostLocation + productsPath;
        returnValue.productOptionLocation = hostLocation + productOptionPath;
        returnValue.productOptionsLocation =hostLocation + productOptionsPath;
        returnValue.attributeLocation =hostLocation + attributePath;
        returnValue.attributesLocation =hostLocation + attributesPath;
        returnValue.productPricingLocation=hostLocation + productPricingPath;
        returnValue.productOptionPricingLocation=hostLocation + productOptionPricingPath;
        returnValue.packagedProductsLocation=hostLocation +packagedProductsPath

        // returnValue.getProductsLocation = hostLocation + getProductsPath;
        // returnValue.setProductLocation = hostLocation + productPath;
        // returnValue.getProductOptionsLocation = hostLocation + productPath;
        // returnValue.setProductOptionLocation = hostLocation + setProductOptionPath;
        // returnValue.getOptionsForProductLocation = hostLocation + getGetOptionsForProductPath;
        // returnValue.setProductOptionsForProductLocation = hostLocation + setProductOptionsForProductPath;
        // returnValue.getAttributesLocation = hostLocation + getAttributePath;
        // returnValue.setAttributeLocation = hostLocation + setAttributePath;
        // returnValue.getProductAttributeLocation = hostLocation + getProductAttributePath;
        // returnValue.setAttributesForProductLocation = hostLocation + setAttributesForProductPath;
        // returnValue.getAttributesForProductOptionLocation = hostLocation + getAttributesForProductOptionPath;
        // returnValue.setAttributesForProductOptionLocation = hostLocation + setAttributesForProductOptionPath;
        // returnValue.getProductAttributeValuesLocation = hostLocation + getAttributeValuesForProductPath;
        // returnValue.setProductAttributeValuesLocation = hostLocation + setAttributeValuesForProductPath;
        // returnValue.getProductOptionAttributeValuesLocation = hostLocation + getProductOptionAttributeValuesPath;
        // returnValue.setProductOptionAttributeValuesLocation = hostLocation + setProductOptionAttributeValuesPath;
        // returnValue.createInitialProductPricingLocation = hostLocation + createInitialProductPricingPath;
        // returnValue.getProductsWithNoPricesLocation = hostLocation + getProductsWithNoPricesPath;
        // returnValue.getPricingForProductsLocation = hostLocation + getPricingForProductsPath;
        // returnValue.setProductPriceLocation = hostLocation + setProductPricePath;
        // returnValue.getProductOptionsWithPricesLocation = hostLocation + getProductOptionsWithPricesPath;
        // returnValue.getProductOptionsWithNoPricesLocation = hostLocation + getProductOptionsWithNoPricesPath;
        // returnValue.createInitialOptionPriceLocation = hostLocation + createInitialOptionPricePath;
        // returnValue.setProductOptionPriceLocation = hostLocation + setProductOptionPricePath;
        // returnValue.getPackagedProductsLocation = hostLocation + getPackagedProductsPath;

        return of(returnValue);

        //*******************************************************************************************************************************************
        //The below functionality was orginal with the application and will need to be changed to use the newest patterns with rxjs and httpclient
        //*******************************************************************************************************************************************

        //This is a service call to get the locations of all the service from the web server
        //var url: string = localUrl + "/api/systemdata/GetServiceLocation";
        //return this.http.get(url)
        //    .map(this.extractData)
        //    .catch(this.errorHandler);//should use the global error handler commoncomponents/helpers/HttpErrorHandler
    }

    //private extractData(res: Response): ServiceLocations {
    //    let body = res.json();//convert this over to use a parser
    //    return body || {};
    //}

}
