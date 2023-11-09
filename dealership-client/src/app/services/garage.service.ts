import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReadGarageModel } from "../models/garage/read.garage.model";
import { enviroment } from "src/enviroments/enviroment";
import { CreateGarageModel } from "../models/garage/create.garage.model";

@Injectable()
export class GarageService {

    constructor(private httpClient: HttpClient) {}

    public getById(id: number) {
        return this.httpClient.get<ReadGarageModel>(`${enviroment.applicationUrl}/api/garage/${id}`);
    }

    public create(garage: CreateGarageModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/garage`, garage);
    }

    


}