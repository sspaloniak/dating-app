import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Department } from '../_models/department';
import { Superior } from '../_models/superior';
import { DictionaryService } from '../_services/dictionary.service';
import { AlertifyService } from '../_services/alertify.service';
import { RegisterUser } from '../_models/registerUser';
import { Router } from '@angular/router';
import { MemberListComponent } from '../members/member-list/member-list.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  departments: Department[];
  superiors: Superior[];
  @Input() valuesForRegister: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private dictionaryService: DictionaryService, private alertify: AlertifyService,
    private router: Router) { }

  ngOnInit() {
    this.loadDepartments();
    this.loadSuperiors();
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.message('New user has been added.');
      this.router.navigateByUrl('/members');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.router.navigateByUrl('/members');
  }

  loadDepartments() {
    this.dictionaryService.getDepartments().subscribe((departments: Department[]) => {
      this.departments = departments;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadSuperiors() {
    this.dictionaryService.getSuperiors().subscribe((superiors: Superior[]) => {
      this.superiors = superiors;
    }, error => {
      this.alertify.error(error);
    });
  }
}
