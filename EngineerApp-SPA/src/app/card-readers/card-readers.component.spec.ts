/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CardReadersComponent } from './card-readers.component';

describe('CardReadersComponent', () => {
  let component: CardReadersComponent;
  let fixture: ComponentFixture<CardReadersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardReadersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardReadersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
