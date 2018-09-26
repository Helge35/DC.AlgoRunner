import { Injectable, EventEmitter } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';



@Injectable({
    providedIn: 'root',
})

export class AuthService {

    private httpHeaders: HttpHeaders;
    apiUrl: string = environment.apiUrl + "users";
    user: string;
    authChange: EventEmitter<string> = new EventEmitter();

    logIn(): boolean {
        this.logInPrv().subscribe(u => {
            this.user = u;
            this.authChange.emit(this.user);
        },
            error => { console.log('Error: ' + error.message); });

        return true;
    }

    private logInPrv(): Observable<string> {
        return this._http.get<string>(this.apiUrl)
    }

    getAuthChangeEmitter() {
        return this.authChange;
    }

    constructor(private _http: HttpClient) {
    }
}