var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
let DetailService = class DetailService {
    constructor(http) {
        this.http = http;
        this.url = "/Detail";
    }
    getDetails() {
        return this.http.get(this.url);
    }
    getDetail(id) {
        return this.http.get(this.url + '/' + id);
    }
    createDetail(detail) {
        return this.http.post(this.url, detail);
    }
    updateDetail(detail) {
        return this.http.put(this.url + '/' + detail.id, detail);
    }
    deleteDetail(id) {
        return this.http.delete(this.url + '/' + id);
    }
};
DetailService = __decorate([
    Injectable()
], DetailService);
export { DetailService };
//# sourceMappingURL=detail.service.js.map