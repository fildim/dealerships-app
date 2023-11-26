
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


  @ViewChild(MatSort) sort: MatSort = new MatSort();

  appointmentDetails!: ReadAppointmentModel;

  dataSource!: MatTableDataSource<ReadAppointmentModel>;

  displayedColumns: string[] = [
    'vehicle',
    'garage',
    'dateOfArrival',
    'mileage',
    'diagnosis',
    'dateOfPickup',
    'created'
  ];


  constructor(
    private service: AppointmentService,
    private tokenService: TokenService,
    private router: Router,
  ) {

    var appointmentId: number = parseInt(router.getCurrentNavigation()!.extras.state!['id']);

    this.service.getById(appointmentId).subscribe({
      next: x => this.appointmentDetails = x
    });

    // this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.appointmentDetails);
    // this.dataSource.sort = this.sort;
  }


}
