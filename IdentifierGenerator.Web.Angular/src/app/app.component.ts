import { Component } from '@angular/core';
import { Router, RouterEvent, ResolveStart, ResolveEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isLoading = false;

  constructor(router: Router) {
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
}
