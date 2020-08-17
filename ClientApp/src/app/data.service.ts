import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ICustomer, IPolicy } from './interfaces'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseCustomersUrl: string = '/api/customer';
  basePoliciesUrl: string = '/api/policy'

  constructor(private http: HttpClient) { }

  getCustomers() : Observable<ICustomer[]> {
    return this.http.get<ICustomer[]>(this.baseCustomersUrl).pipe(
      map((customers: ICustomer[]) => {
          return customers;
      }),
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error); 
    return Observable.throw(error);
  }
}
