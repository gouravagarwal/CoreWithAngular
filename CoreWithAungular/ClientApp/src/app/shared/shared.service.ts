import { Injectable } from "@angular/core";
import { BehaviorSubject } from 'rxjs';
import { LoggedInUser } from "./shared.model";


@Injectable()
export class SharedService {

  private user: BehaviorSubject<LoggedInUser> = new BehaviorSubject<LoggedInUser>({
    userId: null,
    userName: "",
    email: "",
    fullName: "",
    role: ""
  });

  currentUser = this.user.asObservable();

  constructor() { }

  changeCurrentUser(cUser: LoggedInUser) {
    this.user.next(cUser);
  }

}
