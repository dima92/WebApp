import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Detail } from '../models/detail';

@Injectable()
export class DetailService {

    private url = "/api/details";

    constructor(private http: HttpClient) {
    }

    getDetails(filter: any) {
        let param = this.url + "?nomenclatureCode=" + (filter.nomenclatureCode == undefined ? '' : filter.nomenclatureCode);
        return this.http.get(param);
    }

    getDetail(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createDetail(detail: Detail) {
        return this.http.post(this.url, detail);
    }

    updateDetail(detail: Detail) {
        return this.http.put(this.url, detail);
    }

    deleteDetail(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}