import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AlgoResult} from './models/algoResult';



@Injectable({
    providedIn: 'root',
})

export class ResultsService {

    apiUrl: string = environment.apiUrl + "results";

    getResultByPath(path: string): Observable<AlgoResult[]> {
        return this._http.get<AlgoResult[]>(this.apiUrl + "/" + path);
    }

    constructor(private _http: HttpClient) {
    }
}