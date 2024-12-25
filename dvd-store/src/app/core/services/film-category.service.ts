import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { MovieCategory } from '../models/MovieCategory';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FilmCategoryService {
 
  private baseURL = environment.apiUrl + '/film/category';

  constructor(private http: HttpClient) {}

  public getFilmsByCategoryId(id: number): Observable<MovieCategory[]> {
    return this.http.get<MovieCategory[]>(`${this.baseURL}/${id}`);
  }
}
