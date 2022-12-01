import { Component, OnDestroy } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { StatDataInterface } from '../../../@core/data/stat-data';

@Component({
  selector: 'ngx-month-pie',
  template: `
    <chart type="pie" [data]="data" [options]="options"></chart>
  `,
})
export class MonthPieComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService, private statService: StatDataInterface) {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.statService.getMonth(2022, 11).subscribe((res) => {
        this.data = {
          labels: ['Jók', 'Rosszak'],
          datasets: [{
            data: [],
            backgroundColor: [colors.successLight, colors.dangerLight],
          }],
        };
          this.data.datasets[0].data.push(res.joSum);
          this.data.datasets[0].data.push(res.hibaSum);
        console.log(this.data);
      });

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

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
