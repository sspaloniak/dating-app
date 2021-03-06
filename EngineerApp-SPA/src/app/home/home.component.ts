import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  model: any = {};
  users: User[];
  closeResult: string;
  emailForm: FormGroup;

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router,
    private modalService: NgbModal, private userService: UserService, private fb: FormBuilder) { }

  ngOnInit() {
    this.authService.loadUser(this.authService.decodedToken.nameid);
    this.loadUsers();
    this.createEmailForm();
  }

  createEmailForm() {
    this.emailForm = this.fb.group({
      selectuser: ['', Validators.required],
      subject: ['', Validators.required]
    });
  }

  logout() {
    localStorage.clear();
    this.alertify.message('Logged out');
    this.router.navigate(['/login']);
  }

  sendEmail() {
    this.alertify.warning('Email was sent.');
    this.modalService.dismissAll();
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', centered: true}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error(error);
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}
