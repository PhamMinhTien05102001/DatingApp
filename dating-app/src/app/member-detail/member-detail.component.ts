import { Component, Input, OnInit } from '@angular/core';
import { Member } from '../_model/member';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})
export class MemberDetailComponent implements OnInit {
  @Input() member: Member = new Member();
  constructor() { }

  ngOnInit(): void {
  }

}
