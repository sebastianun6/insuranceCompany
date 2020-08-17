import { Component, OnInit } from '@angular/core';
import { ICustomer } from '../interfaces';
import { DataService } from '../data.service';
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  customers: ICustomer[];
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getCustomers().subscribe((response: ICustomer[]) => {
      this.customers = response;
    },
    (err: any) => console.log(err));
  }

}
