/*import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root',
})
export class ReportsService {

  reportsUrl: string = "localhost:57017/api/reports";
  selectedReport: Observable<Report>;

  getReportsList(): Observable<Report[]> {
    //return of(REPORTS);
    return this.http.get<Report[]>(this.reportsUrl)
      .pipe(
        catchError(this.handleError('getReportsList', []))
      );

  }

  getReport(id: number): void {
    this.selectedReport = of(REPORTS.find(rep => rep.id === id));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }


  constructor(private http: HttpClient) { }
}*/