import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { GarageService } from 'src/app/services/garage.service';


@Component({
  selector: 'app-garage-login',
  templateUrl: './garage-login.component.html',
  styleUrls: ['./garage-login.component.css']
})
export class GarageLoginComponent {


  constructor(
    private router: Router,
    private service: GarageService,
    private tokenService: TokenService,
  ) { }


  LoginGarageForm = new FormGroup({

    phone: new FormControl([Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl([Validators.required, Validators.maxLength(8)])
  });


  onSubmit() {
    this.service.Login({
      phone: '',
      password: ''
    }).subscribe({
      next: x => {
        this.tokenService.setToken(x.toString());
        this.router.navigateByUrl("owner-layout")
      },
      error: x => console.log("login error")
    });

  }

}
