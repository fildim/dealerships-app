
import { Component, OnInit, ViewChild } from '@angular/core';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { OwnerAppointmentDetailsComponent } from '../owner-appointment-details/owner-appointment-details.component';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-owner.get-all-appointments',
  templateUrl: './owner.get-all-appointments.component.html',
  styleUrls: ['./owner.get-all-appointments.component.css']
})
export class OwnerGetAllAppointmentsComponent implements OnInit {


  @ViewChild(MatSort) sort!: MatSort;

  listOfAppointments: ReadAppointmentModel[] = [];

  dataSource!: MatTableDataSource<ReadAppointmentModel>;

  displayedColumns: string[] = [
    'vehicle',
    'garage',
    'dateOfArrival'
  ];


  constructor(
    private service: OwnerService,
    private tokenService: TokenService,
    private matDialog: MatDialog,
  ) { }



  ngOnInit(): void {
    this.service.getAppointments(this.tokenService.getId()).subscribe((listOfAppointments) => {
      this.listOfAppointments = listOfAppointments;

      this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.listOfAppointments);
      this.dataSource.sort = this.sort;
    });
  }

  getById(id: number) {

    this.matDialog.open(
      OwnerAppointmentDetailsComponent,
      {
        data:
          { appointment: this.listOfAppointments.find(x => x.id == 1005) }
      }
    )
  }


}
