import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'ngx-dropdown-month',
  templateUrl: './dropdown_month.component.html',
  styleUrls: ['./dropdown_month.component.scss']
})
export class Dropdown_monthComponent implements OnInit {

  @Output() SelectMonth = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }


  addSelectedMonth(value: number) {
    this.SelectMonth.emit(value);
  }

}
