import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService, IUser } from './authorize.service';
import { map, tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';

type CanActivateResult = boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>;

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private authorizeService: AuthorizeService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): CanActivateResult {
    return this.authorizeService.getUser().pipe(
      map(user => user.Admin && user.Admin === 'true'),
      tap(result => {
        if (!result) {
          window.alert('Not Authorized');
        }
      })
    );
  }

}
