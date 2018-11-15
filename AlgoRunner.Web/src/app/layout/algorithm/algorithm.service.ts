import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Algorithm } from './models/algorithm';


@Injectable({
  providedIn: 'root',
})

export class AlgorithmService {

  apiUrl: string = environment.apiUrl + "algo";


  saveAlg( algo: Algorithm): Observable<boolean>{
        return this._http.post<boolean>(this.apiUrl, algo);
  }

  constructor(private _http: HttpClient) {
  }
}