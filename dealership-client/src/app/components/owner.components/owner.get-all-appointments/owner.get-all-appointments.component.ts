
import { Component, OnInit, ViewChild } from '@angular/core';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { OwnerAppointmentDetailsComponent } from '../owner-appointment-details/owner-appointment-details.component';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';

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
    private matDialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {
    this.service.getAppointments(this.tokenService.getId()).subscribe((listOfAppointments) => {
      this.listOfAppointments = listOfAppointments;

      this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.listOfAppointments);
      this.dataSource.sort = this.sort;
    });
   }



  // ngOnInit(): void {
  //   this.service.getAppointments(this.tokenService.getId()).subscribe((listOfAppointments) => {
  //     this.listOfAppointments = listOfAppointments;

  //     this.dataSource = new MatTableDataSource<ReadAppointmentModel>(this.listOfAppointments);
  //     this.dataSource.sort = this.sort;
  //   });
  // }

  getById(id: number) {

    this.matDialog.open(
      OwnerAppointmentDetailsComponent,
      {
        data:
          { appointment: this.listOfAppointments.find(x => x.id == 1005) }
      }
    )
  }


  // ngAfterViewInit() {
  //   this.dataSource.sort = this.sort;
  // }


  announceSortChange(sortState: Sort) {

    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }


}
