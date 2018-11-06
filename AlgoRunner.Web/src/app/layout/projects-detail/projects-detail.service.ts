import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {Project} from './models/project'



@Injectable({
  providedIn: 'root',
})

export class ProjectsDetailService {


  apiUrl: string = environment.apiUrl + "projects";


  getProject(id: number):Observable<Project>
  {
    return this._http.get<Project>(this.apiUrl + "/"+id);
  }

  constructor(private _http: HttpClient) {
  }
}