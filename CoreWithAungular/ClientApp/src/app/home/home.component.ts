import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared/shared.service';
import { LoggedInUser } from '../shared/shared.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  loggedInUser: LoggedInUser = new LoggedInUser();

  constructor(private sharedService: SharedService) { }

  ngOnInit() {
    this.sharedService.currentUser.subscribe(user => this.loggedInUser = user);
  }
}
