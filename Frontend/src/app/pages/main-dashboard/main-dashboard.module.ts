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
import { DailyGraphComponent } from './daily-graph/daily-graph.component';
import { DailyLineComponent } from './daily-graph/daily-line.component';
import { MainDashboardComponent } from './main-dashboard.component';
import { SevenGraphComponent } from './seven-graph/seven-graph.component';
import { SevenBarComponent } from './seven-graph/seven-bar.component';
import { MonthPieCardComponent } from './month-pie/month-pie-card.component';
import { MonthPieComponent } from './month-pie/month-pie.component';


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
    MainDashboardComponent,
    DailyGraphComponent,
    DailyLineComponent,
    SevenGraphComponent,
    SevenBarComponent,
    MonthPieComponent,
    MonthPieCardComponent
  ],
  providers: [
  ],
})
export class MainDashboardModule { }
