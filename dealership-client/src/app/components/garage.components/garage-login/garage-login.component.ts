import { NotificationService } from 'src/app/services/notification.service';
import { Component, OnInit } from '@angular/core';
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
export class GarageLoginComponent implements OnInit {


  constructor(
    private router: Router,
    private service: GarageService,
    private tokenService: TokenService,
    private notificationService: NotificationService
  ) { }

  ngOnInit(): void {

    if (this.tokenService.isLoggedIn() && this.tokenService.getUserType() == "garage") {
      this.router.navigateByUrl("garage-layout")
    }
  }


  LoginGarageForm = new FormGroup({

    phone: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl("", [Validators.required, Validators.minLength(8), Validators.maxLength(8)])
  });


  onSubmit() {
    this.service.Login({
      phone: this.LoginGarageForm.controls.phone.value!,
      password: this.LoginGarageForm.controls.password.value!
    }).subscribe({
      next: x => {
        this.tokenService.setToken(x.toString());
        this.router.navigateByUrl("garage-layout");
        this.notificationService.show("Login Successful")
      },
      error: x => this.notificationService.show(x.error)
    });

  }

}
