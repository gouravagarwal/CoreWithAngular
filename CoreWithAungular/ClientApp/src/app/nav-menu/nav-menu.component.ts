import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';
import { SharedService } from '../shared/shared.service';
import { LoggedInUser } from '../shared/shared.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  isExpanded = false;
  loggedInUser: LoggedInUser = new LoggedInUser();

  constructor(private router: Router, private jwtHelper: JwtHelper, private sharedService: SharedService) {

  }

  ngOnInit() {
    this.sharedService.currentUser.subscribe(user => this.loggedInUser = user);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token))
      return true;

    else
      return false;

  }
}
