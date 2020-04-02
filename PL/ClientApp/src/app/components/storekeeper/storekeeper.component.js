var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
import { Storekeeper } from "../../models/storekeeper";
let StorekeeperComponent = class StorekeeperComponent {
    constructor(storekeeperService) {
        this.storekeeperService = storekeeperService;
        this.storekeeper = new Storekeeper();
        this.status = true;
        this.isNew = true;
        this.obj = {};
        this.filter = {};
    }
    ngOnInit() {
        this.loadStorekeepers();
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
        this.loadStorekeepers();
    }
    add() {
        this.obj = {};
        this.status = false;
    }
    edit(storekeeper) {
        this.status = false;
        this.isNew = false;
        this.obj = storekeeper;
    }
    createStorekeeper(data) {
        this.storekeeperService.createStorekeeper(data).subscribe((data) => {
            this.loadStorekeepers();
            this.status = true;
        });
    }
    deleteStorekeeper(id) {
        this.storekeeperService.deleteStorekeeper(id).subscribe(data => {
            this.loadStorekeepers();
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
    save(storekeeper) {
        debugger;
        this.storekeeperService.updateStorekeeper(storekeeper).subscribe((data) => {
            this.loadStorekeepers();
            this.status = true;
        }, error => {
            for (let i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        });
    }
};
StorekeeperComponent = __decorate([
    Component({
        selector: "app-storekeeper",
        templateUrl: "./storekeeper.component.html"
    })
], StorekeeperComponent);
export { StorekeeperComponent };
//# sourceMappingURL=storekeeper.component.js.map