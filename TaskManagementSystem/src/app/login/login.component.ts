import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ok } from 'assert';
import { AppServiceService } from '../AppServices/app-service.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public show: boolean = false;

  list: any;
  msg: any = "";

  userModel: any = {
    "uname": "",
    "pass": ""

  }


  constructor(private router: Router, private service: AppServiceService) { }

  onSubmit() {
    // localStorage.setItem("uname", this.userModel.uname);
    // localStorage.setItem("pass", this.userModel.pass); 
    console.log("", this.userModel.uname)
    console.log("", this.userModel.pass)

    this.router.navigate(['/task'])
    /*
    this.service.login(this.userModel).subscribe((response: any) => {
      console.log('res', response);
      if (response == ok) {
        this.router.navigate(['/task'])
        localStorage.setItem('sessionId', response.userId);
      }
      else
        this.msg = "Invalid credentials";
    });
    */

  }


  ngOnInit() {
  }

}
