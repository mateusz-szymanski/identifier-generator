import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { IdentifierHistoryResolverService } from './identifier-history-resolver.service';
import { IdentifierHistoryComponent } from './identifier-history/identifier-history.component';
import { IdentifierListResolverService } from './identifier-list-resolver.service';
import { IdentifierListComponent } from './identifier-list/identifier-list.component';

const routes: Routes = [
  {
    path: 'home', component: HomeComponent
  },
  {
    path: 'identifier', component: IdentifierListComponent,
    resolve: {
      identifiers: IdentifierListResolverService
    }
  },
  {
    path: 'identifier/:factoryCode/:categoryCode', component: IdentifierHistoryComponent,
    resolve: {
      identifierHistory: IdentifierHistoryResolverService
    }
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
