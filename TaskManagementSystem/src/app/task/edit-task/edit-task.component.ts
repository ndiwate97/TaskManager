import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from 'src/app/AppServices/app-service.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  taskId: any;
  TaskModel: any = {
    "TaskName": "",
    "Description": "",
    "StartDateTime": "",
    "Status": "",
    "userName": localStorage.getItem('UserName'),
    "userId": localStorage.getItem('sessionId')
  }

  constructor(private service: AppServiceService, private router: Router, private _Activatedroute: ActivatedRoute) { }

  ngOnInit() {
    this._Activatedroute.paramMap.subscribe(params => {
      console.log(params);
      this.taskId = params.get('id');
      console.log("empid is:", this.taskId);
      this.getTaskById(this.taskId);
    })
  }

  getTaskById(taskId) {
    console.log("Task id : ", taskId);
    this.service.getTaskById(this.TaskModel.userId,taskId).subscribe((response: any) => {
      console.log('res', response);

      if (response != null) {

        this.TaskModel.TaskName = response.TaskName;
        this.TaskModel.Description = response.Description;
        this.TaskModel.StartDateTime = response.StartDateTime;        
        this.TaskModel.Status = response.Status;

      }
    })
  }

  onSubmit(formvalid, formvalue) {
    console.log("formvalid", formvalid)
    console.log("formvalue", formvalue)
    console.log(this.TaskModel)
    if (formvalid) {

      const payload =
      {
        TaskName: this.TaskModel.TaskName,
        Description: this.TaskModel.Description,
        StartDateTime: this.TaskModel.StartDateTime,
        Status: this.TaskModel.Status
      }

      console.log("Payload ", payload);

      this.service.updateTask(payload,this.TaskModel.userId,this.taskId).subscribe((res: any) => {
        console.log("Response of update task", res)

      })
    }

    this.router.navigate(['/task'])
  }

}

