import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { IValueCreator } from '../../interfaces/IValueCreator';


@Component({
    selector: 'listEntry',
    templateUrl: './listEntry.component.html',
    styleUrls: ['./listEntry.component.css']
})
export class ListEntryComponent implements OnChanges{

    @Input('Creator') valueCreator: IValueCreator;


    @Input('EnteryValues')enteryValues: SelectItem[];
    @Input('disabled') enabled: boolean;

    @Output() valuesChanged: EventEmitter<SelectItem[]> = new EventEmitter<SelectItem[]>();

    selectedValue: SelectItem;
    newValue: string;
    newDescription:string;

    constructor() {
        if (this.enteryValues == null) {
            this.enteryValues = new Array<SelectItem>();
        }
    }

  ngOnChanges(changes: SimpleChanges): void {
    console.info("got into ng on changes")
  }

    clickAddToList() {
        var found:boolean = false;
        this.enteryValues.forEach(x => {
            if (x.label === this.newDescription) {
                found = true;
                return;
            }
        });
        if (!found) {
            var newValueToStore = this.valueCreator.createValueObject(this.newValue,this.newDescription);
            var item: SelectItem = { label: this.newDescription, value: newValueToStore };
            var tempArray: SelectItem[] = new Array();
            this.enteryValues.forEach(x => tempArray.push(x));
            tempArray.push(item);
            this.enteryValues = tempArray;
            this.valuesChanged.emit(this.enteryValues);
        }
        this.newValue = "";
        this.newDescription = "";
    }

    clickRemoveFromList() {
        var tempArray: SelectItem[] = new Array();
        this.enteryValues.forEach(x => {
            if (x.value != this.selectedValue) {
                tempArray.push(x);
            }
        });
        this.enteryValues = new Array();
        tempArray.forEach(x => { this.enteryValues.push(x); });
        this.selectedValue = null;
        this.valuesChanged.emit(this.enteryValues);
    }
}
