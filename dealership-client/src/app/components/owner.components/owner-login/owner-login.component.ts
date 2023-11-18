import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-owner-login',
  templateUrl: './owner-login.component.html',
  styleUrls: ['./owner-login.component.css'],
})
export class OwnerLoginComponent {

  constructor(private router : Router) {}
  loginOwnerForm = new FormGroup ({

  });
  onSubmit() {
    // throw new Error('Method not implemented.');
    // login
    this.router.navigateByUrl("owner-layout");
  }



}
