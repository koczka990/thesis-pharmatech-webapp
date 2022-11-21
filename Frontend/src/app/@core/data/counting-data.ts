import { Data } from "@angular/router";
import { Observable } from "rxjs";

export abstract class CountingDataInterface {
    abstract getData(from?:string, to?:string): Observable<Data>;
}