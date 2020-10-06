import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';


const routes: Routes = [
  { path: 'employee', redirectTo: 'employee/list', pathMatch: 'full' },
  { path: 'employee/list', component: ListComponent },
  { path: 'employee/add', component: AddComponent }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
