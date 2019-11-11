import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AdminGuard } from 'src/api-authorization/admin.guard';

const routes: Routes = [{
  path: 'admin',
  component: AdminComponent,
  canActivate: [AuthorizeGuard, AdminGuard]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
