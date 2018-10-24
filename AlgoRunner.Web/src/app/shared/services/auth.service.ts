import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { User } from '../models/user';
import { AdminInfo } from '../models/adminInfo';
import { Activity } from '../models/activity';


@Injectable({
    providedIn: 'root',
})

export class AuthService {

    private httpHeaders: HttpHeaders;
    apiUrl: string = environment.apiUrl + "users";
    user: User;
    authChange: EventEmitter<User> = new EventEmitter();

    logIn(): boolean {
        this.logInPrv().subscribe(u => {
            this.user = u;
            this.authChange.emit(this.user);
        },
            error => { console.log('Error: ' + error.message); });

        return true;
    }

    private logInPrv(): Observable<User> {
        return this._http.get<User>(this.apiUrl)
    }

    getAuthChangeEmitter() {
        return this.authChange;
    }

    getAdminInfo(): Observable<AdminInfo> {
        return this._http.get<AdminInfo>(this.apiUrl + "/GetAdminInfo");
    }

    addActivity(activityName: string): Observable<Activity> {
        return this._http.get<Activity>(this.apiUrl + "/AddActivity/" + activityName);
    }


    constructor(private _http: HttpClient) {
    }
}