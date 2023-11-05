import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthenticationService {

    constructor(private httpClient: HttpClient) {}

    public register() {

    }

    public login(username: string, password: string) {
        this.httpClient.post("/", { username, password });
    }


}