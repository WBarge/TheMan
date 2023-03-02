//framework
import { Component, OnInit, Input,Output } from '@angular/core';

//models
import { PriceModel } from '../../../commonComponents/models/products/priceModel';


@Component({
    selector: 'price',
    templateUrl: './price.component.html',
    styleUrls: ['./price.component.css']
})
export class PriceComponent implements OnInit {
    //vars
    @Input() priceData: PriceModel;
    @Input() showFormula: boolean = true;

    constructor() {
    }

    public ngOnInit(): void {
        if (this.priceData == null) {
            this.priceData = new PriceModel();
        }
    }

}
