import { ReadAppointmentModel } from 'src/app/models/appointment/read.appointment.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReadGarageModel } from "../models/garage/read.garage.model";
import { enviroment } from "src/enviroments/enviroment";
import { CreateGarageModel } from "../models/garage/create.garage.model";
import { LoginGarageModel } from "../models/garage/login.garage.model";

@Injectable()
export class GarageService {

    constructor(private httpClient: HttpClient) { }

    public getById(id: number) {
        return this.httpClient.get<ReadGarageModel>(`${enviroment.applicationUrl}/api/garage/${id}`);
    }

    public create(garage: CreateGarageModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/garage`, garage);
    }

    public getAppointments(id: number) {
        return this.httpClient.get<ReadAppointmentModel[]>(`${enviroment.applicationUrl}/api/garage/${id}/GetAppointments`);
    }

    public getAppointmentById(id: number, appointmentId: number) {
        return this.httpClient.get<ReadAppointmentModel>(`${enviroment.applicationUrl}/api/garage/${id}/GetAppointmentById/${appointmentId}`);
    }

    public getAppointmentsForOwnerId(id: number, ownerId: number) {
        return this.httpClient.get<ReadAppointmentModel[]>(`${enviroment.applicationUrl}/api/garage/${id}/GetAppointmentsForOwnerId/${ownerId}`);
    }

    public getAll() {
        return this.httpClient.get<ReadGarageModel[]>(`${enviroment.applicationUrl}/api/garage/GetAll`);
    }

    public Login(loginCredentials: LoginGarageModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/garage/login`, loginCredentials);
    }

    public Update(appointment: ReadAppointmentModel) {
        return this.httpClient.put(`${enviroment.applicationUrl}/api/garage/update`, appointment);
    }


}