import { Component, OnInit } from "@angular/core";
import { StorekeeperService } from "../../services/storekeeper.service";
import { Storekeeper } from "../../models/storekeeper";

@Component({
    selector: "app-storekeeper",
    templateUrl: "./storekeeper.component.html"
})
export class StorekeeperComponent implements OnInit {

    storekeeper: Storekeeper;// = new Storekeeper(0, null, 0);
    storekeepers: Array<Storekeeper>;
    status: boolean = true;
    isNew: boolean = true;

    constructor(private storekeeperService: StorekeeperService) {
        this.storekeepers = new Array<Storekeeper>();
    }

    ngOnInit() {
        this.loadStorekeepers();
    }

    private loadStorekeepers() {
        this.storekeeperService.getStorekeepers().subscribe((data: Storekeeper[]) => {
            this.storekeepers = data;
        });
        error => {
            for (let i = 0; i < error.length; i++) {
                alert(error[i]);
            }
        }
    }

    createStorekeeper() {
        this.storekeeper = new Storekeeper(0, "", 0);
        this.storekeepers.push(this.storekeeper);
        this.status = false;
    }

    updateStrorekeeper(storekeeper: Storekeeper) {
        this.storekeeper = new Storekeeper(storekeeper.id, storekeeper.name, storekeeper.quantity);
        this.status = false;
        this.isNew = false;
    }

    deleteStorekeeper(storekeeper: Storekeeper) {
        this.storekeeperService.deleteStorekeeper(storekeeper.id).subscribe(data => {
            this.loadStorekeepers();
        });
    }
    cancel() {
        this.status = true;
        this.isNew = true;
    }

}
