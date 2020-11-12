import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentifierHistoryResolverService } from './identifier-history-resolver.service';
import { IdentifierHistoryComponent } from './identifier-history/identifier-history.component';
import { IdentifierListResolverService } from './identifier-list-resolver.service';
import { IdentifierListComponent } from './identifier-list/identifier-list.component';
import { IdentifierScreenComponent } from './identifier-screen/identifier-screen.component';

const routes: Routes = [
  {
    path: 'identifier',
    component: IdentifierScreenComponent,
    children: [
      {
        path: '', component: IdentifierListComponent,
        resolve: {
          identifiers: IdentifierListResolverService
        }
      },
      {
        path: ':factoryCode/:categoryCode', component: IdentifierHistoryComponent,
        resolve: {
          identifierHistory: IdentifierHistoryResolverService
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentifierScreenRoutingModule { }
