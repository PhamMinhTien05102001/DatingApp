import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../_model/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private httpClient: HttpClient) { }
  baseUrl = 'https://localhost:5001/api/Users';

  public getMembers() : Observable<Member[]>{
    return this.httpClient.get<Member[]>(this.baseUrl);
  }

  public getMemberByUsername(username: string) : Observable<Member>{
    return this.httpClient.get<Member>(`${this.baseUrl}/${username}`);
  }

  public updateProfile(member: Member){
    return this.httpClient.put(this.baseUrl, member, this.httpOptions);
  }
}
