import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeScreenRoutingModule } from './home-screen-routing.module';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    HomeScreenRoutingModule,
    CommonModule,
    SharedModule
  ]
})
export class HomeScreenModule { }
