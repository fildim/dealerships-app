import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ReadVehicleModel } from 'src/app/models/vehicle/read.vehicle.model';
import { OwnerService } from 'src/app/services/owner.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-owner.get-all-binded-vehicles',
  templateUrl: './owner.get-all-binded-vehicles.component.html',
  styleUrls: ['./owner.get-all-binded-vehicles.component.css']
})
export class OwnerGetAllBindedVehiclesComponent implements OnInit {


  @ViewChild(MatSort) sort!: MatSort;

  listOfVehicles: ReadVehicleModel[] = [];

  dataSource!: MatTableDataSource<ReadVehicleModel>;

  displayedColumns: string[] = [
    'vin',
    'model',
    'dateOfManufacture',
    'mileage',
    'crashed'
  ];

  constructor(
    private service: OwnerService,
    private tokenService: TokenService,
    private matDialog: MatDialog,

    private _liveAnnouncer: LiveAnnouncer
  ) { }


  ngOnInit(): void {
    this.service.getBindedVehicles(this.tokenService.getId()).subscribe({
      next: bindedVehicles => {
        this.listOfVehicles = bindedVehicles;

        this.dataSource = new MatTableDataSource<ReadVehicleModel>(this.listOfVehicles);
        this.dataSource.sort = this.sort;
      }
    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }


  announceSortChange(sortState: Sort) {

    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }



}
