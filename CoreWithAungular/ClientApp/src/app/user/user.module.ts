import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserComponent } from './user.component';
import { UserService } from './user.service';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-details/user-detail.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    UserComponent,
    UserListComponent,
    UserDetailComponent
  ],
  providers: [
    UserService
  ]
})

export class UserModule { }
