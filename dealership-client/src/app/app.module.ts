import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { OwnerService } from './services/owner.service';
import { GarageService } from './services/garage.service';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';
import { RegisterComponent } from './components/utilities/register/register.component';
import { LoginComponent } from './components/utilities/login/login.component';
import { OwnerGetAllBindedVehiclesComponent } from './components/owner.components/owner.get-all-binded-vehicles/owner.get-all-binded-vehicles.component';
import { OwnerGetAllAppointmentsComponent } from './components/owner.components/owner.get-all-appointments/owner.get-all-appointments.component';
import { GetAppointmentByIdComponent } from './components/utilities/get-appointment-by-id/get-appointment-by-id.component';
import { OwnerInitialBindVehicleComponent } from './components/owner.components/owner.initial-bind-vehicle/owner.initial-bind-vehicle.component';
import { OwnerCreateAppointmentComponent } from './components/owner.components/owner.create-appointment/owner.create-appointment.component';
import { OwnerApplicationLayoutComponent } from './components/owner.components/owner.application-layout/owner.application-layout.component';
import { OwnerGetAllGaragesComponent } from './components/owner.components/owner.get-all-garages/owner.get-all-garages.component';
import { GarageUpdateAppointmentComponent } from './components/garage.components/garage.update-appointment/garage.update-appointment.component';
import { GarageGetAllAppointmentsComponent } from './components/garage.components/garage.get-all-appointments/garage.get-all-appointments.component';
import { GarageApplicationLayoutComponent } from './components/garage.components/garage.application-layout/garage.application-layout.component';
import { OwnerLoginComponent } from './components/owner.components/owner-login/owner-login.component';
import { GarageLoginComponent } from './components/garage.components/garage-login/garage-login.component';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    OwnerGetAllBindedVehiclesComponent,
    OwnerGetAllAppointmentsComponent,
    GetAppointmentByIdComponent,
    OwnerInitialBindVehicleComponent,
    OwnerCreateAppointmentComponent,
    OwnerApplicationLayoutComponent,
    OwnerGetAllGaragesComponent,
    GarageUpdateAppointmentComponent,
    GarageGetAllAppointmentsComponent,
    GarageApplicationLayoutComponent,
    GarageLoginComponent,
    OwnerLoginComponent,
    WelcomePageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    RouterModule.forRoot(routes),
    MatFormFieldModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatExpansionModule
  ],
  providers: [
    OwnerService,
    GarageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
