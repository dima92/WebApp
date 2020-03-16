var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
import { Detail } from "../../models/detail";
let DetailComponent = class DetailComponent {
    constructor(detailService) {
        this.detailService = detailService;
        this.detail = new Detail(0, "", null, 0, null, null);
        this.status = true;
        this.isNew = true;
    }
    ngOnInit() {
        this.loadDetails();
    }
    loadDetails() {
        this.detailService.getDetails().subscribe((data) => {
            this.details = data;
        }, error => {
            for (let i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
    }
    createDetail() {
        this.detail = new Detail(0, "", null, 0, null, null);
        this.details.push(this.detail);
        this.status = false;
    }
    updateDetail(detail) {
        this.detail = new Detail(detail.id, detail.nomenclatureCode, detail.name, detail.quantity, detail.createDate, detail.deleteDate);
        this.status = false;
        this.isNew = false;
    }
    deleteDetail(detail) {
        this.detailService.deleteDetail(detail.id).subscribe(data => {
            this.loadDetails();
        });
    }
    cancel() {
        this.status = true;
        this.isNew = true;
    }
};
DetailComponent = __decorate([
    Component({
        selector: "app-detail",
        templateUrl: "./detail.component.html"
    })
], DetailComponent);
export { DetailComponent };
//# sourceMappingURL=detail.component.js.map