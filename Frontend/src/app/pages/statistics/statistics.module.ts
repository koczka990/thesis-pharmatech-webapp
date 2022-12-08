import { NgModule } from '@angular/core';
import {
  NbButtonModule,
  NbCardModule,
  NbProgressBarModule,
  NbTabsetModule,
  NbUserModule,
  NbIconModule,
  NbSelectModule,
  NbListModule,
} from '@nebular/theme';
import { NgxEchartsModule } from 'ngx-echarts';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { ThemeModule } from '../../@theme/theme.module';
import { ChartModule } from 'angular2-chartjs';
import { StatisticsComponent } from './statistics.component';
import { Dropdown_yearComponent } from './dropdown_year/dropdown_year.component';
import { Dropdown_monthComponent } from './dropdown_month/dropdown_month.component';
import { StatPieChartComponent } from './charts/stat-pie-chart.component';
import { DaysLineChartComponent } from './charts/days-line-chart.component';


@NgModule({
  imports: [
    ThemeModule,
    NbCardModule,
    NbUserModule,
    NbButtonModule,
    NbIconModule,
    NbTabsetModule,
    NbSelectModule,
    NbListModule,
    ChartModule,
    NbProgressBarModule,
    NgxEchartsModule,
    NgxChartsModule,
  ],
  declarations: [
    StatisticsComponent,
    Dropdown_yearComponent,
    Dropdown_monthComponent,
    StatPieChartComponent,
    DaysLineChartComponent
  ],
  providers: [
  ],
})
export class StatisticsModule { }
