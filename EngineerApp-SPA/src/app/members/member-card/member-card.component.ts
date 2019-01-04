import { Component, OnInit} from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { Department } from 'src/app/_models/department';
import { Superior } from 'src/app/_models/superior';
import { DictionaryService } from 'src/app/_services/dictionary.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  user: User;
  departments: Department[];
  superiors: Superior[];

  constructor(private userService: UserService, private dictionaryService: DictionaryService, private alertify: AlertifyService,
    private route: ActivatedRoute ) { }

  ngOnInit() {
    this.loadUser();
    this.loadDepartments();
    this.loadSuperiors();
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

}
