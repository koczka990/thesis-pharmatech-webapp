import { Component, OnInit } from '@angular/core';
import { StatDataInterface } from '../../@core/data/stat-data';
import { StatData } from '../../models/StatData';

@Component({
  selector: 'ngx-main-dashboard',
  templateUrl: './main-dashboard.component.html',
  styleUrls: ['./main-dashboard.component.scss']
})
export class MainDashboardComponent implements OnInit {

  data: any[]

  constructor(private statService: StatDataInterface) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.statService.getData().subscribe((res) => {
      this.data = res;
      console.log(this.data);
    });
  }

}
