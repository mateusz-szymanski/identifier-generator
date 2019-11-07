import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeScreenModule } from './home-screen/home-screen.module';
import { IdentifierScreenModule } from './identifier-screen/identifier-screen.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SharedModule } from './shared/shared.module';
import { AppConfigurationService } from './app-configuration.service';

const appInitializerFn = (appConfig: AppConfigurationService) => {
  return () => {
    return appConfig.loadConfiguration();
  };
};

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    SharedModule,
    HomeScreenModule,
    IdentifierScreenModule,
    AppRoutingModule
  ],
  providers: [
    AppConfigurationService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFn,
      multi: true,
      deps: [AppConfigurationService]
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
