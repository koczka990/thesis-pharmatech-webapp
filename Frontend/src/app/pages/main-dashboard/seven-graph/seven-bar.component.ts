import { Component, OnDestroy } from '@angular/core';
import { NbThemeService, NbColorHelper } from '@nebular/theme';
import { StatDataInterface } from '../../../@core/data/stat-data';

@Component({
  selector: 'ngx-seven-bar',
  template: `
    <chart type="bar" [data]="data" [options]="options"></chart>
  `,
})
export class SevenBarComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService, private statService: StatDataInterface) {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.statService.getLastSeven().subscribe((res) => {
        this.data = {
          labels: [],
          datasets: [{
            data: [],
            label: 'Jók',
            backgroundColor: NbColorHelper.hexToRgbA(colors.success, 0.3),
            borderColor: colors.success,
          }, {
            data: [],
            label: 'Repedt',
            backgroundColor: NbColorHelper.hexToRgbA(colors.danger, 0.3),
            borderColor: colors.danger,
          }, {
            data: [],
            label: 'Olajos',
            backgroundColor: NbColorHelper.hexToRgbA(colors.primary, 0.3),
            borderColor: colors.primary,
          }, {
            data: [],
            label: 'Törött szél',
            backgroundColor: NbColorHelper.hexToRgbA(colors.warning, 0.3),
            borderColor: colors.warning,
          },
          ],
        };
        res.forEach(stat => {
          this.data.labels.push(stat.year + "-" + stat.month + "-" + stat.day);
          this.data.datasets[0].data.push(stat.joSum);
          this.data.datasets[1].data.push(stat.repedtSum);
          this.data.datasets[2].data.push(stat.olajosSum);
          this.data.datasets[3].data.push(stat.torottszelSum);
        });
        console.log(this.data);
      });

      this.options = {
        maintainAspectRatio: false,
        responsive: true,
        legend: {
          labels: {
            fontColor: chartjs.textColor,
          },
        },
        scales: {
          xAxes: [
            {
              gridLines: {
                display: false,
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
      };
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
