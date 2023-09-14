import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CognitoUserPool, CognitoUser, AuthenticationDetails } from 'amazon-cognito-identity-js'
import { environment } from 'src/environments/environment.development';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  email: string = '';
  password: string = '';

  constructor(
    private router: Router

  ) { }
  onLogin(): void
  {
    var poolData = {
      UserPoolId: environment.UserPoolId, // Your user pool id here
      ClientId: environment.ClientId, // Your client id here
    };

    var userPool = new CognitoUserPool(poolData);
    
    var userData = {
      Username: this.email,
      Pool: userPool,
      Password: this.password
    }

    var cognitoUser = new CognitoUser(userData);

    var userAuth = {
      Username: this.email,
      Password: this.password
    }

    var authDetails = new AuthenticationDetails(userAuth);

    cognitoUser.authenticateUser(authDetails, {
      onSuccess: (result) => {
        console.log('Token: '+ result.getAccessToken().getJwtToken());
        this.router.navigate(['/home']);
       },
      onFailure: (err) => {
        alert(err.message || JSON.stringify(err));
      }
    });
  }
}
