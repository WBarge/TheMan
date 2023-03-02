import { Observable } from 'rxjs';
import { SelectItem } from 'primeng/primeng';


export interface IDropDownItemsRetriever {
    getItems( ): Observable<SelectItem[]>;
}