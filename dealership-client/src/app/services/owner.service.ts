import { CreateOwnerModel } from './../models/owner/create.owner.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from 'src/enviroments/enviroment';
import { ReadOwnerModel } from '../models/owner/read.owner.model';
import { LoginOwnerModel } from '../models/owner/login.owner.model';
import { ReadAppointmentModel } from '../models/appointment/read.appointment.model';
import { ReadVehicleModel } from '../models/vehicle/read.vehicle.model';

@Injectable()
export class OwnerService {

    constructor(private httpClient: HttpClient) {}

    public getById(id: number) {
        return this.httpClient.get<ReadOwnerModel>(`${enviroment.applicationUrl}/api/owner/${id}`);
    }

    public create(owner: CreateOwnerModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/owner`, owner);
    }

    public getBindedVehicles(id: number) {
        return this.httpClient.get<ReadVehicleModel[]>(`${enviroment.applicationUrl}/api/owner/${id}/GetBindedVehicles`);
    }
    
    public getAppointments(id: number) {
        return this.httpClient.get<ReadAppointmentModel[]>(`${enviroment.applicationUrl}/api/owner/${id}/GetAppointments`);
    }

    public getAppointmentById(id: number, appointmentId: number) {
        return this.httpClient.get<ReadAppointmentModel>(`${enviroment.applicationUrl}/api/owner/${id}/GetAppointmentById/${appointmentId}`);
    }

    public Login(loginCredentials: LoginOwnerModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/owner/login`, loginCredentials);
    }


}

