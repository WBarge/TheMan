//framework
import { Component, OnInit, forwardRef } from '@angular/core';
import { NgModel,NG_VALUE_ACCESSOR } from '@angular/forms';

//models
import { IPropertyModel } from '../../models/propertyBag/PropertyModel';
import { ValueAccessorBase } from '../../helpers/valueAccessorBase';


@Component({
    selector: 'propertyBag',
    templateUrl: './propertyBag.component.html',
    styleUrls: ['./propertyBag.component.css'],
    providers: [{
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => PropertyBag),
        multi: true,
    }]
})
export class PropertyBag extends ValueAccessorBase<IPropertyModel[]> {
    constructor() {
        super();
    }

}
