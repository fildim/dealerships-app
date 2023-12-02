import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "../services/token.service";
import { Observable, catchError, of, tap, throwError } from "rxjs";
import { Router } from "@angular/router";


@Injectable()
export class GeneralInterceptor implements HttpInterceptor {

    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        // if (this.tokenService.isExpired()) {

        //     this.tokenService.removeToken();
        //     this.router.navigateByUrl("");

        //     return new Observable<HttpEvent<any>>(x => {
        //         x.complete();
        //     })
        // }



        // var var1 = next.handle(req);

        // var1.pipe(catchError(
        //     (x: HttpErrorResponse) => {
        //         if (x.status == 401) {
        //             this.tokenService.removeToken();
        //             this.router.navigateByUrl('');
        //         }
        //         return of();
        //     }
        // )
        // );

        // return var1;

        return next.handle(req).pipe(
            catchError((error: any) => {
                if (error instanceof HttpErrorResponse && error.status === 401) {
                    this.tokenService.removeToken();
                    this.router.navigateByUrl('');
                }
                return throwError(error);
            })
        );
    }
}