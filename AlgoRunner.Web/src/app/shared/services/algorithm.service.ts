import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Algorithm } from '../../layout/algorithm/models/algorithm';
import { ProjectAlgo } from '../models/projectAlgo';
import { projectAlgoList } from '../models/projectAlgoList';


@Injectable({
  providedIn: 'root',
})

export class AlgorithmService {


  apiUrl: string = environment.apiUrl + "algo/";


  saveAlg(algo: Algorithm): Observable<boolean> {
    return this._http.post<boolean>(this.apiUrl, algo);
  }

  uploadAlg(file: File, activityId: number): Observable<string> {
    let formData: FormData = new FormData();

    formData.append(file.name, file);
    formData.append(activityId.toString(), '');
    return this._http.post<string>(this.apiUrl + "UploadFile", formData)
  }


  getAlg(projectId: number, id: number): Observable<Algorithm[]> {
    return this._http.get<Algorithm[]>(this.apiUrl  + projectId + "/"+ id);
  }

  checkAccess(projectId:number, activityId: number): Observable<any> {
    let projectAlgo = new ProjectAlgo();
    projectAlgo.algoId = activityId;
    projectAlgo.projectId = projectId;
    
    return this._http.post<string>(this.apiUrl + "checkAccess", projectAlgo);
  }

  runAlgorithms(projectId:number,algos: Algorithm[]) {
    let projectAlgo = new projectAlgoList();
    projectAlgo.algos = algos;
    projectAlgo.projectId = projectId;
    return this._http.post(this.apiUrl + "RunAlgorithms",projectAlgo);
  }

  constructor(private _http: HttpClient) {
  }
}