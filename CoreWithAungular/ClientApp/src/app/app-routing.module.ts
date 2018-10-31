import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { LoginComponent } from './account/login/login.component';
import { AuthGuardService } from './account/auth-guard.service';
import { LogoutComponent } from './account/logout/logout.component';
import { UserDetailComponent } from './user/user-details/user-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardService] },
  { path: 'user', component: UserListComponent, canActivate: [AuthGuardService] },
  { path: 'user/:id', component: UserDetailComponent, canActivate: [AuthGuardService] },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {

}
