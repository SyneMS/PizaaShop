import { Component, OnInit } from '@angular/core';
import { finalOrder } from '../models/finalOrder.model';
import { PizzaService } from './pizza.service';
import { Router } from '@angular/router';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-footer-template',
  templateUrl: './footer-template.component.html',
  styleUrls: ['./footer-template.component.css']
})
export class FooterTemplateComponent implements OnInit {

  finalOrder: finalOrder;
  showPlaceOrder: boolean = false;
  constructor(private pizzaService: PizzaService, private router: Router, private SpinnerService: NgxSpinnerService) {

  }

  ngOnInit(): void {
    this.pizzaService.finalOrder.subscribe(data => {
      this.finalOrder = data;
      if (this.finalOrder && this.finalOrder.pizzaDetails && this.finalOrder.pizzaDetails.length > 0) {
        this.showPlaceOrder = true;
      } else { this.showPlaceOrder = false; }
    });
    if (this.finalOrder == null) {
      this.finalOrder = { pizzaDetails: [], finalPrize: 0 }
    }


  }

  placeOrder() {
    this.SpinnerService.show();  
    this.pizzaService.placeOrder(this.finalOrder).subscribe(data => {
      alert("Order placed successfully with order number :" + data);
      this.finalOrder = { pizzaDetails: [], finalPrize: 0 }
      this.pizzaService.setFinalOrder(this.finalOrder);
      this.router.navigate(['defaultPizza/pizzaList']);
      this.SpinnerService.hide();  
    });
  }

}
