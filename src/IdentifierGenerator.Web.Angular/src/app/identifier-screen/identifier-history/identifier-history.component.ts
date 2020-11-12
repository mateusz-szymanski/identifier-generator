import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { IdentifierHistoryEntry } from '../../model/identifier-history-entry';

@Component({
  selector: 'app-identifier-history',
  templateUrl: './identifier-history.component.html',
  styleUrls: ['./identifier-history.component.scss']
})
export class IdentifierHistoryComponent implements OnInit {
  dataSource: MatTableDataSource<IdentifierHistoryEntry>;
  visibleColumns = ['code', 'createdOn'];

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
