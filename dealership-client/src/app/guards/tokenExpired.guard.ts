
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { TokenService } from '../services/token.service';

@Injectable({
    providedIn: 'root'
})
class TokenExpiredGuardService {
    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (this.tokenService.isExpired()) {

            this.tokenService.removeToken();
            return this.router.navigateByUrl("");
        }
        else
            return true;
    }
}

export const TokenExpiredGuard: CanActivateFn = (
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree => {
    return inject(TokenExpiredGuardService).canActivate(next, state);
}

