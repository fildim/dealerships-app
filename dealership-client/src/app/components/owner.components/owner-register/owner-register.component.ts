import { Router } from '@angular/router';
import { OwnerService } from './../../../services/owner.service';
import { Component } from '@angular/core';
import { TokenService } from 'src/app/services/token.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent {

  constructor(
    private service: OwnerService,
    private router: Router,
    private tokenService: TokenService,

    private notificationService: NotificationService
  ) { }

  RegisterOwnerForm = new FormGroup({

    firstname: new FormControl("", [Validators.required, Validators.maxLength(50)]),
    lastname: new FormControl("", [Validators.required, Validators.maxLength(50)]),
    phone: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl("", [Validators.required, Validators.minLength(8), Validators.maxLength(8)])
  });

  onSubmit() {
    this.service.create({
      firstname: this.RegisterOwnerForm.controls.firstname.value!,
      lastname: this.RegisterOwnerForm.controls.lastname.value!,
      password: this.RegisterOwnerForm.controls.password.value!,
      phone: this.RegisterOwnerForm.controls.phone.value!
    })
      .subscribe({
        next: x => {
          this.service.Login({
            phone: this.RegisterOwnerForm.controls.phone.value!,
            password: this.RegisterOwnerForm.controls.password.value!,
          }).subscribe({
            next: x => {
              this.tokenService.setToken(x.toString());
              this.router.navigateByUrl("owner-layout");
              this.notificationService.show("Login Successful")
            },
            error: x => this.notificationService.show("Login Unsuccessful")
          });
          this.notificationService.show("Register Successful")
        },
        error: x => this.notificationService.show("Register Unsuccessful")
      });
  }

}
