import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserRegister } from '../_model/User';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {
  @Input() userRegister : UserRegister = new UserRegister();
  @Output() cancelRegister = new EventEmitter();

  constructor(private accountsService: AccountsService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountsService.register(this.userRegister).subscribe({
      next : (response) => {this.cancel()}
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}
