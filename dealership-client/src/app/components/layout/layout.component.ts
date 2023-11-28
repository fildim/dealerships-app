import { map, shareReplay } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { TokenService } from 'src/app/services/token.service';
import { Router } from '@angular/router';
@Component({
  selector: 'layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent {


  constructor(private breakpointObserver: BreakpointObserver, private tokenService: TokenService, private router: Router) { }

  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  public isLoggedIn(): boolean {
    return this.tokenService.isLoggedIn();
  }

  public isOwner(): boolean {
    return this.tokenService.getUserType() == "owner";
  }

  public isGarage(): boolean {
    return this.tokenService.getUserType() == "garage";
  }

  public logout(): void {
    this.router.navigateByUrl('');

    return this.tokenService.removeToken();
  }

  public get garageName(): string {
    let garageName = '';
    this.tokenService.isLoggenInObservable().subscribe(x => {
      if (x && this.tokenService.getUserType() == 'garage')
        garageName = this.tokenService.getGarageName();
    });

    return garageName;
  }

  public get ownerFirstname(): string {
    let ownerFirstname = '';
    this.tokenService.isLoggenInObservable().subscribe(x => {
      if (x && this.tokenService.getUserType() == 'owner')
        ownerFirstname = this.tokenService.getFirstname();
    });

    return ownerFirstname;
  }

  public get ownerLastname(): string {
    let ownerLastname = '';
    this.tokenService.isLoggenInObservable().subscribe(x => {
      if (x && this.tokenService.getUserType() == 'owner')
        ownerLastname = this.tokenService.getLastname();
    });

    return ownerLastname;
  }
}
