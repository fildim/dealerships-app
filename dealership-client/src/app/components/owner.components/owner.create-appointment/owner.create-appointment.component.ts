import { CreateAppointmentModel } from './../../../models/appointment/create.appointment.model';
import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'app-owner.create-appointment',
  templateUrl: './owner.create-appointment.component.html',
  styleUrls: ['./owner.create-appointment.component.css']
})
export class OwnerCreateAppointmentComponent {

  constructor(private appointmentService : AppointmentService, private jwtHelper: JwtHelperService) {}

  

  onSubmit() {
    let var1 = this.jwtHelper.decodeToken(localStorage.getItem("jwt")!)!;
    let var2 = var1['userId'];

    this.appointmentService.create({
      ownerId: parseInt(var2),
      vehicleId: 2,
      garageId: 2,
      dateOfArrival: new Date()
    }).subscribe({
      next: x => console.log('success')
    });
  }

}

