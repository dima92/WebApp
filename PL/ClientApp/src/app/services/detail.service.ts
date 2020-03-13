import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Detail } from '../models/detail';

@Injectable()
export class DetailService {

    private url = "/Detail";

    constructor(private http: HttpClient) {
    }

    getDetails() {
        return this.http.get(this.url);
    }

    getDetail(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createDetail(detail: Detail) {
        return this.http.post(this.url, detail);
    }

    updateDetail(detail: Detail) {
        return this.http.put(this.url + '/' + detail.id, detail);
    }

    deleteDetail(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}