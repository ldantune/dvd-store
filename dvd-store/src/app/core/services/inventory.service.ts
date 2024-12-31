import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Inventory } from '../models/Inventory';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class InventoryService {
  private readonly API_URL = environment.apiUrl + '/inventory';
  constructor(private http: HttpClient) {}

  public getByInventoryId(id: number): Observable<Inventory> {
    return this.http.get<Inventory>(`${this.API_URL}/${id}`);
  }
}
