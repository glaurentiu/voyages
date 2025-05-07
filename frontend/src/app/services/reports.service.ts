import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ReportsService {
  private apiUrl = 'https://localhost:44383/api/Reports/visited-countries-last-year';

  constructor(private http: HttpClient) {}

  getVisitedCountriesLastYear(): Observable<Record<string, number>> {
    return this.http.get<Record<string, number>>(this.apiUrl);
  }
}