import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from '../AppServices/app-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userModel : any = {
    "FirstName":"",
    "LastName":"",
    "city":"",
    "dateofBirth":"",
    "email":"",
    "password":""
  }

  constructor(private router: Router, private service: AppServiceService) { }

  ngOnInit() {
  }

  onSubmit(){
    this.router.navigate(['/'])
  }

}
