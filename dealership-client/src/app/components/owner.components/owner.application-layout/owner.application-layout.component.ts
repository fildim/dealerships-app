import { Component } from '@angular/core';

import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';


@Component({
  selector: 'app-owner.application-layout',
  templateUrl: './owner.application-layout.component.html',
  styleUrls: ['./owner.application-layout.component.css']
})
export class OwnerApplicationLayoutComponent {
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );



  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    private tokenService: TokenService
  ) { }

  ownerFirstname: string = this.tokenService.getFirstname();
  ownerLastname: string = this.tokenService.getLastname();


  logout() {
    this.tokenService.removeToken();
    this.router.navigateByUrl("/");
  }
}