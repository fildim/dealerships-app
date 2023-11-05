import { ReadOwnerModel } from './models/owner/read.owner.model';
import { OwnerService } from './services/owner.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'dealership-client';
  owner? : ReadOwnerModel;

  constructor(private ownerService: OwnerService) {
    ownerService.create({firstname: "fsdf", lastname: "fsfds", phone: "2432"}).subscribe();
  }

  ngOnInit(): void {
    this.ownerService.getById(1).subscribe(x => this.owner = x);
  }
}
