import { Component, OnInit } from '@angular/core';
import { ReadVehicleModel } from 'src/app/models/vehicle/read.vehicle.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner.get-all-binded-vehicles',
  templateUrl: './owner.get-all-binded-vehicles.component.html',
  styleUrls: ['./owner.get-all-binded-vehicles.component.css']
})
export class OwnerGetAllBindedVehiclesComponent implements OnInit {

  listOfVehicles: ReadVehicleModel[] = [];

  constructor(private service: OwnerService, private tokenService: TokenService) {}
  ngOnInit(): void {
    this.service.getBindedVehicles(this.tokenService.getId()).subscribe({
      next: x => this.listOfVehicles = x
    });
  }



}
