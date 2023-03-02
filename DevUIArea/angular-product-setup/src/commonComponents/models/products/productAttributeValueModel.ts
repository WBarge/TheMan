export class ProductAttributeValueModel {
    public id: string;
    public valueName: string;
    public description: string;
    public isDefault: boolean;
    
    constructor() {
        this.id = '';
        this.valueName = '';
        this.description = '';
        this.isDefault = false;
    }
}