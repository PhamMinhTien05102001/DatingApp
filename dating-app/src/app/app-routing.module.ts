import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersComponent } from './members/members.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  { path : '', redirectTo: 'home', pathMatch: 'full' },
  { path : 'home', component : HomeComponent },
  { path : 'members', component : MembersComponent },
  { path : 'profile', component : ProfileComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
