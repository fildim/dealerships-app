import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';
@Component({
  selector: 'not-found',
  templateUrl: './not-found.component.html'
})
export class NotFoundComponent {

  constructor(
    private router: Router,
    private tokenService: TokenService
  ) { }

  goBack() {

    if (this.tokenService.getUserType() == "owner") this.router.navigateByUrl('owner-all-appointments');
    if (this.tokenService.getUserType() == "garage") this.router.navigateByUrl('garage-all-appointments');
  }

}
