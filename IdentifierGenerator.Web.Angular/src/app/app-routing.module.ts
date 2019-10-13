import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IdentifierListComponent } from './identifier-list/identifier-list.component';
import { IdentifierHistoryComponent } from './identifier-history/identifier-history.component';

const routes: Routes = [
  { path: "list", component: IdentifierListComponent },
  { path: ":factoryCode/:categoryCode", component: IdentifierHistoryComponent },
  {
    path: "",
    redirectTo: '/list',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
