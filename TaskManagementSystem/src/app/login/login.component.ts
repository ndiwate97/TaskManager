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

  userId: any;

  constructor(private router: Router, private service: AppServiceService) { }

  onSubmit() {
    // localStorage.setItem("uname", this.userModel.uname);
    // localStorage.setItem("pass", this.userModel.pass); 
    console.log("", this.userModel.uname)
    console.log("", this.userModel.pass)

    // this.router.navigate(['/task'])

    const payload = {
      UserName: this.userModel.uname,
      Password: this.userModel.pass
    }

    this.service.login(payload).subscribe((response: any) => {
      console.log('res', response);
      if (response != null) {
        this.router.navigate(['/task'])
        this.userId = response;
        localStorage.setItem('sessionId', response);
      }
      else
        this.msg = "Invalid credentials";
    });


  }


  ngOnInit() {
  }

}
