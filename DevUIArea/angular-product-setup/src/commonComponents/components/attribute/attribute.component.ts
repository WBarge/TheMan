//framework
import { Component, OnInit, Input } from '@angular/core';

//Third Party

//models
import { AttributeModel } from '../../../commonComponents/models/products/attributeModel';

//services



@Component({
    selector: 'attribute',
    templateUrl: './attribute.component.html',
    styleUrls: ['./attribute.component.css']
})
export class AttributeComponent implements OnInit {

    @Input('AttributeData') data: AttributeModel;

    //vars for this component

    constructor() {
    }

    public ngOnInit() {
        if (this.data === null) {
            this.data = new AttributeModel();
        }
    }
}
