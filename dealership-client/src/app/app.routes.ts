import { Routes } from "@angular/router";
import { OwnerLoginComponent } from "./components/owner.components/owner-login/owner-login.component";
import { GarageLoginComponent } from "./components/garage.components/garage-login/garage-login.component";
import { WelcomePageComponent } from "./components/welcome-page/welcome-page.component";
import { OwnerApplicationLayoutComponent } from "./components/owner.components/owner.application-layout/owner.application-layout.component";
import { OwnerRegisterComponent } from "./components/owner.components/owner-register/owner-register.component";
import { OwnerCreateAppointmentComponent } from "./components/owner.components/owner.create-appointment/owner.create-appointment.component";
import { OwnerGetAllAppointmentsComponent } from "./components/owner.components/owner.get-all-appointments/owner.get-all-appointments.component";
import { OwnerGetAllBindedVehiclesComponent } from "./components/owner.components/owner.get-all-binded-vehicles/owner.get-all-binded-vehicles.component";
import { OwnerInitialBindVehicleComponent } from "./components/owner.components/owner.initial-bind-vehicle/owner.initial-bind-vehicle.component";
import { GarageGetAllAppointmentsComponent } from "./components/garage.components/garage.get-all-appointments/garage.get-all-appointments.component";
import { GarageRegisterComponent } from "./components/garage.components/garage-register/garage-register.component";
import { GarageApplicationLayoutComponent } from "./components/garage.components/garage.application-layout/garage.application-layout.component";
import { GarageUpdateAppointmentComponent } from "./components/garage.components/garage.update-appointment/garage.update-appointment.component";
import { GarageUpdateVehicleComponent } from "./garage.update-vehicle/garage.update-vehicle.component";

export const routes: Routes = [
    { path: '', component: WelcomePageComponent },
    { path: "owner-login", component: OwnerLoginComponent },
    { path: "owner-layout", component: OwnerApplicationLayoutComponent },
    { path: "owner-register", component: OwnerRegisterComponent },
    { path: "owner-create-appointment", component: OwnerCreateAppointmentComponent },
    { path: "owner-all-appointments", component: OwnerGetAllAppointmentsComponent },
    { path: "owner-all-binded-vehicles", component: OwnerGetAllBindedVehiclesComponent },
    { path: "owner-bind-vehicle", component: OwnerInitialBindVehicleComponent },
    { path: "garage-all-appointments", component: GarageGetAllAppointmentsComponent },
    { path: "garage-register", component: GarageRegisterComponent },
    { path: "garage-login", component: GarageLoginComponent },
    { path: "garage-layout", component: GarageApplicationLayoutComponent },
    { path: "garage-update-appointment", component: GarageUpdateAppointmentComponent },
    { path: "garage-update-vehicle", component: GarageUpdateVehicleComponent },


]
