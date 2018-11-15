import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Algorithm } from './models/algorithm';


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

  constructor(private _http: HttpClient) {
  }
}