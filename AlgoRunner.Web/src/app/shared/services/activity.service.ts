import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Activity } from '../models/activity';


@Injectable({
    providedIn: 'root',
})

export class ActivityService {

    apiUrl: string = environment.apiUrl + "activity";

    getActivities(): Observable<Activity[]> {
        return this._http.get<Activity[]>(this.apiUrl);
    }


    addActivity(newActiviry: Activity): Observable<Activity> {
        return this._http.post<Activity>(this.apiUrl, newActiviry);
    }

    removeActivity(id: number): void {
        this._http.post(this.apiUrl + "/RemoveActivity/", id).subscribe();
    }


    constructor(private _http: HttpClient) {
    }

}