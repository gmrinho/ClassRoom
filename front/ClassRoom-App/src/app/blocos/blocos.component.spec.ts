/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BlocosComponent } from './blocos.component';

describe('BlocosComponent', () => {
  let component: BlocosComponent;
  let fixture: ComponentFixture<BlocosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlocosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlocosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
