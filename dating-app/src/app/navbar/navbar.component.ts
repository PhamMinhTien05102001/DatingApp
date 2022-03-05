import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../_model/UserLogin';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  user: UserLogin = { username : 'wabson0', password : 'string'};

  constructor(public accountsService: AccountsService) { }

  ngOnInit(): void {

  }

  login(){
    this.accountsService.login(this.user).subscribe({
      next : (response) => {
      },
      error : (error) => console.log(error)});
   };
}
