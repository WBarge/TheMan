//*******************************************************************
//  This is Definitions item on the Product Menu
//*******************************************************************

import { Component } from '@angular/core';

import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'productSetupView',
    templateUrl: './productSetupView.component.html',
    styleUrls: ['./productSetupView.component.css']
})
export class ProductSetupViewComponent {

    constructor(private route: ActivatedRoute,
        private router: Router) {
    }
}
