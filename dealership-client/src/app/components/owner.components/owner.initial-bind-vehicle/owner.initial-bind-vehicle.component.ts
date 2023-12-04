import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ReadVehicleModel } from 'src/app/models/vehicle/read.vehicle.model';
import { NotificationService } from 'src/app/services/notification.service';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner.initial-bind-vehicle',
  templateUrl: './owner.initial-bind-vehicle.component.html',
  styleUrls: ['./owner.initial-bind-vehicle.component.css']
})
export class OwnerInitialBindVehicleComponent implements OnInit {
  @ViewChild(MatSort) sort: MatSort = new MatSort();

  unbindedVehicles: ReadVehicleModel[] = [];

  dataSource!: MatTableDataSource<ReadVehicleModel>;

  displayedColumns: string[] = [
    'vin',
    'bind'
  ];

  constructor(
    private service: OwnerService,
    private tokenService: TokenService,
    private router: Router,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {

    this.service.getUnbindedVehicles()
      .subscribe({
        next: x => {
          this.unbindedVehicles = x;

          this.dataSource = new MatTableDataSource<ReadVehicleModel>(this.unbindedVehicles);
          this.dataSource.sort = this.sort;

          this.notificationService.show("All Unbinded Vehicles Fetching Successful")
        },
        error: x => this.notificationService.show(x.error)
      });

  }



  bind(id: number) {
    let ownerId = this.tokenService.getId();

    this.service.initialBindVehicle(ownerId, id)
      .subscribe({
        next: x => {
          this.router.navigateByUrl("owner-all-binded-vehicles");
          this.notificationService.show("Vehicle Bindind Successful")
        },
        error: x => this.notificationService.show(x.error)
      });
  }
}
