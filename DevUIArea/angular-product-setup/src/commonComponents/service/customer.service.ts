import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map,switchMap,catchError} from 'rxjs/operators';

import { SelectItem } from 'primeng/primeng';
import { ServiceLocatorService } from '../service/serviceLocator.service';
import { HttpErrorHandler } from '../helpers/HttpErrorHandler';
import { ServiceLocations } from '../models/ServiceLocations';
import { CustomerModel } from '../models/customerModel';
import { CustomerModelParser } from '../parsers/customerModelParser';

@Injectable()
export class CustomerService {

    constructor(private http: HttpClient, private configService: ServiceLocatorService) { }

    public setCustomer(customer: CustomerModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap(config => this.saveCustomer(config, customer)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveCustomer(locations: ServiceLocations, customer: CustomerModel) {
        const body: string = JSON.stringify(customer);
        const headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json' );
        return this.http.post(locations.customerLocation, body, { headers: headers }).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getCustomers(): Observable<CustomerModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap(config => this.handleConfigurationResultForGetCustomers(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetCustomers(conf: ServiceLocations): Observable<CustomerModel[]> {
        return this.http.get(conf.customersLocation).pipe(
            map(this.handleGetCustomersResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetCustomersResult(res: object[]): CustomerModel[] {
        var returnValue: CustomerModel[] = CustomerModelParser.parseResponseInToArray(res);
        return returnValue;
    }

    public getPhoneNumberTypes(): Observable<SelectItem[]> {
        return (this.configService.getServiceLocation().pipe(
            switchMap(config => this.handleConfigurationResultForGetPhoneNumberTypes(config)),
            catchError(err => HttpErrorHandler.errorHandler(err)))
        );
    }
    private handleConfigurationResultForGetPhoneNumberTypes(conf: ServiceLocations): Observable<SelectItem[]> {
        return (this.http.get(conf.phoneNumberTypesLocation).pipe(
            map(this.handleGetPhoneNumberTypesResults),
            catchError(HttpErrorHandler.errorHandler))
        );
    }
    private handleGetPhoneNumberTypesResults(res: object[]): SelectItem[] {
        var returnValue: SelectItem[] = (res as SelectItem[]);
        return returnValue;
    }

}
