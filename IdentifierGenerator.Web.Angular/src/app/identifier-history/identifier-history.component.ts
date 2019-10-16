import { Component, OnInit, ViewChild } from '@angular/core';
import { IdentifierHistoryEntry } from '../identifier';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-identifier-history',
  templateUrl: './identifier-history.component.html',
  styleUrls: ['./identifier-history.component.scss']
})
export class IdentifierHistoryComponent implements OnInit {
  dataSource: MatTableDataSource<IdentifierHistoryEntry>;
  visibleColumns = ['createdOn', 'code'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.data.subscribe((data: { identifierHistory: IdentifierHistoryEntry[] }) => {
      this.dataSource = new MatTableDataSource<IdentifierHistoryEntry>(data.identifierHistory);
      this.dataSource.paginator = this.paginator;
    });
  }

}
