var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
import { Detail } from "../../models/detail";
import { Storekeeper } from "../../models/storekeeper";
let DetailComponent = class DetailComponent {
    constructor(detailService, storekeeperService) {
        this.detailService = detailService;
        this.storekeeperService = storekeeperService;
        this.detail = new Detail();
        this.storekeeper = new Storekeeper();
        this.status = true;
        this.isNew = true;
        this.detailObj = {};
        this.filter = {};
    }
    ngOnInit() {
        this.loadDetails();
        this.loadStorekeepers();
    }
    loadDetails() {
        this.detailService.getDetails(this.filter).subscribe((data) => {
            this.details = data;
        }, error => {
            for (let i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
    }
    loadStorekeepers() {
        this.storekeeperService.getStorekeepers(this.filter).subscribe((data) => {
            this.storekeepers = data;
        }, error => {
            for (let i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
    }
    filterForm() {
        this.loadDetails();
    }
    add() {
        this.detailObj = {
            create: new Date(),
            deleteDate: new Date()
        };
        this.status = false;
    }
    edit(detail) {
        this.status = false;
        this.isNew = false;
        this.detailObj = detail;
    }
    createDetail(detail) {
        this.detailService.createDetail(detail).subscribe((data) => {
            this.loadDetails();
            this.status = true;
        });
    }
    deleteDetail(id) {
        this.detailService.deleteDetail(id).subscribe(data => {
            this.loadDetails();
        }),
            error => {
                for (let i = 0; i < error.length; i++) {
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
            for (let i = 0; i < error.length; i++) {
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