//importing RouterModule and Routes so the app can have routing functionality
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import, ourComponent, will give the Router somewhere to go
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { TaskComponent } from './task/task.component';
import { AddTaskComponent } from './task/add-task/add-task.component';
import { EditTaskComponent } from './task/edit-task/edit-task.component';
import { SubtaskComponent } from './subtask/subtask.component';
import { AddSubtaskComponent } from './subtask/add-subtask/add-subtask.component';
import { EditSubtaskComponent } from './subtask/edit-subtask/edit-subtask.component';


/* Routes tell the Router which view to display 
 path: a string that matches the URL in the browser address bar.
 component: the component that the router should create when navigating to this route.*/
const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgotPassword', component: ForgetPasswordComponent },
  { path: 'task', component: TaskComponent },
  { path: 'addTask', component: AddTaskComponent },
  { path: 'editTask/:id', component: EditTaskComponent },
  { path: 'subTask/:id', component: SubtaskComponent },
  { path: 'addSubTask/:id', component: AddSubtaskComponent },
  { path: 'editSubTask/:taskId/:id', component: EditSubtaskComponent },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
