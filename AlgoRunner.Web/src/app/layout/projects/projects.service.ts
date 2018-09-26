import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DashboardInfo } from './models/dashboardInfo';



@Injectable({
  providedIn: 'root',
})

export class ProjectsService {


  apiUrl: string = environment.apiUrl + "projects";

  getDashboardInfo(): Observable<DashboardInfo> {
    return this._http.get<DashboardInfo>(this.apiUrl);
  }

  constructor(private _http: HttpClient) {
  }
}