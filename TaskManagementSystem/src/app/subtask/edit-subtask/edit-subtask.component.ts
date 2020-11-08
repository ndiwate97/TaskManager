import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppServiceService } from 'src/app/AppServices/app-service.service';

@Component({
  selector: 'app-edit-subtask',
  templateUrl: './edit-subtask.component.html',
  styleUrls: ['./edit-subtask.component.css']
})
export class EditSubtaskComponent implements OnInit {

  
  taskId: any;
  
  subtaskId: any;

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
      this.taskId = params.get('taskId');
      this.subtaskId = params.get('id');
      console.log("task is:", this.taskId);
      console.log("subtask is:", this.subtaskId);

      this.getTaskById(this.taskId,this.subtaskId);
    })
  }

  getTaskById(taskId,subtaskId) {
    this.service.getSubtaskById(this.TaskModel.userId,taskId, subtaskId).subscribe((response: any) => {
      console.log('res', response);

      if (response != null) {

        this.TaskModel.TaskName = response.SubTaskName;
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
        SubTaskName: this.TaskModel.SubTaskName,
        Description: this.TaskModel.Description,
        StartDateTime: this.TaskModel.StartDateTime,
        Status: this.TaskModel.Status
      }

      console.log("Payload ", payload);

      this.service.updateSubtask(payload,this.TaskModel.userId,this.taskId, this.subtaskId).subscribe((res: any) => {
        console.log("Response of update sub task", res)

      })
    }

    this.router.navigate(['/subTask',this.taskId])
  }

}
