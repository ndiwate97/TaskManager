//importing RouterModule and Routes so the app can have routing functionality
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import, ourComponent, will give the Router somewhere to go
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


/* Routes tell the Router which view to display 
 path: a string that matches the URL in the browser address bar.
 component: the component that the router should create when navigating to this route.*/
const routes: Routes = [
  { path: '' , component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
