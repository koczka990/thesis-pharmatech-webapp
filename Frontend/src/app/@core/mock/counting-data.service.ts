import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { CountingDataInterface } from "../data/counting-data";
import { map, retry } from "rxjs/operators";

class CountingData {
  constructor(
    public countingDataId: number,
    public fromTime: string,
    public toTime: string,
    public joCount: number,
    public repedtCount: number,
    public olajosCount: number,
    public torottszelCount: number,
    public totalCount: number
  ) {}
}

@Injectable()
export class CountingDataService extends CountingDataInterface {
  baseUrl = environment.baseUrlCountingData;
  private httpClient: HttpClient;

  constructor(private http: HttpClient) {
    super();
    this.httpClient = http;
  }

  getRecords(url: string): Observable<CountingData[]> {
    return this.httpClient.get<CountingData[]>(url).pipe(
      map((dto: CountingData[]) => {
        const list: CountingData[] = dto.map((elem) => {
          const data: CountingData = {
            countingDataId: elem.countingDataId,
            fromTime: elem.fromTime,
            toTime: elem.toTime,
            joCount: elem.joCount,
            repedtCount: elem.repedtCount,
            olajosCount: elem.olajosCount,
            torottszelCount: elem.torottszelCount,
            totalCount: elem.totalCount,
          };
          return data;
        });
        return list;
      }),
      retry(3)
    );
  }

  getData() : Observable<CountingData[]> {
    var url: string;
    url = this.getBaseUrl() + '/filtered';
    return this.getRecords(url);
  }

  getBaseUrl() : string {
    var url: string;
    url = this.baseUrl;
    return url;
  }

}
