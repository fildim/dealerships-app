
import { Component, ViewChild } from '@angular/core';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';

@Component({
  selector: 'app-owner.get-all-appointments',
  templateUrl: './owner.get-all-appointments.component.html',
  styleUrls: ['./owner.get-all-appointments.component.css']
})
export class OwnerGetAllAppointmentsComponent {


  @ViewChild(MatSort) sort: MatSort = new MatSort();

  listOfAppointments: ReadAppointmentModel[] = [];

  dataSource!: MatTableDataSource<ReadAppointmentModel>;

  displayedColumns: string[] = [
    'vehicle',
    'garage',
    'dateOfArrival',
    'details'
  ];


  constructor(
    private service: OwnerService,
    private tokenService: TokenService,
    private router: Router
  ) {
    this.service.getAppointments(this.tokenService.getId()).subscribe((listOfAppointments) => {
      this.listOfAppointments = listOfAppointments;

      this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.listOfAppointments);
      this.dataSource.sort = this.sort;
    });
  }


  sendId(id: number) {

    this.router.navigateByUrl("/owner-appointment-details", { state: { id: id } });
  }




}
