import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../_model/User';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isRegisterMode: boolean = false;
  user : UserRegister = {
    username : "Tien",
    email : "Tien@gmail.com",
    password : 'string'
  };
  constructor() { }

  ngOnInit(): void {
  }

  cancelRegisterMode(event : boolean){
    this.isRegisterMode = event
  }
}
