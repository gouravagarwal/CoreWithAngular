import { Component, OnInit } from '@angular/core';
import { UserDetails } from '../user.model';
import { UserService } from '../user.service';

@Component({
  templateUrl: './user-list.html'
})

export class UserListComponent implements OnInit {
  users: Array<UserDetails>;

  constructor(private userService: UserService) { }


  ngOnInit() {
    this.getUsers();
  }


  getUsers() {
    this.userService.getUsers()
      .subscribe(users => this.users = users );
  }

}
