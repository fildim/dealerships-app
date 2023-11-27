import { NotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { TokenService } from 'src/app/services/token.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GarageService } from 'src/app/services/garage.service';

@Component({
  selector: 'app-garage-register',
  templateUrl: './garage-register.component.html',
  styleUrls: ['./garage-register.component.css']
})
export class GarageRegisterComponent {


  constructor(
    private service: GarageService,
    private router: Router,
    private tokenService: TokenService,
    private notificationService: NotificationService
  ) { }

  RegisterGarageForm = new FormGroup({

    name: new FormControl("", [Validators.required, Validators.maxLength(50)]),
    address: new FormControl("", [Validators.required, Validators.maxLength(50)]),
    phone: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl("", [Validators.required, Validators.minLength(8), Validators.maxLength(8)])
  });

  onSubmit() {
    this.service.create({
      name: this.RegisterGarageForm.controls.name.value!,
      address: this.RegisterGarageForm.controls.address.value!,
      phone: this.RegisterGarageForm.controls.phone.value!,
      password: this.RegisterGarageForm.controls.password.value!
    })
      .subscribe({
        next: x => {
          this.service.Login({
            phone: this.RegisterGarageForm.controls.phone.value!,
            password: this.RegisterGarageForm.controls.password.value!
          }).subscribe({
            next: x => {
              this.tokenService.setToken(x.toString());
              this.router.navigateByUrl("garage-layout")
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
