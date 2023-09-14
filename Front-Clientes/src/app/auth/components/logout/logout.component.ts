import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CognitoUserPool, CognitoUserAttribute } from 'amazon-cognito-identity-js'
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {

  attributes: CognitoUserAttribute[] = []; //atributos de usuario
  
  poolData = {  //user pool de aws cognito
    UserPoolId: environment.UserPoolId, 
    ClientId: environment.ClientId, 
  };

  constructor(
    private router: Router,
  ) { }

  onLogout(): void {
    
    var userPool = new CognitoUserPool(this.poolData);
    var currentUser = userPool.getCurrentUser();
    currentUser?.signOut();
    this.router.navigate(['']);
  }

  getAttributes(): void {
    var userPool = new CognitoUserPool(this.poolData);
    var currentUser = userPool.getCurrentUser();
    currentUser?.getSession(( (err: any, session: any) => {
       
      if (err) {
        alert(err.message || JSON.stringify(err));
        return;
      }
      currentUser?.getUserAttributes((err, result) => {
        if (err) {
          alert(err.message || JSON.stringify(err));
          return;
        }

        this.attributes = result;
        this.attributes.forEach((attr: CognitoUserAttribute) => {
          console.log( attr.Name + ' = '+ attr.Value );          
        });
      });
    } ));
  } 

}
