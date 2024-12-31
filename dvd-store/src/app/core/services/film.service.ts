import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Film } from '../models/Film';

@Injectable({
  providedIn: 'root'
})
export class FilmService {

private baseURL = environment.apiUrl + '/film';

  constructor(private http: HttpClient) {}

  public getByFilmId(filmId: number): Observable<Film> {
    return this.http.get<Film>(`${this.baseURL}/${filmId}`);
  }

}
