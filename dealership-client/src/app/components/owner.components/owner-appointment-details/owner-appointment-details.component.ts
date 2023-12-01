import { NotificationService } from 'src/app/services/notification.service';

import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AppointmentService } from 'src/app/services/appointment.service';
import { TokenService } from 'src/app/services/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-owner-appointment-details',
  templateUrl: './owner-appointment-details.component.html',
  styleUrls: ['./owner-appointment-details.component.css']
})
export class OwnerAppointmentDetailsComponent {


  appointmentDetails!: ReadAppointmentModel;


  constructor(
    private service: AppointmentService,
    private tokenService: TokenService,
    private router: Router,
    private notificationService: NotificationService
  ) {

    var appointmentId: number = parseInt(router.getCurrentNavigation()!.extras.state!['id']);

    this.service.getById(appointmentId)
      .subscribe({
        next: x => {
          this.appointmentDetails = x;
          this.appointmentDetails.created = new Date(x.created.getDate() + x.created.getMonth() + x.created.getFullYear());
          this.notificationService.show("Appointment Details Fetching Successful")
        },
        error: x => {
          this.notificationService.show(x.error)
        }
      });

  }


}
