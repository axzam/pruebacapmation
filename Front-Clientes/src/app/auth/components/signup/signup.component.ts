import { Component } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { CognitoUserPool, CognitoUserAttribute } from 'amazon-cognito-identity-js'
import { Iuser } from '../../../models/iuser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  
  email: string = '';
  givenName: string = '';
  password: string = '';

  constructor(
    private router: Router
  ) {}
  onRegister(): void {
    
    var poolData = {
      UserPoolId: environment.UserPoolId, // Your user pool id here
      ClientId: environment.ClientId, // Your client id here
    };

    var userPool = new CognitoUserPool(poolData);

    var iuser: Iuser = {
      email: this.email,
      given_name: this.givenName
    }
  
    const attributeList = Object.keys(iuser).map(key => new CognitoUserAttribute({
      Name: key,
      Value: iuser[key]
    }));

    userPool.signUp(this.email, this.password, attributeList, [], (err, result) => {
      
      if (err) {
        alert(err.message || JSON.stringify(err));
        return;
      }
      var newUser = result?.user;
      console.log(JSON.stringify(newUser));
      alert('We have sent you an email to activate your account');
      this.router.navigate(['/login']);
    });

  }

}
