import { Component } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private jwtHelper: JwtHelper) { }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token))
      return true;

    return false;
  }
}
