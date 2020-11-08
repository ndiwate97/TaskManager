import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppServiceService } from 'src/app/AppServices/app-service.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {

  addTaskModel: any = {
    "TaskName": "",
    "Description": "",
    "StartDateTime": "",
    "Status": "",
    "userName": localStorage.getItem('UserName'),
    "userId": localStorage.getItem('sessionId')
  }
  constructor(private service: AppServiceService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(formvalid, formvalue) {
    console.log("formvalid", formvalid)
    console.log("formvalue", formvalue)
    console.log(this.addTaskModel)

    if (formvalid) {

      const payload =
      {
        TaskName: this.addTaskModel.TaskName,
        Description: this.addTaskModel.Description,
        StartDateTime: this.addTaskModel.StartDateTime,
        Status: this.addTaskModel.Status
      }

      console.log("Payload ", payload);

      this.service.addTask(payload,this.addTaskModel.userId).subscribe((res: any) => {
        console.log("Response of Register", res)

      })
    }

    this.router.navigate(['/task'])
  }


}
