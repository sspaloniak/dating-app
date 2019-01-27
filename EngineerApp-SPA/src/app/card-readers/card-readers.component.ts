import { Component, OnInit, ViewChild } from '@angular/core';
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
  model: any = {};
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

  deleteCardReader(id: number) {
    this.dictionaryService.deleteCardReader(id).subscribe(() => {
      this.alertify.warning('Card reader was deleted.');
      this.loadCardReaders();
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

  deleteLocalization(id: number) {
    this.dictionaryService.deleteLocalization(id).subscribe(() => {
      this.alertify.warning('Localization was deleted.');
      this.loadLocalizations();
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

  deleteDepartment(id: number) {
    this.dictionaryService.deleteDepartment(id).subscribe(() => {
      this.alertify.warning('Department was deleted.');
      this.loadDepartments();
    }, error => {
      this.alertify.error(error);
    });
  }

  addLocalization(form) {
    this.dictionaryService.addLocalization(this.model).subscribe(() => {
      this.alertify.message('New localization was added.');
      this.loadLocalizations();
    }, error => {
      this.alertify.error(error);
    });
  }

  addCardReader() {
    this.dictionaryService.addCardReader(this.model).subscribe(() => {
      this.alertify.message('New card reader was added.');
      this.loadCardReaders();
    }, error => {
      this.alertify.error(error);
    });
  }

  addDepartment() {
    this.dictionaryService.addDepartment(this.model).subscribe(() => {
      this.alertify.message('New department was added.');
      this.loadDepartments();
    }, error => {
      this.alertify.error(error);
    });
  }

}
