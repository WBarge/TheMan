import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';



import { Observable } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';

import { HttpErrorHandler } from '../../helpers/HttpErrorHandler';


import { ServiceLocatorService } from '../../service/serviceLocator.service';
import { ServiceLocations } from '../../models/ServiceLocations';
import { IErrorMessageFromServer } from '../../interfaces/IErrorMessageFromServer';

import { FieldsetModule } from "primeng/primeng";
import { SelectItem } from 'primeng/primeng';

import { AddressPanelModel } from '../../models/addressPanelModel';

@Component({
    selector: 'addressPanel',
    template: './addressPanel.component.html',
    styles: ['./addressPanel.component.css']
})
export class AddressPanelComponent implements OnInit {

    @Input('Header') headingTest: string = "Test Heading";
    stateList: SelectItem[];
    @Input('AddressData')data:AddressPanelModel;
    selectedState: any;

    @Output('ErrorHandler') errorhandler: EventEmitter<IErrorMessageFromServer> = new EventEmitter<IErrorMessageFromServer>(true);

    constructor(private http: HttpClient, private configService: ServiceLocatorService) {
    }

    ngOnInit() {
        this.buildStateList();
    }

    private buildStateList() {
        this.getStates().subscribe((result: SelectItem[]) => {
            this.stateList = result;
        });
    }

    private getStates(): Observable<SelectItem[]> {
        return (this.configService.getServiceLocation().pipe(
            switchMap((config: ServiceLocations) => this.handleConfigurationResult(config)),
            catchError (err => HttpErrorHandler.errorHandler(err))) as any
        );
    }

    private handleConfigurationResult(conf: ServiceLocations): Observable<SelectItem[]> {
        return(this.http.get(conf.statesLocation).pipe(
            map(this.handleGetStatesResults),
            catchError(HttpErrorHandler.errorHandler)) as any
            );
    }
    //TODO FIX
    private handleGetStatesResults(res: object): SelectItem[] {
        let body = res as SelectItem[];
        return body;
    }

}
