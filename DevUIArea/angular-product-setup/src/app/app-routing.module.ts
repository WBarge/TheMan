import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductPricingViewComponent } from './views/productPricingView.component';
import { ProductSetupViewComponent } from './views/productSetupView.component';
import { OptionPricingViewComponent } from './views/optionPricingView.component';
import { ProductPackageViewComponent } from './views/productPackageView.Component';


const routes: Routes = [
  { path: 'productSetup', component: ProductSetupViewComponent },
  { path: 'productPricing', component: ProductPricingViewComponent },
  { path: 'productPackaging', component: ProductPackageViewComponent },
  { path: 'optionPricing', component: OptionPricingViewComponent },
  { path: 'productPricing/:testParameter', component: ProductPricingViewComponent }, //without this path definition combined with the one above you cannot pass an optional parameter to view 1
  {
      path: '',
      redirectTo: '/productSetup',
      pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
