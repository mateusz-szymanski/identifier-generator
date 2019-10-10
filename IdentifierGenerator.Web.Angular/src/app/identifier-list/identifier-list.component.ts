import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { delay } from 'q';

interface Identifier {
  factory: string;
  category: string;
  currentValue: number;
}

class IdentifierDataService {

  async get(): Promise<Identifier[]> {
    await delay(5000);

    let promise = Promise.resolve(DATA);
    return promise;
  }

}

const DATA: Identifier[] = [
  { factory: "F001", category: "C001", currentValue: 1 },
  { factory: "F002", category: "C001", currentValue: 2 },
  { factory: "F003", category: "C001", currentValue: 422 },
  { factory: "F004", category: "C001", currentValue: 2312 },
  { factory: "F005", category: "C001", currentValue: 123 },
  { factory: "F006", category: "C001", currentValue: 342 },
  { factory: "F007", category: "C001", currentValue: 1 },
  { factory: "F008", category: "C001", currentValue: 2 },
  { factory: "F009", category: "C001", currentValue: 12354 },
  { factory: "F010", category: "C001", currentValue: 7 },
  { factory: "F011", category: "C001", currentValue: 1 },
  { factory: "F012", category: "C001", currentValue: 3 },
  { factory: "F013", category: "C001", currentValue: 1 },
  { factory: "F014", category: "C001", currentValue: 1 },
  { factory: "F015", category: "C001", currentValue: 23 },
  { factory: "F016", category: "C001", currentValue: 1 },
  { factory: "F017", category: "C001", currentValue: 1 },
];

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

  constructor() { }

  ngOnInit(): void {
    this.initializeData();
  }

  private initializeData() {
    this.isLoading = true;
    let service = new IdentifierDataService();
    service.get().then((data) => {
      this.dataSource = new MatTableDataSource<Identifier>(data);
      this.dataSource.paginator = this.paginator;
    }).catch((reason) => {
      console.log(reason);
    }).finally(() => {
      this.isLoading = false;
    });
  }

}
