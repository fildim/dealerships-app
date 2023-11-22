import { ReadVehicleModel } from './../../../models/vehicle/read.vehicle.model';

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReadGarageModel } from 'src/app/models/garage/read.garage.model';
import { AppointmentService } from 'src/app/services/appointment.service';
import { GarageService } from 'src/app/services/garage.service';
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
    private tokenService: TokenService
  ) {

    this.minDate = new Date(new Date().getDay() + 1);
  }


  ngOnInit(): void {

    this.ownerService.getBindedVehicles(this.tokenService.getId()).subscribe(
      (listofVehicles: ReadVehicleModel[]) => this.vehicleControl = listofVehicles
    );

    this.garageService.getAll().subscribe(
      (listOfGarages: ReadGarageModel[]) => this.garageControl = listOfGarages
    );

  }







  createAppointmentForm = new FormGroup({

    ownerId: new FormControl([Validators.required]),
    vehicleId: new FormControl([Validators.required]),
    garageId: new FormControl([Validators.required]),
    dateOfArrival: new FormControl(new Date(), [Validators.required])
  });






  onSubmit() {
    let ownerId = this.tokenService.getId();

    this.appointmentService.create({
      ownerId: ownerId,
      vehicleId: ,
      garageId: this.garageControl[0].id,
      dateOfArrival: 
    }).subscribe({
        next: x => this.router.navigateByUrl('/owner-all-appointments')
      });
  }

}

