import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Storekeeper} from "../model/storekeeper";

@Injectable()
export class StorekeeperService {

  private readonly url = "/api/storekeepers";

    constructor(private http: HttpClient) {
    }

    getStorekeepers() {
        return this.http.get(this.url);
    }

    getStorekeeper(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createStorekeeper(storekeeper: Storekeeper) {
      const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
      return this.http.post(this.url, JSON.stringify(storekeeper), { headers: myHeaders });
    }
    updateStorekeeper(storekeeper: Storekeeper) {

      const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
      return this.http.put(this.url, JSON.stringify(storekeeper), { headers: myHeaders });
    }
    deleteStorekeeper(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
