import { Component, OnInit } from '@angular/core';
import { IPolicy } from '../interfaces';
import { DataService } from '../data.service';

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.css']
})
export class PoliciesComponent implements OnInit {

  policies: IPolicy[];
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getPolicies().subscribe((response: IPolicy[]) => {
      this.policies = response;
    },
    (err: any) => console.log(err));
  }

}
