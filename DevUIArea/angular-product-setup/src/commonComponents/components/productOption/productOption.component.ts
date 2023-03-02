//framework
import { Component, OnInit, Input } from '@angular/core';

//Third Party

//models
import { ProductOptionModel } from '../../../commonComponents/models/products/productOptionModel';

//services



@Component({
    selector: 'productOption',
    templateUrl: './productOption.component.html',
    styleUrls: ['./productOption.component.css']
})
export class ProductOptionComponent implements OnInit {

    @Input('ProductOptionData') data: ProductOptionModel;

    //vars for this component

    constructor() {
    }

    public ngOnInit() {
        if (this.data === null) {
            this.data = new ProductOptionModel();
        }
    }
}
