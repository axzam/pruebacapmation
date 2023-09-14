import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { SignupComponent } from './auth/components/signup/signup.component';
import { HomeComponent } from './views/components/home/home.component';
import { loginGuard } from './core/guards/login.guard';
import { homeGuard } from './core/guards/home.guard';

const routes: Routes = [
  {path: '', component: LoginComponent, canActivate: [loginGuard]},
  {path: 'login', component: LoginComponent, canActivate: [loginGuard]},
  {path: 'signup', component: SignupComponent, canActivate: [loginGuard]},
  {path: 'home', component: HomeComponent, canActivate: [homeGuard]},
  {path: '**', redirectTo: '', pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
 