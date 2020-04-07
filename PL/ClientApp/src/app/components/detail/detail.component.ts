import { Component, OnInit } from "@angular/core";
import { DetailService } from "../../services/detail.service";
import { Detail } from "../../models/detail";
import { StorekeeperService } from "../../services/storekeeper.service";
import { Storekeeper } from "../../models/storekeeper";


@Component({
    selector: "app-detail",
    templateUrl: "./detail.component.html"
})
export class DetailComponent implements OnInit {

    detail: Detail = new Detail();
    details: Detail[];
    storekeeper: Storekeeper = new Storekeeper();
    storekeepers: Storekeeper[];
    status: boolean = true;
    isNew: boolean = true;
    detailObj: {} = {};
    filter: {} = {};

    constructor(private detailService: DetailService,
        private storekeeperService: StorekeeperService) {
    }

    ngOnInit() {
        this.loadDetails();
        this.loadStorekeepers();
    }

    loadDetails() {
        this.detailService.getDetails(this.filter).subscribe((data: Detail[]) => {
            this.details = data;
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
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
        this.loadDetails();
    }

    add() {
        this.detailObj = {
            created: new Date(),
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
        detail.storekeeperId = + detail.storekeeperId;
        this.detailService.createDetail(detail).subscribe((data: Detail) => {
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
        },
            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });
    }
}