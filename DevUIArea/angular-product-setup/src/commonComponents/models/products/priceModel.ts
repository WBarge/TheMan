export class PriceModel {

    //standard data properties
    public id: string;
    public startDateTime: Date;
    public startDateTimeString: string;
    public endDateTime: Date;
    public endDateTimeString: string;
    public flatPrice: number;
    public formulaPrice: string;
    public formulaVariables:string[];

    //calculated properties (hence ready-only)

    //is this the default price for the item - should only be one
    get isDefaultPrice(): boolean {
        var returnValue: boolean = false;
        returnValue = (this.startDateTime.getFullYear() === 9999);
        return returnValue;
    }

    //does the item have a formula price
    get hasFormula(): boolean {
        return (this.formulaPrice !== '');
    }

    //the start date for the price (formatted to local)
    get startFormatted(): string {
        var returnValue = '';
        returnValue = this.startDateTime.toLocaleDateString();
        return returnValue;
    }
    //the end date for the price (formatted to local)
    get endFormatted(): string {
        var returnValue = '';
        returnValue = this.endDateTime.toLocaleDateString();
        return returnValue;
    }

    get formulaVariablesFormatted(): string {
        var newLineString: string = '\r\n';
        var tabString: string = '\t';
        var returnValue: string = 'The list of avaiable variables are:' + newLineString;
        if (this.formulaVariables != null) { 
            this.formulaVariables.forEach(fr => returnValue += tabString+fr+newLineString);
        }
        return returnValue;
    }

    constructor() {
        this.id = '';
        this.startDateTime = new Date(Date.now());
        this.endDateTime = new Date(Date.now());
        this.flatPrice = 0;
        this.formulaPrice = '';
        this.formulaVariables = null;
    }


}