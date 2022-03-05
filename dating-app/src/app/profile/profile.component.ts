import { Component, OnInit } from '@angular/core';
import { Member } from '../_model/member';
import { AccountsService } from '../_services/accounts.service';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  profile: Member = new Member();
  constructor(private membersService: MembersService, private accountsService: AccountsService) { 

  }

  ngOnInit(): void {
    let username = "";
    console.log("1");
    this.accountsService .currentUser$.subscribe({
      "next" : (account) => {
        var _username = account?.userName;
        if(_username){
          username = _username;
        }
      },
      "error" : (error) => console.log(error)
    })
    console.log("2");
    this.membersService.getMemberByUsername(username).subscribe(
      {
        "next" : member => {
          this.profile = member;
          console.log(member);
        },
        "error": error => console.log(error)
      }
    )
  }

  submit() {
    this.membersService.updateProfile(this.profile).subscribe();
  }
}
