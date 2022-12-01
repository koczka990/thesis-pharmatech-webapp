import { Data } from "@angular/router";
import { Observable } from "rxjs";

export abstract class StatDataInterface {
    abstract getData(): Observable<Data[]>;
    abstract getLastSeven(): Observable<Data[]>;
    abstract getMonth(year: number, month: number): Observable<Data>;
}