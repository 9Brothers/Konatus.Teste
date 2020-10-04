import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AircraftModel } from 'src/entities/aircraft-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AircraftModelService {

  constructor(private _http: HttpClient) { }

  getAll() {
    return this._http.get<AircraftModel[]>(`${environment.baseUrl}/ModeloAeronave/All`).toPromise();
  }

  get(code: string = '') {
    return this._http.get<AircraftModel[]>(`${environment.baseUrl}/ModeloAeronave?code=${code}`).toPromise();
  }

  add(aircraftModel: AircraftModel) {
    return this._http.post(`${environment.baseUrl}/ModeloAeronave`, aircraftModel).toPromise();
  }

  update(aircraftModel: AircraftModel) {
    return this._http.put(`${environment.baseUrl}/ModeloAeronave`, aircraftModel).toPromise();
  }

  delete(code: string) {
    return this._http.delete(`${environment.baseUrl}/ModeloAeronave?code=${code}`).toPromise();
  }
}
