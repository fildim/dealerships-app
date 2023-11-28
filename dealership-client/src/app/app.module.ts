import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { OwnerService } from './services/owner.service';
import { GarageService } from './services/garage.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';
import { OwnerGetAllBindedVehiclesComponent } from './components/owner.components/owner.get-all-binded-vehicles/owner.get-all-binded-vehicles.component';
import { OwnerGetAllAppointmentsComponent } from './components/owner.components/owner.get-all-appointments/owner.get-all-appointments.component';
import { OwnerInitialBindVehicleComponent } from './components/owner.components/owner.initial-bind-vehicle/owner.initial-bind-vehicle.component';
import { OwnerCreateAppointmentComponent } from './components/owner.components/owner.create-appointment/owner.create-appointment.component';
import { GarageUpdateAppointmentComponent } from './components/garage.components/garage.update-appointment/garage.update-appointment.component';
import { GarageGetAllAppointmentsComponent } from './components/garage.components/garage.get-all-appointments/garage.get-all-appointments.component';
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
import { OwnerRegisterComponent } from './components/owner.components/owner-register/owner-register.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AppointmentService } from './services/appointment.service';
import { TokenService, tokenGetter } from './services/token.service';
import { OwnerAppointmentDetailsComponent } from './components/owner.components/owner-appointment-details/owner-appointment-details.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableModule } from '@angular/material/table';
import { GarageRegisterComponent } from './components/garage.components/garage-register/garage-register.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NotificationService } from './services/notification.service';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { LayoutComponent } from './components/layout/layout.component';
import { CanActivateGuard } from './guards/canActivate.guard';
import { OwnerGuard } from './guards/owner.guard';
import { NotFoundComponent } from './components/not-found/not-found.component';



@NgModule({
  declarations: [
    AppComponent,
    OwnerGetAllBindedVehiclesComponent,
    OwnerGetAllAppointmentsComponent,
    OwnerInitialBindVehicleComponent,
    OwnerCreateAppointmentComponent,
    GarageUpdateAppointmentComponent,
    GarageGetAllAppointmentsComponent,
    GarageLoginComponent,
    OwnerLoginComponent,
    WelcomePageComponent,
    OwnerRegisterComponent,
    OwnerAppointmentDetailsComponent,
    GarageRegisterComponent,
    LayoutComponent,
    NotFoundComponent
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
    MatExpansionModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5161"],
        disallowedRoutes: []
      }
    }),
    MatDialogModule,
    MatInputModule,
    FormsModule,
    MatToolbarModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDatepickerModule,
    MatTableModule,
    MatNativeDateModule,
    MatSortModule,
    MatSnackBarModule,
    MatCheckboxModule
  ],
  providers: [
    OwnerService,
    GarageService,
    AppointmentService,
    TokenService,
    NotificationService,
    CanActivateGuard,
    OwnerGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


