import { Component } from '@angular/core';
import { Router, RouterEvent, ResolveStart, ResolveEnd } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { IdentifierGenerateFormComponent } from './identifier-generate-form/identifier-generate-form.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isLoading: boolean = false;

  constructor(private dialog: MatDialog, router: Router) {
    router.events.subscribe((routerEvent: RouterEvent) => this.checkRouterEvent(routerEvent));
  }

  private checkRouterEvent(routerEvent: RouterEvent): void {
    if (routerEvent instanceof ResolveStart) {
      this.isLoading = true;
    }

    if (routerEvent instanceof ResolveEnd) {
      this.isLoading = false;
    }
  }

  openPopup() {
    let dialogRef = this.dialog.open(IdentifierGenerateFormComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        let { factoryName, categoryName } = result;
        if (factoryName && categoryName) {
          //reload list
        }
      }
    });
  }
}
