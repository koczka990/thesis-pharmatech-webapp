import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dropdown_monthComponent } from './dropdown_month.component';

describe('Dropdown_monthComponent', () => {
  let component: Dropdown_monthComponent;
  let fixture: ComponentFixture<Dropdown_monthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Dropdown_monthComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Dropdown_monthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
