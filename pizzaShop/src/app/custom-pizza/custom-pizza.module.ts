import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PizzaCrustComponent } from './pizza-crust.component';

const routes: Routes = [
  { path: 'pizzaCrust', component: PizzaCrustComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class CustomPizzaModule { }
