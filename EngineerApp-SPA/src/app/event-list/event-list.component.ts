import { Component, OnInit } from '@angular/core';
import { Event } from 'src/app/_models/event';
import { EventService } from '../_services/event.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: Event[];
  pageTitle = 'List of events';
  tempInfo = 'Loading...';

  constructor(private eventService: EventService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getEvents().subscribe((events: Event[]) => {
      this.events = events;
    }, error => {
      this.alertify.error(error);
    });
  }
}
