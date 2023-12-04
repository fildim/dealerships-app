
import { Component, OnInit, ViewChild } from '@angular/core';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-owner.get-all-appointments',
  templateUrl: './owner.get-all-appointments.component.html',
  styleUrls: ['./owner.get-all-appointments.component.css']
})
export class OwnerGetAllAppointmentsComponent implements OnInit {


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
    private router: Router,
    private notificationService: NotificationService,
  ) { }

  ngOnInit() {

    this.service.getAppointments(this.tokenService.getId())
      .subscribe({
        next: (listOfAppointments) => {
          this.listOfAppointments = listOfAppointments;

          this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.listOfAppointments);
          this.dataSource.sortingDataAccessor = (obj, property) => {
            switch (property) {
              case "vehicle": return obj.vehicle.model;
              case "garage": return obj.garage.name;
              case "dateOfArrival": return obj.dateOfArrival.toString();
              default: return obj.vehicle.model;
            }
          };
          this.dataSource.sort = this.sort;

          this.notificationService.show("All Appointments Fetching Successful")
        },
        error: x => this.notificationService.show(x.error)
      });

  }


  sendId(id: number) {

    this.router.navigateByUrl("/appointment-details", { state: { id: id } });
  }



}
