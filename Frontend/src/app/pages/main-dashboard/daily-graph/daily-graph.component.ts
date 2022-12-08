import { Component, Input } from '@angular/core';

@Component({
  selector: 'ngx-daily-graph',
  styleUrls: ['./daily-graph.component.scss'],
  templateUrl: './daily-graph.component.html',
})
export class DailyGraphComponent {
    @Input() goodOrBad: Boolean;
}
