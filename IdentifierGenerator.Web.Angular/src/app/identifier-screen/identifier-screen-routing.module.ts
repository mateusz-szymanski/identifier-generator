import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentifierHistoryResolverService } from './identifier-history-resolver.service';
import { IdentifierListResolverService } from './identifier-list-resolver.service';
import { IdentifierHistoryComponent } from './identifier-history/identifier-history.component';
import { IdentifierListComponent } from './identifier-list/identifier-list.component';

const routes: Routes = [
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
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentifierScreenRoutingModule { }
