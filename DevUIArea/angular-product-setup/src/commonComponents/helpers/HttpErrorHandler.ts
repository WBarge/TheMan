import { HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IErrorMessageFromServer } from '../../commonComponents/interfaces/IErrorMessageFromServer';

export class HttpErrorHandler {
    public static errorHandler(error: HttpErrorResponse | any) {
        let errMsg: string;
        let systemErrorMessage: IErrorMessageFromServer;
        if (error instanceof HttpErrorResponse) {
            systemErrorMessage = error.error;
            errMsg = `${systemErrorMessage.exceptionType} - ${systemErrorMessage.message || ''} URL Error Happened At ${error.url}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return throwError(systemErrorMessage ? systemErrorMessage.message : errMsg);
    }
}
