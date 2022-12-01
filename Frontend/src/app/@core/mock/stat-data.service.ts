import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { map, retry } from "rxjs/operators";
import { StatDataInterface } from "../data/stat-data";
import { StatData } from "../../models/StatData";
import { Data } from "@angular/router";

@Injectable()
export class StatDataService extends StatDataInterface {
  baseUrl = environment.baseUrlStatData;
  private httpClient: HttpClient;

  constructor(private http: HttpClient) {
    super();
    this.httpClient = http;
  }

  getRecords(url: string): Observable<StatData[]> {
    return this.httpClient.get<StatData[]>(url).pipe(
      map((dto: StatData[]) => {
        const list: StatData[] = dto.map((elem) => {
          const data: StatData = {
            statDataId: elem.statDataId,
            year: elem.year,
            month: elem.month,
            day: elem.day,
            fromTime: elem.fromTime,
            toTime: elem.toTime,
            hibaSum: elem.hibaSum,
            joSum: elem.joSum,
            repedtSum: elem.repedtSum,
            olajosSum: elem.olajosSum,
            torottszelSum: elem.torottszelSum,
          };
          return data;
        });
        return list;
      }),
      retry(3)
    );
  }

  getRecord(url: string): Observable<StatData> {
    return this.httpClient.get<StatData>(url).pipe(
        map((elem: StatData) => {
            const data: StatData = {
                statDataId: elem.statDataId,
                year: elem.year,
                month: elem.month,
                day: elem.day,
                fromTime: elem.fromTime,
                toTime: elem.toTime,
                hibaSum: elem.hibaSum,
                joSum: elem.joSum,
                repedtSum: elem.repedtSum,
                olajosSum: elem.olajosSum,
                torottszelSum: elem.torottszelSum,
              };
              return data;
        }),
        retry(3)
    );
  }

  getData() : Observable<StatData[]> {
    var url: string;
    url = this.getBaseUrl() + '/DaysBetween?from=2022-02-01&to=2022-02-28';
    return this.getRecords(url);
  }

  getLastSeven(): Observable<StatData[]> {
    var url: string;
    url = this.getBaseUrl() + '/lastseven';
    return this.getRecords(url);
  }

  getMonth(year: number, month: number): Observable<StatData> {
    var url: string;
    url = this.getBaseUrl() + '/Month?year=' + year + '&month=' + month;
    return this.getRecord(url);
  }

  getBaseUrl() : string {
    var url: string;
    url = this.baseUrl;
    return url;
  }

}
