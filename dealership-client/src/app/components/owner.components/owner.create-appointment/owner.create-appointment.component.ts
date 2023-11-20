
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from 'src/app/services/appointment.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner.create-appointment',
  templateUrl: './owner.create-appointment.component.html',
  styleUrls: ['./owner.create-appointment.component.css']
})
export class OwnerCreateAppointmentComponent {

  constructor(private appointmentService : AppointmentService, private router : Router, 
                      private tokenService: TokenService) {}

  

  onSubmit() {
    let ownerId = this.tokenService.getId();

    this.appointmentService.create({
      ownerId: ownerId,
      vehicleId: 2,
      garageId: 2,
      dateOfArrival: new Date()
    }).subscribe({
      next: x => this.router.navigateByUrl('/owner-all-appointments')
    });
  }

}

