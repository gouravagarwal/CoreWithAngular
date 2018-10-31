import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelper } from 'angular2-jwt';
import { SharedService } from '../../shared/shared.service';
import { LoggedInUser } from '../../shared/shared.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean;
  currentLoggedInUser: LoggedInUser;

  constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelper, private sharedService: SharedService) { }

  ngOnInit() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token))
      this.router.navigate(["/"]);

    this.sharedService.currentUser.subscribe(user => this.currentLoggedInUser = user);
  }

  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);
    this.http.post("api/Auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(
      response => {
        let token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;

        let obj = this.jwtHelper.decodeToken(token);

        let currentUser = new LoggedInUser();
        currentUser.fullName = obj["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        currentUser.userName = obj["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"];
        currentUser.email = obj["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
        currentUser.role = obj["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        currentUser.userId = obj["http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"];

        this.sharedService.changeCurrentUser(currentUser);

        this.router.navigate(["/"]);
      },
      err => {
        this.invalidLogin = true;
      });
  }

}
