import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { OwnerService } from './services/owner.service';
import { GarageService } from './services/garage.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
  ],
  providers: [
    OwnerService,
    GarageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
