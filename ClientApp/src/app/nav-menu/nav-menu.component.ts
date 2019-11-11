import { Component } from '@angular/core';
import { AuthorizeService, IUser } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  user$: Observable<IUser>;

  constructor(authorizeService: AuthorizeService) {
    this.user$ = authorizeService.getUser();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
