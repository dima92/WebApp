import { Component, OnInit } from "@angular/core";
import { DetailService } from "../../services/detail.service";
import { Detail } from "../../models/detail";



@Component({
    selector: "app-detail",
    templateUrl: "./detail.component.html"
})
export class DetailComponent implements OnInit {

    detail: Detail = new Detail();
    details: Detail[];
    status: boolean = true;
    isNew: boolean = true;
    obj: {} = {};
    filter: {} = {};

    constructor(private detailService: DetailService) {
    }

    ngOnInit() {
        this.loadDetails();
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

    filterForm() {
        this.loadDetails();
    }
	
	add() {
        this.obj = {};
        this.obj = {
            createDate: new Date(),
            deleteDate: new Date(),
        };
        this.status = false;
    }
	
    edit(detail) {
        this.status = false;
        this.isNew = false;
        this.obj = detail;
    }

    createDetail(data) {
        this.detailService.createDetail(data).subscribe((data: Detail) => {
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