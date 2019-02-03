import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { RegisterUser } from '../_models/registerUser';
import { User } from '../_models/user';
import { UserService } from './user.service';
import { AlertifyService } from './alertify.service';
import { Password } from '../_models/password';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient, private userService: UserService, private alertify: AlertifyService) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
          }
        })
      );
  }

  loadUser(id: number) {
    this.userService.getUser(id).subscribe((user: User) => {
      localStorage.setItem('permission', 'sq@3$s/' + user.typePermission.toString());
    }, error => {
      this.alertify.error(error);
    });
  }

  register(model: RegisterUser) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  changePassword(model: Password) {
    model.idUser = this.decodedToken.nameid;
    return this.http.post(this.baseUrl + 'changepassword', model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  setUserProfile() {
    if (localStorage.getItem('permission') === 'sq@3$s/1') {
      return false;
    } else {
      return true;
    }
  }
}
