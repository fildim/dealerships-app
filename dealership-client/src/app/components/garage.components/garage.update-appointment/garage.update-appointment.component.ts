import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { AppointmentService } from 'src/app/services/appointment.service';
import { GarageService } from 'src/app/services/garage.service';
import { NotificationService } from 'src/app/services/notification.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-garage.update-appointment',
  templateUrl: './garage.update-appointment.component.html',
  styleUrls: ['./garage.update-appointment.component.css']
})
export class GarageUpdateAppointmentComponent {

  appointmentId!: number;
  appointmentDetails!: ReadAppointmentModel;
  minDate!: Date;

  constructor(
    private appointmentService: AppointmentService,
    private garageService: GarageService,

    private tokenService: TokenService,
    private router: Router,
    private notificationService: NotificationService
  ) {

    this.appointmentId = parseInt(router.getCurrentNavigation()!.extras.state!['id']);

  }

  ngOnInit() {

    this.appointmentService.getById(this.appointmentId)
      .subscribe({
        next: x => {
          this.appointmentDetails = x;
          this.notificationService.show("Appointment Details Fetching Successful");
          this.updateAppointmentForm.controls.crashed.setValue(this.appointmentDetails.vehicle.crashed);
        },
        error: x => {
          this.notificationService.show(x.error)
        }
      });

    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);



  }

  updateAppointmentForm = new FormGroup({

    mileage: new FormControl(0, [Validators.required]),
    diagnosis: new FormControl("", [Validators.required]),
    dateOfPickup: new FormControl("", [Validators.required]),
    crashed: new FormControl(false, [Validators.required]),
  });

  onSubmit() {

    this.appointmentDetails.mileage = this.updateAppointmentForm.controls.mileage.value!;
    this.appointmentDetails.diagnosis = this.updateAppointmentForm.controls.diagnosis.value!
    // if (this.updateAppointmentForm.controls.crashed == null) 
    this.appointmentDetails.dateOfPickup = new Date(this.updateAppointmentForm.controls.dateOfPickup.value!);


    this.garageService.Update(this.appointmentDetails)
      .subscribe({
        next: x => {
          this.router.navigateByUrl('/garage-all-appointments');
          this.notificationService.show("Appointment Updated Successfully")
        },
        error: x => this.notificationService.show(x.error)
      });
  }




}
