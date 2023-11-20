import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { FormBuilder } from '@angular/forms';
import { LoginOwnerModel } from 'src/app/models/owner/login.owner.model';

@Component({
  selector: 'app-owner-login',
  templateUrl: './owner-login.component.html',
  styleUrls: ['./owner-login.component.css'],
})
export class OwnerLoginComponent {

  constructor(
    private router: Router,
    private service: OwnerService,
    private tokenService: TokenService,
  ) { }


  loginOwnerForm = new FormGroup({

    phone: new FormControl([Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl([Validators.required, Validators.maxLength(8)])
  });



  onSubmit() {
    this.service.Login({
      phone: String = this.loginOwnerForm. ,
      password: "12312312"
    }).subscribe({
      next: x => {
        this.tokenService.setToken(x.toString());
        this.router.navigateByUrl("owner-layout")
      },
      error: x => console.log("login error")
    });




  }



}
