import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Department } from '../_models/department';
import { Superior } from '../_models/superior';
import { DictionaryService } from '../_services/dictionary.service';
import { AlertifyService } from '../_services/alertify.service';
import { RegisterUser } from '../_models/registerUser';

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

  constructor(private authService: AuthService, private dictionaryService: DictionaryService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadDepartments();
    this.loadSuperiors();
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('registration successful');
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
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
