//framework
import { Component, OnInit } from '@angular/core';

//Third Party
import { MessageService } from 'primeng/api';

//models
import { AttributeModel } from '../../../commonComponents/models/products/attributeModel';

//services
import { AttributeService } from '../../../commonComponents/service/attribute.service';


@Component({
    selector: 'attributes',
    templateUrl: './attributes.component.html',
    styleUrls: ['./attributes.component.css']
})
export class AttributesComponent implements OnInit {
    //vars

    //data for the grid
    attributeData: AttributeModel[];

    //create new product dialog
    showNewAttributeDialog: boolean;
    newAttribute: AttributeModel;

    //edit product dialog
    showAttributeDetailDialog: boolean;
    selectedAttribute: AttributeModel;

    constructor(private messageService:MessageService, private dataService: AttributeService) {
        this.attributeData = new Array<AttributeModel>();
    }

    public ngOnInit(): void {
        this.loadAttributes();
    }

    private loadAttributes() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.dataService.getAttributes().subscribe((dataSet: AttributeModel[]) => {
            this.attributeData = dataSet;
            this.messageService.clear();
            },
            ex => this.handleError(ex));
    }

    public clickNewAttributeDialog() {
        if (this.newAttribute == null)
            this.newAttribute = new AttributeModel();
        this.showNewAttributeDialog = true;
    }
    public createNewAttributeDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productOptionToUpload: AttributeModel = this.newAttribute;
        this.dataService.setAttribute(productOptionToUpload).subscribe(
            () => this.loadAttributes(),
            error => this.handleError(error)
        );
        this.showNewAttributeDialog = false;
    }

    public clickDetailAttributeDialog(productOption: AttributeModel) {
        this.selectedAttribute = productOption;
        this.showAttributeDetailDialog = true;
    }
    public saveAttributeDetailDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Saving Product' });
        const productOptionToUpload: AttributeModel = this.selectedAttribute;
        this.dataService.setAttribute(productOptionToUpload).subscribe(
            () => { this.messageService.clear(); },
            error => this.handleError(error)
        );

        this.showAttributeDetailDialog = false;
    }

    private handleError(errorMsg: string) {
      this.messageService.clear();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }

}
