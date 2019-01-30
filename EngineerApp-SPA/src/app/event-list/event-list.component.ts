import { Component, OnInit } from '@angular/core';
import { Event } from 'src/app/_models/event';
import { EventService } from '../_services/event.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

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

  constructor(private authService: AuthService, private eventService: EventService, private alertify: AlertifyService,
    private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getEvents(this.authService.decodedToken.nameid).subscribe((events: Event[]) => {
      this.events = events;
    }, error => {
      this.alertify.error(error);
    });
  }
}
