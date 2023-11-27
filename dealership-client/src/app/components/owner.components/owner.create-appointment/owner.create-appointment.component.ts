import { ReadVehicleModel } from './../../../models/vehicle/read.vehicle.model';

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReadGarageModel } from 'src/app/models/garage/read.garage.model';
import { AppointmentService } from 'src/app/services/appointment.service';
import { GarageService } from 'src/app/services/garage.service';
import { NotificationService } from 'src/app/services/notification.service';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner.create-appointment',
  templateUrl: './owner.create-appointment.component.html',
  styleUrls: ['./owner.create-appointment.component.css']
})
export class OwnerCreateAppointmentComponent implements OnInit {

  minDate!: Date;

  vehicleControl: ReadVehicleModel[] = [];
  garageControl: ReadGarageModel[] = [];

  constructor(
    private appointmentService: AppointmentService,
    private ownerService: OwnerService,
    private garageService: GarageService,
    private router: Router,
    private tokenService: TokenService,
    private notificationService: NotificationService
  ) {

    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);

  }


  ngOnInit(): void {

    this.ownerService.getBindedVehicles(this.tokenService.getId())
      .subscribe({
        next: (listofVehicles: ReadVehicleModel[]) => {
          this.vehicleControl = listofVehicles;
          // this.notificationService.show("Vehicle Bind Successful")
        },
        error: x => this.notificationService.show(x.error)
      });

    this.garageService.getAll()
      .subscribe({
        next: (listOfGarages: ReadGarageModel[]) => {
          this.garageControl = listOfGarages;
          // this.notificationService.show("All Garages Fetching Successful")
        },
        error: x => this.notificationService.show(x.error)
      });

  }

  createAppointmentForm = new FormGroup({

    vehicleId: new FormControl("", [Validators.required]),
    garageId: new FormControl("", [Validators.required]),
    dateOfArrival: new FormControl("", [Validators.required])
  });


  onSubmit() {
    let ownerId = this.tokenService.getId();

    this.appointmentService.create({
      ownerId: ownerId,
      vehicleId: parseInt(this.createAppointmentForm.controls.vehicleId.value!),
      garageId: parseInt(this.createAppointmentForm.controls.garageId.value!),
      dateOfArrival: new Date(this.createAppointmentForm.controls.dateOfArrival.value!)
    })
      .subscribe({
        next: x => {
          this.router.navigateByUrl('/owner-all-appointments');
          this.notificationService.show("Appointment Created Successfully")
        },
        error: x => this.notificationService.show(x.error)
      });
  }

}

