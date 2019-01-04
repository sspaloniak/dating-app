import { Component, OnInit } from '@angular/core';
import { Localization } from '../_models/localization';
import { DictionaryService } from '../_services/dictionary.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { CardReader } from '../_models/cardReader';
import { Department } from '../_models/department';

@Component({
  selector: 'app-card-readers',
  templateUrl: './card-readers.component.html',
  styleUrls: ['./card-readers.component.css']
})
export class CardReadersComponent implements OnInit {
  cardReaders: CardReader[];
  localizations: Localization[];
  departments: Department[];
  pageTitle = 'List of Card Readers';
  pageTitle2 = 'List of Localizations';
  pageTitle3 = 'List of Departments';
  tempInfo = 'Loading...';

  constructor(private dictionaryService: DictionaryService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadCardReaders();
    this.loadLocalizations();
    this.loadDepartments();
  }

  loadCardReaders() {
    this.dictionaryService.getCardReaders().subscribe((cardReaders: CardReader[]) => {
      this.cardReaders = cardReaders;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadLocalizations() {
    this.dictionaryService.getLocalizations().subscribe((localizations: Localization[]) => {
      this.localizations = localizations;
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

}
