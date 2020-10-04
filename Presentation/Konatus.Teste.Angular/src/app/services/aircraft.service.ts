import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Aircraft } from 'src/entities/aircraft';
import { AircraftModel } from 'src/entities/aircraft-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AircraftService {

  constructor(private _http: HttpClient) { }

  get(prefix: string = '', page: number = 0) {
    return this._http.get<Aircraft[]>(`${environment.baseUrl}/Aeronave?prefix=${prefix}&page=${page}`).toPromise();
  }

  add(aircraft: Aircraft) {
    return this._http.post(`${environment.baseUrl}/Aeronave`, aircraft).toPromise();
  }

  update(aircraft: Aircraft) {
    return this._http.put(`${environment.baseUrl}/Aeronave`, aircraft).toPromise();
  }

  delete(prefix: string) {
    return this._http.delete(`${environment.baseUrl}/Aeronave?prefix=${prefix}`).toPromise();
  }
}
