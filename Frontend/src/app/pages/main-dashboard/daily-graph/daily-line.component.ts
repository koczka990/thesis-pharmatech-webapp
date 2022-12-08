import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NbThemeService, NbColorHelper } from '@nebular/theme';
import { StatDataInterface } from '../../../@core/data/stat-data';

@Component({
  selector: 'ngx-daily-line',
  template: `
    <chart type="line" [data]="data" [options]="options"></chart>
  `,
})
export class DailyLineComponent implements OnDestroy, OnInit {
  data: any;
  options: any;
  themeSubscription: any;
  @Input() goodOrBad: Boolean = false;

  constructor(private theme: NbThemeService, private statService: StatDataInterface) {
    
  }
  ngOnInit(): void {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {
      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;
      var color = colors.danger;
      var label = "Bad"
      if(this.goodOrBad){
        color = colors.success;
        label = "Good"
      } 
      this.statService.getDaysLastMonth().subscribe((res) => {
        this.data = {
          labels: [],
          datasets: [{
            data: [],
            label: label,
            backgroundColor: NbColorHelper.hexToRgbA(color, 0.3),
            borderColor: color,
          }
          ],
        };
        res.forEach(stat => {
          this.data.labels.push(stat.year + "-" + stat.month + "-" + stat.day);
          if(this.goodOrBad){
            this.data.datasets[0].data.push(stat.joSum);
          }else{
            this.data.datasets[0].data.push(stat.hibaSum);
          }
        });
        console.log(this.data);
      });

      this.options = {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          xAxes: [
            {
              gridLines: {
                display: true,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
          yAxes: [
            {
              gridLines: {
                display: true,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
        },
        legend: {
          labels: {
            fontColor: chartjs.textColor,
          },
        },
      };
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
