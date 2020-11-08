import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AppServiceService } from '../AppServices/app-service.service';

@Component({
  selector: 'app-subtask',
  templateUrl: './subtask.component.html',
  styleUrls: ['./subtask.component.css']
})
export class SubtaskComponent implements OnInit {
  list: any;
  taskId: any;
  userId: any = localStorage.getItem('sessionId');

  constructor(private service: AppServiceService, private router: Router, private _Activatedroute: ActivatedRoute) {
    this.ngOnInit();
  }

  ngOnInit() {
    this._Activatedroute.paramMap.subscribe(params => {
      console.log(params);
      this.taskId = params.get('id');
      console.log("task id is:", this.taskId);
      this.getSubTasks(this.taskId);
    })
  }

  getUserDetails() {
    this.service.getUserById(this.userId).subscribe((response: any) => {
      console.log('user details---------->', response);
      localStorage.setItem('UserName', response.FirstName + " " + response.LastName);
    })
  }
  getSubTasks(taskId) {
    //localStorage.getItem('sessionId')
    this.service.getAllSubTask(this.userId, taskId).subscribe((response: any) => {
      console.log('res all sub task', response);

      if (response != null || response == 0) {

        if (response.length) {
          this.list = (response ? response : []);
        } else {
          this.list.push(response);
        }

        console.log("this.list->", this.list)
      }
    })
  }

  removeData(id) {
    this.service.deleteSubtask(this.userId, this.taskId, id).subscribe((res: any) => {
      console.log("res of deletedEmp", res)
    })
    this.ngOnInit();
  }
}
