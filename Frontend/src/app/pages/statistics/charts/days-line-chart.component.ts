import { Component, OnDestroy } from '@angular/core';
import { NbThemeService, NbColorHelper } from '@nebular/theme';
import { StatData } from '../../../models/StatData';

@Component({
  selector: 'ngx-days-line-chart',
  template: `
    <chart type="line" [data]="data" [options]="options"></chart>
  `,
})
export class DaysLineChartComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService) {
    
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }

  refresh(statData: StatData[]) {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.data = {
        labels: [],
        datasets: [{
          data: [],
          label: 'Good',
          backgroundColor: NbColorHelper.hexToRgbA(colors.success, 0.3),
          borderColor: colors.success,
        }, {
          data: [],
          label: 'Bad',
          backgroundColor: NbColorHelper.hexToRgbA(colors.danger, 0.3),
          borderColor: colors.danger,
        }
        ],
      };
      statData.forEach(stat => {
        this.data.labels.push(stat.year + "-" + stat.month + "-" + stat.day);
        this.data.datasets[0].data.push(stat.joSum);
        this.data.datasets[1].data.push(stat.hibaSum);
      });

      this.options = {
        responsive: true,
        maintainAspectRatio: true,
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
}
