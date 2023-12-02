import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "../services/token.service";
import { Observable, catchError, throwError } from "rxjs";
import { Router } from "@angular/router";


@Injectable()
export class GeneralInterceptor implements HttpInterceptor {

    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req).pipe(
            catchError((error: any) => {
                if (error instanceof HttpErrorResponse && error.status === 401) {
                    this.tokenService.removeToken();
                    this.router.navigateByUrl('');
                }
                return throwError(() => new Error(error));
            })
        );
    }
}