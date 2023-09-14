import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service'

export const loginGuard: CanActivateFn = (route, state) => {

  const router = inject( Router );
  const authService = inject( AuthService );
  var isAuth = authService.isAuth();
  if(isAuth)
  {
    router.navigate(['/home']);
    return false;
  }

  
  return true;
};
