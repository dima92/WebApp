import { Component, OnInit } from "@angular/core";
import { StorekeeperService } from "../../services/storekeeper.service";
import { Storekeeper } from "../../models/storekeeper";

@Component({
    selector: "app-storekeeper",
    templateUrl: "./storekeeper.component.html"
})
export class StorekeeperComponent implements OnInit {

    storekeeper: Storekeeper = new Storekeeper();
    storekeepers: Storekeeper[];
    status: boolean = true;
    isNew: boolean = true;
    obj: {} = {};
    filter: {} = {};

    constructor(private storekeeperService: StorekeeperService) {
    }

    ngOnInit() {
        this.loadStorekeepers();
    }

    loadStorekeepers() {
        this.storekeeperService.getStorekeepers(this.filter).subscribe((data: Storekeeper[]) => {
            this.storekeepers = data;
        },
            error => {
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
        this.storekeeperService.createStorekeeper(data).subscribe((data: Storekeeper) => {
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
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }
}