import { Router } from '@angular/router';
import { OwnerService } from './../../../services/owner.service';
import { Component } from '@angular/core';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent {

  constructor(private service:  OwnerService, private router: Router, private tokenService: TokenService) {}

  onSubmit() {
    this.service.create({
      firstname: "fili",
      lastname: "dimi",
      password: "12345678",
      phone: "1234565555" 
    })
    .subscribe({
      next: x => this.service.Login({
        password: "12345678",
        phone: "1234565555" 
      }).subscribe({
        next: x => { 
          this.tokenService.setToken(x.toString());
          this.router.navigateByUrl("owner-layout")},
        error: x => console.log("login error")
      })
    });
  }

}
