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

export const routes: Routes = [
    { path: '', component: WelcomePageComponent },
    { path: "owner-login", component: OwnerLoginComponent },
    { path: "garage-login", component: GarageLoginComponent },
    { path: "owner-layout", component: OwnerApplicationLayoutComponent },
    { path: "owner-register", component: OwnerRegisterComponent },
    { path: "owner-create-appointment", component: OwnerCreateAppointmentComponent },
    { path: "owner-all-appointments", component: OwnerGetAllAppointmentsComponent },
    { path: "owner-all-binded-vehicles", component: OwnerGetAllBindedVehiclesComponent },
    { path: "owner-bind-vehicle", component: OwnerInitialBindVehicleComponent },

]
