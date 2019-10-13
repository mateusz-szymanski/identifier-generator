import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { IdentifierDataService } from '../identifier-data-service';
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
  isLoading = false;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private identifierDataService: IdentifierDataService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.loadData(params.get('factoryCode'), params.get('categoryCode'));
    });
  }

  private loadData(factoryCode: string, categoryCode: string) {
    this.isLoading = true;

    this.identifierDataService.getIdentifierHistory(factoryCode, categoryCode).subscribe((data) => {
      this.dataSource = new MatTableDataSource<IdentifierHistoryEntry>(data);
      this.dataSource.paginator = this.paginator;
      this.isLoading = false;
    });
  }

}
