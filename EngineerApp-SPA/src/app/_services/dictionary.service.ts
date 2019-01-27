import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../_models/department';
import { Superior } from '../_models/superior';
import { Localization } from '../_models/localization';
import { CardReader } from '../_models/cardReader';

@Injectable({
  providedIn: 'root'
})
export class DictionaryService {
  baseUrl = environment.apiUrl;

constructor(
  private http: HttpClient) { }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl + 'dictionary/departments');
  }

  deleteDepartment(id): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'dictionary/departments/delete/' + id);
  }

  getDepartment(id): Observable<Department> {
    return this.http.get<Department>(this.baseUrl + 'dictionary/departments/' + id);
  }

  addDepartment(model: Department) {
    return this.http.post(this.baseUrl + 'dictionary/departments/add', model);
  }

  getSuperiors(): Observable<Superior[]> {
    return this.http.get<Superior[]>(this.baseUrl + 'dictionary/superiors');
  }

  getSuperior(id): Observable<Superior> {
    return this.http.get<Superior>(this.baseUrl + 'dictionary/superiors/' + id);
  }

  getLocalizations(): Observable<Localization[]> {
    return this.http.get<Localization[]>(this.baseUrl + 'dictionary/localizations');
  }

  deleteLocalization(id): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'dictionary/localizations/delete/' + id);
  }

  addLocalization(model: Localization) {
    return this.http.post(this.baseUrl + 'dictionary/localizations/add', model);
  }

  getCardReaders(): Observable<CardReader[]> {
    return this.http.get<CardReader[]>(this.baseUrl + 'dictionary/cardreaders');
  }

  deleteCardReader(id): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'dictionary/cardreaders/delete/' + id);
  }

  addCardReader(model: CardReader) {
    return this.http.post(this.baseUrl + 'dictionary/cardreaders/add', model);
  }
}
