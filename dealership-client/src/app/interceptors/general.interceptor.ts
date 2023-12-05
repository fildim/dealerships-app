import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "../services/token.service";
import { Observable, catchError, tap, throwError } from "rxjs";
import { Router } from "@angular/router";


@Injectable()
export class GeneralInterceptor implements HttpInterceptor {

    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req).pipe(

            tap({
                error: x => {
                    console.log(JSON.stringify(x));

                    if (x instanceof HttpErrorResponse && x.status === 401) {
                        this.tokenService.removeToken();
                        this.router.navigateByUrl('');
                    }
                },
                complete: () => console.log('completed'),
            }),
        );
    }
}