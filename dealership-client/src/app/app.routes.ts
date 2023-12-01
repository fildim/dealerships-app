import { Routes } from "@angular/router";
import { OwnerLoginComponent } from "./components/owner.components/owner-login/owner-login.component";
import { GarageLoginComponent } from "./components/garage.components/garage-login/garage-login.component";
import { WelcomePageComponent } from "./components/welcome-page/welcome-page.component";
import { OwnerRegisterComponent } from "./components/owner.components/owner-register/owner-register.component";
import { OwnerCreateAppointmentComponent } from "./components/owner.components/owner.create-appointment/owner.create-appointment.component";
import { OwnerGetAllAppointmentsComponent } from "./components/owner.components/owner.get-all-appointments/owner.get-all-appointments.component";
import { OwnerGetAllBindedVehiclesComponent } from "./components/owner.components/owner.get-all-binded-vehicles/owner.get-all-binded-vehicles.component";
import { OwnerInitialBindVehicleComponent } from "./components/owner.components/owner.initial-bind-vehicle/owner.initial-bind-vehicle.component";
import { GarageGetAllAppointmentsComponent } from "./components/garage.components/garage.get-all-appointments/garage.get-all-appointments.component";
import { GarageRegisterComponent } from "./components/garage.components/garage-register/garage-register.component";
import { GarageUpdateAppointmentComponent } from "./components/garage.components/garage.update-appointment/garage.update-appointment.component";
import { OwnerAppointmentDetailsComponent } from "./components/owner.components/owner-appointment-details/owner-appointment-details.component";
import { CanActivateGuard } from "./guards/canActivate.guard";
import { OwnerGuard } from "./guards/owner.guard";
import { NotFoundComponent } from "./components/not-found/not-found.component";
import { GarageGuard } from "./guards/garage.guard";
import { AppointmentDetailsComponent } from "./appointment-details/appointment-details.component";

export const routes: Routes = [
  { path: '', component: WelcomePageComponent },
  { path: "owner-login", component: OwnerLoginComponent },
  { path: "owner-register", component: OwnerRegisterComponent },
  { path: "owner-create-appointment", component: OwnerCreateAppointmentComponent, canActivate: [CanActivateGuard, OwnerGuard] },
  { path: "owner-all-appointments", component: OwnerGetAllAppointmentsComponent, canActivate: [CanActivateGuard, OwnerGuard] },
  { path: "owner-all-binded-vehicles", component: OwnerGetAllBindedVehiclesComponent, canActivate: [CanActivateGuard, OwnerGuard] },
  { path: "owner-bind-vehicle", component: OwnerInitialBindVehicleComponent, canActivate: [CanActivateGuard, OwnerGuard] },
  { path: "owner-appointment-details", component: OwnerAppointmentDetailsComponent, canActivate: [CanActivateGuard, OwnerGuard] },
  { path: "garage-all-appointments", component: GarageGetAllAppointmentsComponent, canActivate: [CanActivateGuard, GarageGuard] },
  { path: "garage-register", component: GarageRegisterComponent },
  { path: "garage-login", component: GarageLoginComponent },
  { path: "garage-update-appointment", component: GarageUpdateAppointmentComponent, canActivate: [CanActivateGuard, GarageGuard] },
  { path: "not-found", component: NotFoundComponent },
  { path: "appointment-details", component: AppointmentDetailsComponent, canActivate: [CanActivateGuard] },



]
