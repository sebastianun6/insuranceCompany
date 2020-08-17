import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICustomer } from '../interfaces';
import { DataService } from '../data.service';

@Component({
  selector: 'app-customers-edit',
  templateUrl: './customers-edit.component.html',
  styleUrls: ['./customers-edit.component.css']
})
export class CustomersEditComponent implements OnInit {


  customerForm: FormGroup;
  customer: ICustomer = {
    id: 0,
    fullName: '',
    identification: ''
  }
  saveOrUpdateText = 'Save';
  showDeleteMessage: boolean;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,private route: ActivatedRoute, 
    private dataService: DataService
  ) { }

  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    if(id != 0){
      this.dataService.getCustomer(id).subscribe((response: ICustomer) => {
        this.customer = response;
        this.saveOrUpdateText = 'Update';
        this.buildForm();
      },
      (err: any) => console.log(err));
    }else{
      this.buildForm();
    }
  }

  buildForm() {
    this.customerForm = this.formBuilder.group({
      id: [this.customer.id, Validators.required],
      fullName: [this.customer.fullName, Validators.required],
      identification: [this.customer.identification, Validators.required]
    });
  }

  submit(event: Event){

    if(this.customerForm.value.id){
      //update
      this.dataService.updateCustomer(this.customerForm.value).subscribe((response: ICustomer) => {
        this.router.navigate(['/customers']);
      },
      (err: any) => console.log(err));
    }else{
      //add
      this.dataService.addCustomer(this.customerForm.value).subscribe((response: ICustomer) => {
        this.router.navigate(['/customers']);
      },
      (err: any) => console.log(err));
    }
  }

  delete(event: Event){
    this.dataService.deleteCustomer(this.customerForm.value).subscribe((response: ICustomer) => {
      this.router.navigate(['/customers']);
    },
    (err: any) => console.log(err));
  }

  cancel(event: Event){
    this.router.navigate(['/customers']);
  }

}
