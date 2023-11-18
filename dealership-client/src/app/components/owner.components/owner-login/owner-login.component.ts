import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormGroup } from '@angular/forms';
import { OwnerService } from 'src/app/services/owner.service';

@Component({
  selector: 'app-owner-login',
  templateUrl: './owner-login.component.html',
  styleUrls: ['./owner-login.component.css'],
})
export class OwnerLoginComponent {

  constructor(private router : Router, private service : OwnerService) {}
  loginOwnerForm = new FormGroup ({

  });
  onSubmit() {
    this.service.Login({
      phone: "1234567890",
      password: "12312312"
    }).subscribe({
      next: x => { 
        localStorage.setItem("jwt", x.toString());
        this.router.navigateByUrl("owner-layout")},
      error: x => console.log("login error")
    });

    
    
    
  }



}
