import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_model/User';
import { AccountsService } from './_services/accounts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'dating-app';
  users: User[] = [];

  /**
   *
   */
  constructor(private httpClient: HttpClient, public accountsService: AccountsService) {

  }
  ngOnInit(): void {
    //this.fetchUsers();
    this.accountsService.refreshToken();
  }

  // ngOnInit(): void {
  //   this.fetchUsers();
  // }

  // fetchUsers(){
  //   this.httpClient.get('https://localhost:5001/api/Users').subscribe((response) => {
  //     this.users = response as User[];
  //   });
  // }
}
