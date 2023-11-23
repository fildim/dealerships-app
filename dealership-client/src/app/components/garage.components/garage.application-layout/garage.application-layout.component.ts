import { Component } from '@angular/core';

import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-garage.application-layout',
  templateUrl: './garage.application-layout.component.html',
  styleUrls: ['./garage.application-layout.component.css']
})
export class GarageApplicationLayoutComponent {

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

  garageName: string = this.tokenService.getFirstname();



  logout() {
    this.tokenService.removeToken();
    this.router.navigateByUrl("/");
  }

}
