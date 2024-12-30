import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResponseRentalsJson } from '../models/ResponseRentalsJson';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  private readonly API_URL = environment.apiUrl + '/rental';

  constructor(private http: HttpClient) {}

  getRentalByCustomerId(
    customerId: number,
    pageIndex: number,
    pageSize: number
  ): Observable<ResponseRentalsJson> {
    const params = {
      PageNumber: pageIndex.toString(),
      PageSize: pageSize.toString(),
    };

    return this.http.get<ResponseRentalsJson>(
      `${this.API_URL}/customer-id/${customerId}`, { params }
    );
  }
}
