import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Identifier } from '../identifier';
import { IdentifierDataService } from '../identifier-data-service';
import { ActivatedRoute } from '@angular/router';

interface IdentifierEntry extends Identifier {
  isLoading: boolean;
}

@Component({
  selector: 'app-identifier-list',
  templateUrl: './identifier-list.component.html',
  styleUrls: ['./identifier-list.component.scss']
})
export class IdentifierListComponent implements OnInit {
  visibleColumns = ['factoryCode', 'categoryCode', 'currentValue', 'actions'];
  dataSource = new MatTableDataSource<IdentifierEntry>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private route: ActivatedRoute, private identifierDataService: IdentifierDataService) { }

  ngOnInit(): void {
    this.route.data.subscribe((data: { identifiers: Identifier[] }) => {
      let extendedData = data.identifiers.map((el) => {
        return { isLoading: false, ...el };
      });

      this.dataSource = new MatTableDataSource<IdentifierEntry>(extendedData);
      this.dataSource.paginator = this.paginator;
    });
  }

  generateNew(identifierEntry: IdentifierEntry) {
    identifierEntry.isLoading = true;
    this.identifierDataService
      .generateNewIdentifier(identifierEntry.factoryCode, identifierEntry.categoryCode)
      .subscribe(() => {
        identifierEntry.value++;
        identifierEntry.isLoading = false;
      });
  }

}
