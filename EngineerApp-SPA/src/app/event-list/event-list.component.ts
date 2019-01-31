import { Component, OnInit } from '@angular/core';
import { Event } from 'src/app/_models/event';
import { EventService } from '../_services/event.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';
import { ExcelService } from '../_services/excel.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: Event[];
  user: User;
  pageTitle = 'List of events';
  tempInfo = 'Loading...';
  startDate: Date;
  finishDate: Date;

  constructor(private authService: AuthService, private eventService: EventService, private alertify: AlertifyService,
    private userService: UserService, private excelService: ExcelService) { }

  ngOnInit() {
    this.loadEvents();
    this.filter();
  }

  loadEvents() {
    this.eventService.getEvents(this.authService.decodedToken.nameid).subscribe((events: Event[]) => {
      this.events = events;
    }, error => {
      this.alertify.error(error);
    });
  }

  filter() {

  }

  exportAsXLSX() {
    this.excelService.exportAsExcelFile(this.events, 'Export');
  }
}
