import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Storekeeper } from '../models/storekeeper';

@Injectable({ providedIn: "root" })
export class StorekeeperService {

    private url = "/api/storekeepers";

    constructor(private http: HttpClient) {
    }

    getStorekeepers(filter: any) {
        let param = this.url + "?name=" + (filter.name == undefined ? '' : filter.name);
        return this.http.get(param);
    }

    getStorekeeper(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createStorekeeper(storekeeper: Storekeeper) {
        return this.http.post(this.url, storekeeper);
    }

    updateStorekeeper(storekeeper: Storekeeper) {
        return this.http.put(this.url,storekeeper);
    }

    deleteStorekeeper(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}