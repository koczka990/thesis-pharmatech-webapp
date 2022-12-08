import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dropdown_yearComponent } from './dropdown_year.component';

describe('Dropdown_yearComponent', () => {
  let component: Dropdown_yearComponent;
  let fixture: ComponentFixture<Dropdown_yearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Dropdown_yearComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Dropdown_yearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
