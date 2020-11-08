import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from '../AppServices/app-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userModel: any = {
    "firstName": "",
    "lastName": "",
    "city": "",
    "dateofBirth": "",
    "phoneNo": "",
    "email": "",
    "password": ""
  }

  confirm_Password: any;


  constructor(private router: Router, private service: AppServiceService) { }

  ngOnInit() {
  }

  onSubmit(formvalid, formvalue) {
    console.log("formvalid", formvalid)
    console.log("formvalue", formvalue)
    console.log(this.userModel)

    if (formvalid) {

      const payload =
      {
        FirstName: this.userModel.firstName,
        LastName: this.userModel.lastName,
        DOB: this.userModel.dateofBirth,
        City: this.userModel.city,
        ContactNumber: this.userModel.phoneNo,
        Email: this.userModel.email,
        UserPass: this.userModel.password
      }

      console.log("Payload ", payload);

      this.service.register(payload).subscribe((res: any) => {
        console.log("Response of Register", res)
        
      })
    }

    this.router.navigate(['/'])
  }

}
