import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NbDateService } from '@nebular/theme';

@Component({
  selector: 'ngx-dropdown-year',
  templateUrl: './dropdown_year.component.html',
  styleUrls: ['./dropdown_year.component.scss']
})
export class Dropdown_yearComponent implements OnInit {

  @Output() SelectYear = new EventEmitter<number>();

  years: string[] = [];

  constructor( protected dateService: NbDateService<Date>) { 
    var year = this.dateService.today().getFullYear()
    for (let i = 2018; i <= year; i++) {
      this.years.push(String(i));
    }
  }

  ngOnInit(): void {
  }

  addYear(value: number) {
    this.SelectYear.emit(value);
  }

}
