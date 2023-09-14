import { AuthService } from '../../auth/services/auth.service'
import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';



export const homeGuard: CanActivateFn = (route, state) => {
  const router = inject( Router );
  const authService = inject( AuthService );
  var isAuth = authService.isAuth();
  if(!isAuth)
  {
    router.navigate(['/']);
    return false;
  }

  return true;
};
