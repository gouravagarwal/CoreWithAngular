import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UserModule } from './user/user.module';
import { AccountModule } from './account/account.module';
import { SharedService } from './shared/shared.service';

import { AppRoutingModule } from './app-routing.module';
import { JwtHelper } from 'angular2-jwt';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    UserModule,
    AccountModule
  ],
  providers: [JwtHelper, SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
