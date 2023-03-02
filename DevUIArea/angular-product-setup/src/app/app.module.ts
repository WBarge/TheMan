import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

//Third party imports
import { TabViewModule } from 'primeng/tabview';
import { DropdownModule } from 'primeng/dropdown';
import { FieldsetModule } from 'primeng/fieldset';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';
//import { SharedModule } from 'primeng/primeng';
import { DialogModule } from 'primeng/dialog';
//import { DataListModule } from 'primeng/primeng';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ToastModule } from 'primeng/toast';
import { PickListModule } from 'primeng/picklist';
import { InputMaskModule } from 'primeng/inputmask';
import { ListboxModule } from 'primeng/listbox';
import { MenuModule } from 'primeng/menu';
import { CalendarModule } from 'primeng/calendar';
import { SpinnerModule } from 'primeng/spinner';
import {MessageService} from 'primeng/api'
import { Moment } from 'moment';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './components/products/products.component';//product grid
import { ProductOptionsComponent } from './components/productOptions/productOptions.component';//product option grid
import { AttributesComponent } from './components/attributes/attributes.component';//product option grid
import { ProductSetupComponent } from './components/productSetup/productSetup.component';//product configuration (setup)
import { BaseProductPricesComponent } from './components/baseProductPrices/baseProductPrices.component';//product prices grid
import { BaseOptionPricesComponent } from './components/baseOptionPrices/baseOptionPrices.component';//product option prices grid
import { PriceComponent } from './components/price/price.component';//price detail
import { PackagedProduct } from './components/packagedProduct/packagedProduct.component';
import { ProductComponent } from '../commonComponents/components/product/product.component';//product detail
import { ProductOptionComponent } from '../commonComponents/components/productOption/productOption.component';//product option detail
import { AttributeComponent } from '../commonComponents/components/attribute/attribute.component';//product option detail
import { ListEntryComponent } from '../commonComponents/components/listEntry/listEntry.component';
import { PropertyBag } from '../commonComponents/components/propertyBag/propertyBag.component';
//views
import { ProductPricingViewComponent } from './views/productPricingView.component';
import { ProductSetupViewComponent } from './views/productSetupView.component';
import { OptionPricingViewComponent } from './views/optionPricingView.component';
import { ProductPackageViewComponent } from './views/productPackageView.Component';


//application services
import { ServiceLocatorService } from '../commonComponents/service/serviceLocator.service';//location of all services
import { ProductService } from '../commonComponents/service/product.service';
import { ProductOptionService } from '../commonComponents/service/productOption.service';
import { AttributeService } from '../commonComponents/service/attribute.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductPricingViewComponent,
    ProductSetupViewComponent,
    OptionPricingViewComponent,
    ProductPackageViewComponent,
    ProductsComponent,
    ProductComponent,
    ProductOptionsComponent,
    ProductOptionComponent,
    AttributesComponent,
    AttributeComponent,
    ProductSetupComponent,
    ListEntryComponent,
    BaseProductPricesComponent,
    BaseOptionPricesComponent,
    PriceComponent,
    PackagedProduct,
    PropertyBag
  ],
  providers: [
    ServiceLocatorService,
    MessageService,
    ProductService,
    ProductOptionService,
    AttributeService
],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    TabViewModule,
    DropdownModule,
    FieldsetModule,
    ButtonModule,
    CheckboxModule,
    TableModule,
    //SharedModule,
    DialogModule,
    InputTextModule,
    PasswordModule,
    ToastModule,
    PickListModule,
    InputMaskModule,
    ListboxModule,
    MenuModule,
    CalendarModule,
    SpinnerModule,
    FontAwesomeModule,
    AppRoutingModule
],
  bootstrap: [AppComponent]
})
export class AppModule { }
