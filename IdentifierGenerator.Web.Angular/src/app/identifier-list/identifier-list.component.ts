import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Identifier } from '../identifier-history-entry';
import { IdentifierDataService } from '../identifier-data-service';

@Component({
  selector: 'app-identifier-list',
  templateUrl: './identifier-list.component.html',
  styleUrls: ['./identifier-list.component.scss']
})
export class IdentifierListComponent implements OnInit {
  visibleColumns = ['factoryCode', 'categoryCode', 'currentValue', 'actions'];
  dataSource = new MatTableDataSource<Identifier>();
  isLoading = true;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private identifierDataService: IdentifierDataService) { }

  ngOnInit(): void {
    this.initializeData();
  }

  generateNew(identifier: Identifier){
    this.identifierDataService.generateNewIdentifier(identifier.factoryCode, identifier.categoryCode)
    .subscribe(() => identifier.value++);
  }

  private initializeData() {
    this.isLoading = true;

    this.identifierDataService.getIdentifiers().subscribe((data) => {
      this.dataSource = new MatTableDataSource<Identifier>(data);
      this.dataSource.paginator = this.paginator;
      this.isLoading = false;
    });
  }

}
