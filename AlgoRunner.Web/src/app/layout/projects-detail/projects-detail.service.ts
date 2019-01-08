import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {Project} from './models/project'
import { Algorithm } from '../algorithm/models/algorithm';



@Injectable({
  providedIn: 'root',
})

export class ProjectsDetailService {


  apiUrl: string = environment.apiUrl + "projects";


  getProject(id: number):Observable<Project>
  {
    return this._http.get<Project>(this.apiUrl + "/"+id);
  }

  loadAlgsData(page: number): Observable<Algorithm[]> {
    return this._http.get<Algorithm[]>(this.apiUrl + "/LoadAllAlgs/");
  }

  execiteProject(id : number){
    return this._http.post(this.apiUrl + "ExeciteProject" ,id);
  }

  saveProject(proj : Project){
    return this._http.post(this.apiUrl ,proj);
  }

  constructor(private _http: HttpClient) {
  }
}