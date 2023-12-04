import { NotificationService } from 'src/app/services/notification.service';

import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { TokenService } from 'src/app/services/token.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})
export class AppointmentDetailsComponent implements OnInit {

  appointmentId!: number;
  appointmentDetails!: ReadAppointmentModel;


  constructor(
    private service: AppointmentService,
    private tokenService: TokenService,
    private router: Router,
    private notificationService: NotificationService
  ) {

    this.appointmentId = parseInt(router.getCurrentNavigation()!.extras.state!['id']);


  }

  ngOnInit() {
    this.service.getById(this.appointmentId)
      .subscribe({
        next: x => {
          this.appointmentDetails = x;
          this.notificationService.show("Appointment Details Fetching Successful");
        },
        // error: x => {
        //   this.notificationService.show(x.error)
        // }
      });
  }

  public isLoggedIn(): boolean {
    return this.tokenService.isLoggedIn();
  }

  public isOwner(): boolean {
    return this.tokenService.getUserType() == "owner";
  }

  public isGarage(): boolean {
    return this.tokenService.getUserType() == "garage";
  }




}
