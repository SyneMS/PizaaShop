import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { pizzaDetails } from '../models/pizzaDetails.model';
import { ingradients } from '../models/ingradients.model';
import { pizzaIngradients } from '../models/pizzaIngradients.model';
import { BehaviorSubject } from 'rxjs';
import { finalOrder } from '../models/finalOrder.model';
import { environment } from 'src/environments/environment';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class PizzaService {

    public finalOrder = new BehaviorSubject(null);
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {

    }

    setFinalOrder(obj: finalOrder) {
        this.finalOrder.next(obj);
    }

    getFinalOrder() {
        return this.finalOrder;
    }

    getAllDefaultPizza(): Observable<pizzaDetails[]> {
        return this.http.get<pizzaDetails[]>(this.baseUrl + 'pizza/GetDefaultPizzDetails');
    };

    getAllPizzaIngradients(pizzaId): Observable<pizzaIngradients[]> {
        return this.http.get<pizzaIngradients[]>(this.baseUrl + 'pizza/GetPizzIngradients/' + pizzaId);
    };

    getAllIngradients(): Observable<ingradients[]> {
        return this.http.get<ingradients[]>(this.baseUrl + 'pizza/GetAllIngradients/');
    };

    placeOrder(finalOrder): Observable<number> {
        return this.http.post<number>(this.baseUrl + 'pizza/SavePizzaDetails/', finalOrder, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }).pipe(catchError(this.handleError));
    };

    private handleError(errorResponse: HttpErrorResponse) {
        let errorMessage = '';
        if (errorResponse.error instanceof ErrorEvent) {
            errorMessage = `Error: ${errorResponse.error.message}`;
            console.error('Client Side Error :', errorResponse.error.message);
        } else {
            errorMessage = `Error Status: ${errorResponse.status}\nMessage: ${errorResponse.message}`;
            console.error('Server Side Error :', errorResponse);
        }
        // return an observable with a meaningful error message to the end user
        console.log(errorMessage);
        return throwError(errorMessage);
    }


}
