import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Category } from '../models/Category';
import { Observable } from 'rxjs';
import { ResponseCategoriesJson } from '../models/ResponseCategoriesJson';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  private readonly API_URL = environment.apiUrl + '/category';

  constructor(private http: HttpClient) {}

  public getCategoriesHome(): Observable<Category[]> {
    const params = {
      IsPaged: false,
    };

    return this.http.get<Category[]>(this.API_URL, { params });
  }

  getAll(pageIndex: number = 1, pageSize: number = 10): Observable<ResponseCategoriesJson> {
    const params = {
      PageNumber: pageIndex.toString(),
      PageSize: pageSize.toString()
    };

    return this.http.get<ResponseCategoriesJson>(this.API_URL, { params });
  }

  // Esse método deve retornar um Observable
  addCategory(category: any): Observable<any> {
    return this.http.post<any>(this.API_URL, category);
  }

}
