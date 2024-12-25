import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private baseURL = environment.apiUrl + '/category';  // URL da sua API

  constructor(private http: HttpClient) {}

  public getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseURL);
  }

   // Certifique-se de que o método retorna um Observable
  //  getCategories(): Observable<{ id: number; name: string; lastUpdate: string }[]> {
  //   return this.http.get<{ id: number; name: string; lastUpdate: string }[]>(this.apiUrl);
  // }

  // Esse método deve retornar um Observable
  addCategory(category: any): Observable<any> {
    return this.http.post<any>(this.baseURL, category);
  }
}
