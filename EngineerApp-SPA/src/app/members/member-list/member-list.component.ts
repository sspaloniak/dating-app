import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users: User[];
  pageTitle = 'List of users';
  tempInfo = 'Loading...';

  constructor(private userService: UserService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error(error);
    });
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe(() => {
      console.log('deleted successful');
      this.loadUsers();
    }, error => {
      console.log(error);
    });
  }
}

