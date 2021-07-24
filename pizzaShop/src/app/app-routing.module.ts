import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'defaultPizza', loadChildren: () => import('./pizza/dafault-pizza.module')
      .then(m => m.DafaultPizzaModule)
  },
  {
    path: 'customPizza', loadChildren: () => import('./custom-pizza/custom-pizza.module')
      .then(m => m.CustomPizzaModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
