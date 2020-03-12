import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Storekeeper } from "../model/storekeeper";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class StorekeeperService {

  url: string = "";
  //private readonly url = "/api/storekeepers";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getStorekeepers() {
    return this.http.get(this.url + 'api/storekeepers')
      .pipe(map(
        response => {
          return response;
        }))
  }

  getStorekeeper(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createStorekeeper(storekeeper: Storekeeper) {
    return this.http.post(this.url, storekeeper);
  }
  updateStorekeeper(storekeeper: Storekeeper) {

    return this.http.put(this.url, storekeeper);
  }
  deleteStorekeeper(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}
