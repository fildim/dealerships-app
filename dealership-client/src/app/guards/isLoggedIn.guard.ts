
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { TokenService } from '../services/token.service';

@Injectable({
    providedIn: 'root'
})
class IsLoggedInGuardService {
    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (this.tokenService.isLoggedIn() && !this.tokenService.isExpired())
            return true;
        else
            return this.router.navigateByUrl('not-found');
    }
}

export const IsLoggedInGuard: CanActivateFn = (
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree => {
    return inject(IsLoggedInGuardService).canActivate(next, state);
}