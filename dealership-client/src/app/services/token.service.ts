import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";
import { BehaviorSubject, Observable } from "rxjs";



@Injectable()
export class TokenService {
  private subject = new BehaviorSubject<boolean>(false);

  constructor(private jwtHelper: JwtHelperService) { }


  public isExpired() {
    return this.jwtHelper.isTokenExpired();
  }


  public isLoggenInObservable(): Observable<boolean> {
    return this.subject.asObservable();
  }

  setToken(token: string) {
    this.subject.next(true);
    sessionStorage.setItem("jwt", token);
  }

  isLoggedIn() {
    return sessionStorage.getItem("jwt") != null;
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

  getGarageName() {
    let var1 = this.jwtHelper.decodeToken(tokenGetter()!);
    return var1['garageName'];
  }

  getUserType() {
    let var1 = this.jwtHelper.decodeToken(tokenGetter()!);
    return var1['userType'];
  }

  removeToken() {
    this.subject.next(false);
    sessionStorage.removeItem("jwt");
  }
}

export function tokenGetter() {
  return sessionStorage.getItem("jwt");
}
