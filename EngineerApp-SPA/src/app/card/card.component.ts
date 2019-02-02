import { Component, OnInit } from '@angular/core';
import { CardService } from '../_services/card.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { Card } from '../_models/card';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { User } from '../_models/user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  cards: Card[];
  users: User[];
  pageTitle = 'List of cards';
  tempInfo = 'Loading...';
  closeResult: string;
  cardForm: FormGroup;

  constructor(private cardService: CardService, private alertify: AlertifyService, private router: Router,
    private modalService: NgbModal, private fb: FormBuilder) { }

  ngOnInit() {
    this.loadCards();
    this.loadUsers();
    this.createCardForm();
  }

  createCardForm() {
    this.cardForm = this.fb.group({
      idUser: ['', Validators.required],
      cardnumber4: ['', Validators.required],
      cardnumber3: ['', Validators.required],
      cardnumber2: ['', Validators.required],
      cardnumber1: ['', Validators.required],
      blocked: ['true']
    });
  }

  loadCards() {
    this.cardService.getCards().subscribe((cards: Card[]) => {
      this.cards = cards;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadUsers() {
    this.cardService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error(error);
    });
  }

  deleteCard(id: number) {
    this.cardService.deleteCard(id).subscribe(() => {
      this.alertify.warning('Card was deleted.');
      this.loadCards();
    }, error => {
      this.alertify.error(error);
    });
  }

  addCard() {
    this.cardService.addCard(this.cardForm.value).subscribe(() => {
      this.alertify.message('New card was added.');
      this.loadCards();
      this.modalService.dismissAll();
    }, error => {
      this.alertify.error(error);
    });
    this.cardForm.reset();
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', centered: true}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
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
