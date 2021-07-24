import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finalOrder } from '../models/finalOrder.model';
import { pizzaDetails } from '../models/pizzaDetails.model';
import { PizzaService } from './pizza.service';

@Component({
  selector: 'app-pizza-list',
  templateUrl: './pizza-list.component.html',
  styleUrls: ['./pizza-list.component.css']
})
export class PizzaListComponent implements OnInit {

  pizzaDetails: pizzaDetails[];
  pizzaDetail: pizzaDetails;
  finalOrder: finalOrder;
  constructor(private router: Router, private pizzaService: PizzaService) { }

  ngOnInit(): void {
    //this.finalOrder = {}
    this.pizzaService.getAllDefaultPizza().subscribe(data => this.pizzaDetails = data);
    this.pizzaService.finalOrder.subscribe(data => this.finalOrder = data);
    //if (this.finalOrder == null) {
    this.finalOrder = { pizzaDetails: [], finalPrize: 0 }
    this.pizzaService.setFinalOrder(this.finalOrder);
    //}
  }

  moveToIngradients() {
    if (this.pizzaDetail && this.pizzaDetail.pizzaId) {
      this.router.navigate(['/pizzaIngradients', this.pizzaDetail.pizzaId]);
    } else {
      alert("Please select Pizza of your choice");
    }
  }

  checkValue(pizzaID, event) {
    //alert(pizzaID);
    if (this.pizzaDetail && this.pizzaDetail.pizzaId && event.target.checked == true) {
      alert("You have chosen the Pizza. Kindly uncheck and select another one.");
      event.target.checked = false;
    } else {
      if (event.target.checked) {
        this.pizzaDetail = this.pizzaDetails.filter(detail => detail.pizzaId === pizzaID)[0];
        this.finalOrder.finalPrize = this.pizzaDetail.pizzaPrize;
        this.finalOrder.pizzaDetails.push(this.pizzaDetail);
        this.pizzaService.setFinalOrder(this.finalOrder);
      } else {
        this.pizzaDetail = this.finalOrder.pizzaDetails.filter(detail => detail.pizzaId === pizzaID)[0];
        this.finalOrder.finalPrize = this.finalOrder.finalPrize - this.pizzaDetail.pizzaPrize;
        let index = this.finalOrder.pizzaDetails.indexOf(this.pizzaDetail);
        this.finalOrder.pizzaDetails.splice(index, 1);
        this.pizzaDetail = undefined;
        this.pizzaService.setFinalOrder(this.finalOrder);
      }
    }

  }
}
