import { Component, OnInit, ViewChild } from '@angular/core';
import { StatDataInterface } from '../../@core/data/stat-data';
import { StatData } from '../../models/StatData';
import { DaysLineChartComponent } from './charts/days-line-chart.component';
import { StatPieChartComponent } from './charts/stat-pie-chart.component';

@Component({
  selector: 'ngx-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {

  year = -1;
  month = -1;
  statData: StatData;
  statDatas: StatData[];
  hideDiagrams = true;

  @ViewChild(StatPieChartComponent) childPieChart: StatPieChartComponent;
  @ViewChild(DaysLineChartComponent) childLineChart: DaysLineChartComponent;

  constructor(private statService: StatDataInterface) { }

  ngOnInit(): void {
  }

  setYear(event){
    if(event == this.year) return;
    this.year = event;
    this.onRefresh();
  }

  setMonth(event){
    if(event == this.month) return;
    if(event == 0) this.month = -1;
    else this.month = event;
    this.onRefresh();
  }

  onRefresh(){
    if(this.year == -1) return;
    this.hideDiagrams = false;
    if(this.month == -1){
      this.statService.getYear(this.year).subscribe((res) => {
        this.statData = res;
        console.log(this.statData);
        this.childPieChart.refresh(this.statData);
      });
      this.statService.getYearMonths(this.year).subscribe((res) => {
        console.log(res);
        this.childLineChart.refresh(res);
      });
    }else{
      this.statService.getMonth(this.year, this.month).subscribe((res) => {
        this.statData = res;
        console.log(this.statData);
        this.childPieChart.refresh(this.statData);
        //this.statService.getData().subscribe((res) => {});
      });
      this.statService.getMonthDays(this.year, this.month).subscribe((res) => {
        console.log(res);
        this.childLineChart.refresh(res);
      });
    }
  }

  loadData(){
    if(this.year == -1) return;
    if(this.month == -1){
      this.statService.getYear(this.year).subscribe((res) => {
        this.statData = res;
        console.log(res);
      });
    }else{
      this.statService.getMonth(this.year, this.month).subscribe((res) => {
        this.statData = res;
        console.log(res);
      });
    }
  }

}
