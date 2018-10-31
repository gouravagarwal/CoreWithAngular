import { Component, OnInit } from "@angular/core";
import { SharedService } from "../../shared/shared.service";
import { LoggedInUser } from "../../shared/shared.model";
import { Router, ActivatedRoute } from "@angular/router";
import { UserService } from "../user.service";
import { UserDetails } from "../user.model";


@Component({
  selector: 'user-detail',
  templateUrl: './user-detail.html'
})

export class UserDetailComponent implements OnInit {

  loggedInUser: LoggedInUser = null;
  userDetails: UserDetails = new UserDetails();

  constructor(private shareService: SharedService, private router: ActivatedRoute, private userService: UserService) { }


  ngOnInit() {
    this.shareService.currentUser.subscribe(user => this.loggedInUser = user);
    this.getUserDetails();
  }


  getUserDetails() {
    let userId = this.router.snapshot.paramMap.get('id');
    this.userService.getUserById(parseInt(userId)).subscribe(userDetail => this.userDetails = userDetail);
  }

}
