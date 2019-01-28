import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../_models/card';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  baseUrl = environment.apiUrl;

constructor(
  private http: HttpClient) { }

  getCards(): Observable<Card[]> {
    return this.http.get<Card[]>(this.baseUrl + 'card');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getCard(id): Observable<Card> {
    return this.http.get<Card>(this.baseUrl + 'card/' + id);
  }

  deleteCard(id): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'card/delete/' + id);
  }

  addCard(model: Card) {
    return this.http.post(this.baseUrl + 'card/add', model);
  }
}
