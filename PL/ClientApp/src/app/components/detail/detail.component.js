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
        this.detail = new Detail();
        this.status = true;
        this.isNew = true;
        this.Obj = {};
        this.filter = {};
    }
    ngOnInit() {
        this.loadDetails();
    }
    loadDetails() {
        this.detailService.getDetails(this.filter).subscribe((data) => {
            this.details = data;
        }, error => {
            for (var i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
    }
    filterForm() {
        this.loadDetails();
    }
    edit(detail) {
        this.status = false;
        this.isNew = false;
        this.Obj = detail;
    }
    createDetail(Data) {
        this.detailService.createDetail(Data).subscribe((data) => {
            this.loadDetails();
            this.status = true;
        });
    }
    deleteDetail(id) {
        this.detailService.deleteDetail(id).subscribe(data => {
            this.loadDetails();
        }),
            error => {
                for (var i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            };
    }
    cancel() {
        this.status = true;
        this.isNew = true;
    }
    save(detail) {
        debugger;
        this.detailService.updateDetail(detail).subscribe((data) => {
            this.loadDetails();
            this.status = true;
        }, error => {
            for (var i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
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