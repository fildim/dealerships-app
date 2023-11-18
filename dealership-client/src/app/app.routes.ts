import { Routes } from "@angular/router";
import { OwnerLoginComponent } from "./components/owner.components/owner-login/owner-login.component";
import { GarageLoginComponent } from "./components/garage.components/garage-login/garage-login.component";
import { WelcomePageComponent } from "./components/welcome-page/welcome-page.component";
import { OwnerApplicationLayoutComponent } from "./components/owner.components/owner.application-layout/owner.application-layout.component";

export const routes: Routes = [
    { path: '', component: WelcomePageComponent },
    { path: "owner-login", component: OwnerLoginComponent },
    { path: "garage-login", component: GarageLoginComponent },
    { path: "owner-layout", component: OwnerApplicationLayoutComponent }
]
