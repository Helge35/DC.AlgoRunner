import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AlgoResultDotesGraph } from './models/algoResultDotesGraph';



@Injectable({
    providedIn: 'root',
})

export class ResultsService {

    apiUrl: string = environment.apiUrl + "results";

    getResultByPath(path: string): Observable<AlgoResultDotesGraph> {
        return this._http.get<AlgoResultDotesGraph>(this.apiUrl + "/" + path);
    }

    constructor(private _http: HttpClient) {
    }
}