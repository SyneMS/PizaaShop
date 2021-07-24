import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzaListComponent } from './pizza-list.component';
import { Routes, RouterModule } from '@angular/router';
import { PizzaIngradientsComponent } from './pizza-ingradients.component';


const routes: Routes = [
  { path: 'pizzaList', component: PizzaListComponent },
  { path: 'pizzaIngradients/:pizzaId', component: PizzaIngradientsComponent },
];


@NgModule({
  declarations: [PizzaListComponent, PizzaIngradientsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class DafaultPizzaModule { }
