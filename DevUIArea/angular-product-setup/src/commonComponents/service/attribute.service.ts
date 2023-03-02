import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import {map,switchMap,catchError} from 'rxjs/operators';

import { ServiceLocatorService } from '../service/serviceLocator.service';
import { ServiceLocations } from '../models/ServiceLocations';
import { HttpErrorHandler } from '../helpers/HttpErrorHandler';
import { AttributeModel } from '../models/products/attributeModel';
import { AttributeModelParser } from '../parsers/productModels/attributeModelParser';

@Injectable()
export class AttributeService {

    constructor(private http: HttpClient, private configService: ServiceLocatorService) { }

    public setAttribute(attribute: AttributeModel) {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.saveAttribute(config, attribute)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private saveAttribute(locations: ServiceLocations, attribute: AttributeModel) {
        return this.http.post(locations.attributeLocation, attribute).pipe(
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }

    public getAttributes(): Observable<AttributeModel[]> {
        return this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResultForGetAttributes(config)),
            catchError(err => HttpErrorHandler.errorHandler(err))
        );
    }
    private handleConfigurationResultForGetAttributes(conf: ServiceLocations): Observable<AttributeModel[]> {
        return this.http.get(conf.attributesLocation).pipe(
            map(this.handleGetAttributesResult),
            catchError(HttpErrorHandler.errorHandler)
        );
    }
    private handleGetAttributesResult(res: object[]): AttributeModel[] {
        var returnValue: AttributeModel[] = AttributeModelParser.parseResponseInToArray(res);
        return returnValue;
    }
}
