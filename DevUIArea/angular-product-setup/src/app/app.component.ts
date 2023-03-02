import { Component } from '@angular/core';
import { MenuItem } from 'primeng/primeng';

import { ServiceLocatorService } from '../commonComponents/service/serviceLocator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-product-setup';
  items: MenuItem[];

  constructor(private locator: ServiceLocatorService) {
    var url: string = "https://localhost:44341";//location.origin;
    this.locator.setUrl(url);
}

ngOnInit() {
    this.items = [
        { label: 'Definitions', routerLink: ['/productSetup']},
        { label: 'Price Products', routerLink: ['/productPricing'] },
        { label: 'Price Options', routerLink: ['/optionPricing'] },
        { label: 'Package Product', routerLink: ['/productPackaging'] }
        ];
}

}
