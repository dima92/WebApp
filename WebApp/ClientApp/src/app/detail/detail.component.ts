import { Component, OnInit } from "@angular/core";
import { DetailService } from "../service/detail.service";
import { Detail } from "../model/detail";



@Component({
    selector: "app-detail",
    templateUrl: "./detail.component.html"
})
export class DetailComponent implements OnInit {

    detail: Detail = new Detail(1, 100, null, 1, false, null, null);
    details: Detail[];

    constructor(private detailService: DetailService) {
    }

    ngOnInit() {
        this.detailService.getDetails().subscribe((data: Detail[]) => {
            this.details = data;
        },

            error => {
                for (let i = 0; i < error.length; i++) {
                    alert(error[i]);
                }
            });

    }
}