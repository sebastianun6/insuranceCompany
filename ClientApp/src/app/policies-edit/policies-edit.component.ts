import { Component, OnInit } from '@angular/core';
import { formatDate } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPolicy } from '../interfaces';
import { DataService } from '../data.service';

@Component({
  selector: 'app-policies-edit',
  templateUrl: './policies-edit.component.html',
  styleUrls: ['./policies-edit.component.css']
})
export class PoliciesEditComponent implements OnInit {

  policyForm: FormGroup;
  policy: IPolicy = {
    id: 0,
    name: '',
    description: '',
    typePolicy: '',
    coverage: 0,
    beginDate: new Date(),
    coveragePeriod: 0,
    policyCost: 0,
    typeRisk: ''
  }
  saveOrUpdateText = 'Save';
  showDeleteMessage: boolean;

  typePolicyOptions: any = ['Earthquake', 'Fire', 'Robbery', 'Flood', 'Other'];
  typeRiskOptions: any = ['Low', 'Medium', 'Medium-High', 'High'];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,private route: ActivatedRoute, 
    private dataService: DataService
  ) { }

  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    if(id != 0){
      this.dataService.getPolicy(id).subscribe((response: IPolicy) => {
        this.policy = response;
        this.saveOrUpdateText = 'Update';
        this.buildForm();
      },
      (err: any) => console.log(err));
    }else{
      this.buildForm();
    }
  }

  buildForm() {
    this.policyForm = this.formBuilder.group({
      id: [this.policy.id, Validators.required],
      name: [this.policy.name, Validators.required],
      description: [this.policy.description, Validators.required],
      typePolicy: [this.policy.typePolicy, Validators.required],
      coverage: [this.policy.coverage, [Validators.required, Validators.min(0),Validators.max(100)]],
      beginDate: [formatDate(this.policy.beginDate, 'yyyy-MM-dd', 'en'), Validators.required],
      coveragePeriod: [this.policy.coveragePeriod, Validators.required],
      policyCost: [this.policy.policyCost, Validators.required],
      typeRisk: [this.policy.typeRisk, Validators.required],
    });
  }

  submit(event: Event){

    if(this.policyForm.value.id){
      //update
      this.dataService.updatePolicy(this.policyForm.value).subscribe((response: IPolicy) => {
        this.router.navigate(['/policies']);
      },
      (err: any) => console.log(err));
    }else{
      //add
      this.dataService.addPolicy(this.policyForm.value).subscribe((response: IPolicy) => {
        this.router.navigate(['/policies']);
      },
      (err: any) => console.log(err));
    }
  }

  delete(event: Event){
    this.dataService.deletePolicy(this.policyForm.value).subscribe((response: IPolicy) => {
      this.router.navigate(['/policies']);
    },
    (err: any) => console.log(err));
  }

  cancel(event: Event){
    this.router.navigate(['/policies']);
  }

}
