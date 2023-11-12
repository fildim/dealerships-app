import { FormGroup, FormControl } from '@angular/forms';
import { OwnerService } from './services/owner.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  createOwnerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    phone: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private ownerService: OwnerService) {
  }

  public onSubmit(): void {
    debugger;
    let firstName = this.createOwnerForm.get('firstName')?.value!;
    let lastName = this.createOwnerForm.get('lastName')?.value!;
    let phone = this.createOwnerForm.get('phone')?.value!;
    let password = this.createOwnerForm.get('password')?.value!;

    this.ownerService.create({ firstname: firstName, lastname: lastName, phone: phone, password: password }).subscribe();
  }
}
