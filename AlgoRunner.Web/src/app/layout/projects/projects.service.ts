import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DashboardInfo } from './models/dashboardInfo';
import {Project} from './models/project'



@Injectable({
  providedIn: 'root',
})

export class ProjectsService {


  apiUrl: string = environment.apiUrl + "projects";

  getDashboardInfo(): Observable<DashboardInfo> {
    return this._http.get<DashboardInfo>(this.apiUrl);
  }

  addToFavorite(id: number): Observable<boolean> {
    return this._http.get<boolean>(this.apiUrl + "/AddToFavorite/" + id);
  }

  loadProjectData(page: number):Observable<DashboardInfo>
  {
    return this._http.get<DashboardInfo>(this.apiUrl + "/LoadProjects/"+page);
  }

  constructor(private _http: HttpClient) {
  }
}