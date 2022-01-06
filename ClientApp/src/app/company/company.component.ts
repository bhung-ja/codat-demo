import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-company",
  templateUrl: "./company.component.html",
  styleUrls: ["./company.component.css"],
})
export class CompanyComponent implements OnInit {
  companies: any[];
  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.httpClient.get("/api/codat/companies").subscribe((datas) => {
      console.log( datas["results"]);
      this.companies = datas["results"] as any[];
    });
  }

  onSubmit(formData: any) {
    console.log(formData);
    this.httpClient
      .post("/api/codat/companies", formData.value)
      .subscribe((response) => {
        console.log(response);
        this.companies.push({name:response["name"], redirect: response["redirect"]})
      });
  }
}
