import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-invoices",
  templateUrl: "./invoices.component.html",
  styleUrls: ["./invoices.component.css"],
})
export class InvoicesComponent implements OnInit {
  constructor(private httpClient: HttpClient) {}

  ngOnInit() {}

  onSubmit(form: any) {
    this.httpClient.post("api/codat/invoices", form.value).subscribe((res) => {
      console.log(res);
      alert("Your invoice has been created.")
    });
  }
}
