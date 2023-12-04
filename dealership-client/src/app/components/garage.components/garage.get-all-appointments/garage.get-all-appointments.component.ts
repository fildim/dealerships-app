import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { GarageService } from 'src/app/services/garage.service';
import { NotificationService } from 'src/app/services/notification.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-garage.get-all-appointments',
  templateUrl: './garage.get-all-appointments.component.html',
  styleUrls: ['./garage.get-all-appointments.component.css']
})
export class GarageGetAllAppointmentsComponent implements OnInit {


  @ViewChild(MatSort) sort!: MatSort;

  listOfAppointments: ReadAppointmentModel[] = [];

  dataSource!: MatTableDataSource<ReadAppointmentModel>;

  displayedColumns: string[] = [
    'vehicle',
    'owner',
    'dateOfArrival',
    'details',
    'update'
  ];

  constructor(
    private service: GarageService,
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
              case "owner": return obj.owner.lastname;
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

  sendIdToUpdate(id: number) {

    this.router.navigateByUrl("/garage-update-appointment", { state: { id: id } });
  }







}
