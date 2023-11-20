
import { Component, OnInit } from '@angular/core';
import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';
import { MatDialog } from '@angular/material/dialog';
import { OwnerAppointmentDetailsComponent } from '../owner-appointment-details/owner-appointment-details.component';

@Component({
  selector: 'app-owner.get-all-appointments',
  templateUrl: './owner.get-all-appointments.component.html',
  styleUrls: ['./owner.get-all-appointments.component.css']
})
export class OwnerGetAllAppointmentsComponent implements OnInit{

  listOfAppointments: ReadAppointmentModel[] = [];


  constructor(private service : OwnerService, private tokenService: TokenService, 
                  private matDialog: MatDialog) {}

  ngOnInit(): void {
    this.service.getAppointments(this.tokenService.getId()).subscribe({
      next: x => this.listOfAppointments = x
    });
  }

  getById(id: number) {

    this.matDialog.open(OwnerAppointmentDetailsComponent, 
                  {data: {appointment: this.listOfAppointments.find(x => x.id == 1005)}})
  }


}
