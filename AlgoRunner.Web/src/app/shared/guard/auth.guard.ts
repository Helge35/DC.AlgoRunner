import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private _authService: AuthService) { }

    user: string;

    canActivate() {
        if (localStorage.getItem('isLoggedin')) {
            return true;
        }

        if (this._authService.logIn()) {
            return true;
        }

        // this.router.navigate(['/login']);
        return false;
    }
}
