import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private jwtHelper: JwtHelper) { }

  canActivate() {
    let token: string = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token))
      return true;

    this.router.navigate(["login"]);
    return false;

  }
}
