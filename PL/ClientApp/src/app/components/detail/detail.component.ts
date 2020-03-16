import { Component, OnInit } from "@angular/core";
import { DetailService } from "../../services/detail.service";
import { Detail } from "../../models/detail";



@Component({
    selector: "app-detail",
    templateUrl: "./detail.component.html"
})
export class DetailComponent implements OnInit {

    detail: Detail = new Detail(0, "", null, 0, null, null);
    details: Detail[];
    status: boolean = true;
    isNew: boolean = true;

    constructor(private detailService: DetailService) {
    }

    ngOnInit() {
        this.loadDetails();
    }

    loadDetails() {
        this.detailService.getDetails().subscribe((data: Detail[]) => {
            this.details = data;
        },

            error => {
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

    updateDetail(detail: Detail) {
        this.detail = new Detail(detail.id, detail.nomenclatureCode, detail.name, detail.quantity, detail.createDate, detail.deleteDate);
        this.status = false;
        this.isNew = false;
    }

    deleteDetail(detail: Detail) {
        this.detailService.deleteDetail(detail.id).subscribe(data => {
            this.loadDetails();
        });
    }
    cancel() {
        this.status = true;
        this.isNew = true;
    }
}