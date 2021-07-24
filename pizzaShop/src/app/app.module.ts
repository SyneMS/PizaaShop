import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DafaultPizzaModule } from './pizza/dafault-pizza.module';
import { CustomPizzaModule } from './custom-pizza/custom-pizza.module';
import { HttpClientModule } from '@angular/common/http';
import { FooterTemplateComponent } from '../app/pizza/footer-template.component';



@NgModule({
  declarations: [
    AppComponent,
    FooterTemplateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DafaultPizzaModule,
    CustomPizzaModule,
    HttpClientModule,
    FormsModule,
    NgxSpinnerModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
