import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-owner-appointment-details',
  templateUrl: './owner-appointment-details.component.html',
  styleUrls: ['./owner-appointment-details.component.css']
})
export class OwnerAppointmentDetailsComponent {

  @ViewChild(MatSort) sort!: MatSort;

  appointmentTable!: ReadAppointmentModel;

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
    @Inject(MAT_DIALOG_DATA) public appointment: ReadAppointmentModel,
    private matDialog: MatDialog,
  ) { }






}
