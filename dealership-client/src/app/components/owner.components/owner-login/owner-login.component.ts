import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';


@Component({
  selector: 'app-owner-login',
  templateUrl: './owner-login.component.html',
  styleUrls: ['./owner-login.component.css'],
})
export class OwnerLoginComponent implements OnInit {

  constructor(
    private router: Router,
    private service: OwnerService,
    private tokenService: TokenService,
  ) { }

  ngOnInit(): void {

    if (this.tokenService.isLoggedIn() && this.tokenService.getUserType() == "owner") {
      this.router.navigateByUrl("owner-layout")
    }
  }


  loginOwnerForm = new FormGroup({

    phone: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl("", [Validators.required, Validators.minLength(8), Validators.maxLength(8)])
  });


  onSubmit() {
    this.service.Login({
      phone: this.loginOwnerForm.controls.phone.value!,
      password: this.loginOwnerForm.controls.password.value!
    }).subscribe({
      next: x => {
        this.tokenService.setToken(x.toString());
        this.router.navigateByUrl("owner-layout")
      },
      error: x => console.log("login error")
    });

  }



}
