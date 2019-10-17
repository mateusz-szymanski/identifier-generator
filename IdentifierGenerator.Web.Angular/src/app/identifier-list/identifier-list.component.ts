import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Identifier } from '../identifier';
import { IdentifierDataService } from '../identifier-data-service';
import { ActivatedRoute } from '@angular/router';
import { MessenagerService } from '../messenager.service';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { IdentifierGenerateFormComponent } from '../identifier-generate-form/identifier-generate-form.component';

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
  isLoading = false;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private route: ActivatedRoute,
    private identifierDataService: IdentifierDataService,
    private messenagerService: MessenagerService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.messenagerService.identifierAddedMessage.subscribe(() => this.reload());
    this.route.data.subscribe((data: { identifiers: Identifier[] }) => this.fillData(data.identifiers));
  }

  private reload() {
    this.isLoading = true;
    this.identifierDataService.getIdentifiers().subscribe((data) => {
      this.fillData(data);
      this.isLoading = false;
    });
  }

  private fillData(data: Identifier[]) {
    const extendedData = data.map((el) => {
      return { isLoading: false, ...el };
    });

    this.dataSource = new MatTableDataSource<IdentifierEntry>(extendedData);
    this.dataSource.paginator = this.paginator;
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

  openPopup() {
    const config: MatDialogConfig = { disableClose: true };
    this.dialog.open(IdentifierGenerateFormComponent, config);
  }

}
