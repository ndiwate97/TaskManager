import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from '../AppServices/app-service.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  emailModel: any = {
    "email": "",
    "password" : ""
  }

  confirm_Password :any;

  verifiedUser: boolean = false;

  constructor(private router: Router, private service: AppServiceService) { }

  ngOnInit() {
  }

  verifyUser() {
    this.verifiedUser = true;
  }


  onSubmit(formvalid, formvalue) {
    console.log(this.emailModel)
    //this.router.navigate(['/'])
  }

}
