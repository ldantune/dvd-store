import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseActorsJson } from '../models/ResponseActorsJson';

@Injectable({
  providedIn: 'root',
})
export class ActorService {
  private readonly API_URL = environment.apiUrl + '/actor';

  constructor(private http: HttpClient) {}

  getAllActors(
    pageIndex: number = 1,
    pageSize: number = 10
  ): Observable<ResponseActorsJson> {
    const params = {
      PageNumber: pageIndex.toString(),
      PageSize: pageSize.toString(),
    };

    return this.http.get<ResponseActorsJson>(this.API_URL, { params });
  }
}
