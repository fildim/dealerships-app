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
    private tokenService: TokenService
  ) { }

  RegisterGarageForm = new FormGroup({

    name: new FormControl([Validators.required, Validators.minLength(50), Validators.maxLength(50)]),
    address: new FormControl([Validators.required, Validators.minLength(50), Validators.maxLength(50)]),
    phone: new FormControl([Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    password: new FormControl([Validators.required, Validators.maxLength(8)])
  });

  onSubmit() {
    this.service.create({
      name: '',
      address: '',
      phone: '',
      password: ''
    })
      .subscribe({
        next: x => this.service.Login({
          password: "12345678",
          phone: "1234565555"
        }).subscribe({
          next: x => {
            this.tokenService.setToken(x.toString());
            this.router.navigateByUrl("owner-layout")
          },
          error: x => console.log("login error")
        })
      });
  }


}
