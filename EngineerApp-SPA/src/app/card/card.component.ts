import { Component, OnInit } from '@angular/core';
import { CardService } from '../_services/card.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { Card } from '../_models/card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  cards: Card[];
  pageTitle = 'List of cards';
  tempInfo = 'Loading...';
  model: any = {};

  constructor(private cardService: CardService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadCards();
  }

  loadCards() {
    this.cardService.getCards().subscribe((cards: Card[]) => {
      this.cards = cards;
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
    this.cardService.addCard(this.model).subscribe(() => {
      this.alertify.message('New card was added.');
      this.loadCards();
    }, error => {
      this.alertify.error(error);
    });
  }

}
