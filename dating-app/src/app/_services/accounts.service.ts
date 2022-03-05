import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { __values } from 'tslib';
import { UserRegister, UserToken } from '../_model/User';
import { UserLogin } from '../_model/UserLogin';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  httpOption = {
    headers : new HttpHeaders({'Content-Type' : 'application/json'}),
  }

  baseUrl = 'https://localhost:5001/api/Accounts';
  private currentUser = new BehaviorSubject<UserToken|null>(null)
  currentUser$ = this.currentUser.asObservable();

  constructor(private httpClient: HttpClient) { }
  
  login(userLogin : UserLogin) : Observable<any>{
    return this.httpClient.post<any>(`${this.baseUrl}/login`, userLogin, this.httpOption)
               .pipe(
                 map((response: UserToken) => {
                   const user = response;
                   if(user){
                     localStorage.setItem('userToken', JSON.stringify(user))
                     this.currentUser.next(user);
                   }
                 })
               );
  }

  logout(){
    localStorage.removeItem('userToken');
    this.currentUser.next(null);
  }

  register(user: UserRegister){
    return this.httpClient.post<any>(`${this.baseUrl}/register`, user, this.httpOption)
                          .pipe(
                            map((response: UserToken) => {
                              const user = response;
                              if(user){
                                localStorage.setItem('userToken', JSON.stringify(user))
                                this.currentUser.next(user);
                              }
                            })
                          );
  }

  refreshToken(){
    const localObj = localStorage.getItem(`userToken`)
    if(localObj){
      let user = JSON.parse( localObj );
      if(user){
        this.currentUser.next(user);
        return;
      }
      else{
        this.logout();
      }
    }
  }
}
