import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from 'src/app/AppServices/app-service.service';
import { ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-add-subtask',
  templateUrl: './add-subtask.component.html',
  styleUrls: ['./add-subtask.component.css']
})
export class AddSubtaskComponent implements OnInit {

  taskId : any;
  
  addTaskModel: any = {
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
    })
  }

  onSubmit(formvalid, formvalue) {
    console.log("formvalid", formvalid)
    console.log("formvalue", formvalue)
    console.log(this.addTaskModel)

    if (formvalid) {

      const payload =
      {
        SubTaskName: this.addTaskModel.TaskName,
        Description: this.addTaskModel.Description,
        StartDateTime: this.addTaskModel.StartDateTime,
        Status: this.addTaskModel.Status
      }

      console.log("Payload ", payload);

      this.service.addSubtask(payload,this.addTaskModel.userId,this.taskId ).subscribe((res: any) => {
        console.log("Response of Add subtask", res)

      })
    }

    this.router.navigate(['/subTask',this.taskId])
}
}