import { Component, OnInit} from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { Department } from 'src/app/_models/department';
import { Superior } from 'src/app/_models/superior';
import { DictionaryService } from 'src/app/_services/dictionary.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  user: User;
  departments: Department[];
  superiors: Superior[];
  updateUserForm: FormGroup;

  constructor(private userService: UserService, private dictionaryService: DictionaryService, private alertify: AlertifyService,
    private route: ActivatedRoute, private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.loadUser();
    this.loadDepartments();
    this.loadSuperiors();
    this.createUpdateUserForm();
  }

  createUpdateUserForm() {
    this.updateUserForm = this.fb.group({
      name: [''],
      surname: [''],
      typePermission: [''],
      idSuperior: [''],
      idDepartment: [''],
      email: ['']
    });
  }

  loadUser() {
    this.userService.getUser(this.route.snapshot.params['id']).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error(error);
    });
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

  cancel() {
    this.router.navigateByUrl('/members');
  }

  update() {
    this.userService.updateUser(this.updateUserForm.value, this.route.snapshot.params['id']).subscribe(() => {
      this.alertify.message('User has been updated.');
      this.router.navigateByUrl('/members');
    }, error => {
      this.alertify.error(error);
    });
  }
}
