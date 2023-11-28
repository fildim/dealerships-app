import { FormGroup, FormControl } from '@angular/forms';
import { OwnerService } from './services/owner.service';
import { Component } from '@angular/core';
import { Observable, map, shareReplay } from 'rxjs';
import { Breakpoints } from '@angular/cdk/layout';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
}
