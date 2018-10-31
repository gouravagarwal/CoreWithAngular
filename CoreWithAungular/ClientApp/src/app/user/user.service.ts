import { Injectable } from '@angular/core';
import { UserDetails } from './user.model';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class UserService {

  token: string = localStorage.getItem("jwt");

  constructor(private http: HttpClient) { }

  getUsers(): Observable<UserDetails[]> {
    return this.http.get<UserDetails[]>("api/UserDetails", {
      headers: new HttpHeaders({
        "Authorization": `Bearer ${this.token}`,
        "Content-Type":"application/json"
      })
    })
      .pipe();
  }

  getUserById(id: number): Observable<UserDetails> {
    return this.http.get<UserDetails>(("api/UserDetails/" + id), {
      headers: new HttpHeaders({
        "Authorization": `Bearer ${this.token}`,
        "Content-Type": "application/json"
      })
    }).pipe();
  }

}
