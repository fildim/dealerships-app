import { CreateOwnerModel } from './../models/owner/create.owner.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from 'src/enviroments/enviroment';
import { ReadOwnerModel } from '../models/owner/read.owner.model';

@Injectable()
export class OwnerService {

    constructor(private httpClient: HttpClient) {}

    public getById(id: number) {
        return this.httpClient.get<ReadOwnerModel>(`${enviroment.applicationUrl}/api/owner/${id}`);
    }

    public create(owner: CreateOwnerModel) {
        return this.httpClient.post(`${enviroment.applicationUrl}/api/owner`, owner);
    }

    


}

