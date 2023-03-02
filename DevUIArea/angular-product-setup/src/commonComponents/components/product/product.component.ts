//framework
import { Component, OnInit, Input } from '@angular/core';

//Third Party

//models
import { ProductModel } from '../../../commonComponents/models/products/productModel';

//services



@Component({
    selector: 'product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

    @Input('ProductData') data: ProductModel;

    //vars for this component

    constructor() {
    }

    public ngOnInit() {
        if (this.data === null) {
            this.data = new ProductModel();
        }
    }
}
