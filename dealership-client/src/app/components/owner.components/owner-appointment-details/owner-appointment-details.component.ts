import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-owner-appointment-details',
  templateUrl: './owner-appointment-details.component.html',
  styleUrls: ['./owner-appointment-details.component.css']
})
export class OwnerAppointmentDetailsComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public appointment: ReadAppointmentModel) {
    
  }

}
