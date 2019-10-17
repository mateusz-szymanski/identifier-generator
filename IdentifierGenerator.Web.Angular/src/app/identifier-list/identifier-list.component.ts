import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Identifier } from '../identifier';
import { IdentifierDataService } from '../identifier-data-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-identifier-list',
  templateUrl: './identifier-list.component.html',
  styleUrls: ['./identifier-list.component.scss']
})
export class IdentifierListComponent implements OnInit {
  visibleColumns = ['factoryCode', 'categoryCode', 'currentValue', 'actions'];
  dataSource = new MatTableDataSource<Identifier>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private route: ActivatedRoute, private identifierDataService: IdentifierDataService) { }

  ngOnInit(): void {
    this.route.data.subscribe((data: { identifiers: Identifier[] }) => {
      this.dataSource = new MatTableDataSource<Identifier>(data.identifiers);
      this.dataSource.paginator = this.paginator;
    });
  }

  generateNew(identifier: Identifier) {
    this.identifierDataService
      .generateNewIdentifier(identifier.factoryCode, identifier.categoryCode)
      .subscribe(() => identifier.value++);
  }

}
