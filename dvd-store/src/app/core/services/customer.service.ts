import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResponseCustomersJson } from '../models/ResponseCustomersJson';
import { Observable } from 'rxjs';
import { Customer } from '../models/Customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private readonly API_URL = environment.apiUrl + '/customer';

  constructor(private http: HttpClient) {}

  getAllCustomers(
    pageIndex: number = 1,
    pageSize: number = 10
  ): Observable<ResponseCustomersJson> {
    const params = {
      PageNumber: pageIndex.toString(),
      PageSize: pageSize.toString(),
    };

    return this.http.get<ResponseCustomersJson>(this.API_URL, { params });
  }

  getCustomerById(customerId: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.API_URL}/${customerId}`);
  }
}