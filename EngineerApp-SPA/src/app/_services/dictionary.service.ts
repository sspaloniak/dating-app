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

  getDepartment(id): Observable<Department> {
    return this.http.get<Department>(this.baseUrl + 'dictionary/departments/' + id);
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

  getCardReaders(): Observable<CardReader[]> {
    return this.http.get<CardReader[]>(this.baseUrl + 'dictionary/cardreaders');
  }
}
