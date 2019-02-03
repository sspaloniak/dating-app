import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';
import { User } from '../_models/user';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  user: User;
  constructor(public authService: AuthService, private alertify: AlertifyService,
    private userService: UserService) { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.userService.getUser(this.authService.decodedToken.nameid).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error(error);
    });
  }

}
