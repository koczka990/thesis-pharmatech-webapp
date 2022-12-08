import { Component, OnDestroy } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { StatData } from '../../../models/StatData';

@Component({
  selector: 'ngx-stat-pie-chart',
  template: `
    <chart type="pie" [data]="data" [options]="options"></chart>
  `,
})
export class StatPieChartComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService) {
    
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }

  refresh(statData: StatData){
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.data = {
        labels: ['Good', 'Bad'],
        datasets: [{
          data: [statData.joSum, statData.hibaSum],
          backgroundColor: [colors.success, colors.danger],
        }],
      };

      this.options = {
        maintainAspectRatio: false,
        responsive: true,
        scales: {
          xAxes: [
            {
              display: false,
            },
          ],
          yAxes: [
            {
              display: false,
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
}
