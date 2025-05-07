import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Voyage {
  id: number;
  shipId: number;
  shipName: string;
  shipMaxSpeed: number;
  departurePortId: number;
  departurePortName: string;
  departureCountryName: string;
  arrivalPortId: number;
  arrivalPortName: string;
  arrivalCountryName: string;
  startTimestamp: string;
  endTimestamp: string;
}

@Injectable({
  providedIn: 'root',
})
export class VoyageService {
  private apiUrl = 'https://localhost:44383/api/Voyages'; 

  constructor(private http: HttpClient) {}

  getVoyages(): Observable<Voyage[]> {
    return this.http.get<Voyage[]>(this.apiUrl);
  }
}