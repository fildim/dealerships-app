import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReadAppointmentModel } from "../models/appointment/read.appointment.model";
import { enviroment } from "src/enviroments/enviroment";
import { CreateAppointmentModel } from "../models/appointment/create.appointment.model";

@Injectable()
export class AppointmentService {

    constructor(private httpClient: HttpClient) {}

    public getById(id: number) {
        return this.httpClient.get<ReadAppointmentModel>(`${enviroment.applicationUrl}/api/appointment/${id}`);
    }

    public create(appointment: CreateAppointmentModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/appointment`, appointment);
    }



}