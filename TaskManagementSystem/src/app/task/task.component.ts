import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from '../AppServices/app-service.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  list: any;

  userId: any = localStorage.getItem('sessionId');
  constructor(private service: AppServiceService, private router: Router) { }

  ngOnInit() {
    this.getTasks();
    this.getUserDetails();
  }

  getUserDetails() {
    this.service.getUserById(this.userId).subscribe((response:any) =>{
      console.log('user details---------->',response);
      localStorage.setItem('UserName', response.FirstName + " "+ response.LastName);
    })
  }
  getTasks() {
    //localStorage.getItem('sessionId')
    this.service.getAllTask(this.userId).subscribe((response: any) => {
      console.log('res', response);

      if (response != null) {

        if (response.length) {
          this.list = (response ? response : []);
        } else {
          this.list.push(response);
        }

        console.log("this.list->", this.list)
      }
    })
  }
}
