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

  getCustomer(id: number) : Observable<ICustomer> {
    return this.http.get<ICustomer>(this.baseCustomersUrl + '/' + id).pipe(
      map((customer: ICustomer) => {
          return customer;
      }),
      catchError(this.handleError)
    );
  }

addCustomer(customer: ICustomer) : Observable<ICustomer> {
  return this.http.post<ICustomer>(this.baseCustomersUrl, customer).pipe(
    map((customer: ICustomer) => {
        return customer;
    }),
    catchError(this.handleError)
  );
}

updateCustomer(customer: ICustomer) : Observable<ICustomer> {
  return this.http.put<ICustomer>(this.baseCustomersUrl + '/' + customer.id, customer).pipe(
    map((customer: ICustomer) => {
        return customer;
    }),
    catchError(this.handleError)
  );
}

deleteCustomer(customer: ICustomer) : Observable<ICustomer> {
  return this.http.delete<ICustomer>(this.baseCustomersUrl + '/' + customer.id).pipe(
    map((res) => {
        return res;
    }),
    catchError(this.handleError)
  );
}

getPolicies() : Observable<IPolicy[]> {
  return this.http.get<IPolicy[]>(this.basePoliciesUrl).pipe(
    map((policies: IPolicy[]) => {
        return policies;
    }),
    catchError(this.handleError)
  );
}

getPolicy(id: number) : Observable<IPolicy> {
  return this.http.get<IPolicy>(this.basePoliciesUrl + '/' + id).pipe(
    map((policy: IPolicy) => {
        return policy;
    }),
    catchError(this.handleError)
  );
}

addPolicy(policy: IPolicy) : Observable<IPolicy> {
return this.http.post<IPolicy>(this.basePoliciesUrl, policy).pipe(
  map((policy: IPolicy) => {
      return policy;
  }),
  catchError(this.handleError)
);
}

updatePolicy(policy: IPolicy) : Observable<IPolicy> {
return this.http.put<IPolicy>(this.basePoliciesUrl + '/' + policy.id, policy).pipe(
  map((policy: IPolicy) => {
      return policy;
  }),
  catchError(this.handleError)
);
}

deletePolicy(policy: IPolicy) : Observable<IPolicy> {
return this.http.delete<IPolicy>(this.basePoliciesUrl + '/' + policy.id).pipe(
  map((res) => {
      return res;
  }),
  catchError(this.handleError)
);
}

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error); 
    return Observable.throw(error);
  }
}
