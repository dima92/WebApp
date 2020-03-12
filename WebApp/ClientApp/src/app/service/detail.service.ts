import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Detail } from "../model/detail";

@Injectable()
export class DetailService {

  private url = "/api/details";

  constructor(private http: HttpClient) {
  }

  getDetails() {
    return this.http.get(this.url);
  }

  getDetail(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createDetail(detail: Detail) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post(this.url, JSON.stringify(detail), { headers: myHeaders });
  }
  updateDetail(id: number, detail: Detail) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.put(this.url, JSON.stringify(detail), { headers: myHeaders });
  }
  deleteDetail(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
