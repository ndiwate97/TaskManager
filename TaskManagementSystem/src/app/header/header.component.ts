import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userName : any = localStorage.getItem('UserName')

  constructor(private router: Router) { }

  ngOnInit() {
    this.userName= localStorage.getItem('UserName');
  }

  logout(){
    localStorage.clear();
    
    this.router.navigate(['/'])
  }

}
