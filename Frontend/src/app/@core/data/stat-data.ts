import { Data } from "@angular/router";
import { Observable } from "rxjs";
import { StatData } from "../../models/StatData";

export abstract class StatDataInterface {
    abstract getData(): Observable<Data[]>;
    abstract getLastSeven(): Observable<Data[]>;
    abstract getYear(year: number): Observable<StatData>;
    abstract getMonth(year: number, month: number): Observable<StatData>;
    abstract getDaysLastMonth(): Observable<StatData[]>;
    abstract getMonthDays(year: number, month: number): Observable<StatData[]>;
    abstract getYearMonths(year: number): Observable<StatData[]>;
}