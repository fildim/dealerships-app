import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";


@Injectable()
export class TokenService {

    constructor(private jwtHelper: JwtHelperService) { }

    setToken(token: string) {
        localStorage.setItem("jwt", token);
    }

    isLoggedIn(){
      return localStorage.getItem("jwt");
    }

    getId() {
        let var1 = this.jwtHelper.decodeToken(tokenGetter()!)!;
        return parseInt(var1['userId']);
    }

    getFirstname() {
        let var1 = this.jwtHelper.decodeToken(tokenGetter()!);
        return var1['userFirstname'];
    }

    getLastname() {
        let var1 = this.jwtHelper.decodeToken(tokenGetter()!);
        return var1['userLastname'];
    }

    getUserType() {
      let var1 = this.jwtHelper.decodeToken(tokenGetter()!);
      return var1['userType'];
  }

    removeToken() {
        localStorage.removeItem("jwt");
    }
}

export function tokenGetter() {
    return localStorage.getItem("jwt");
}
