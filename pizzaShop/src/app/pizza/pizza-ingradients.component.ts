import { Component, OnInit } from '@angular/core';
import { ingradients } from '../models/ingradients.model';
import { pizzaIngradients } from '../models/pizzaIngradients.model';
import { PizzaService } from './pizza.service';
import { ActivatedRoute } from '@angular/router';
import { finalOrder } from '../models/finalOrder.model';
import { forkJoin } from 'rxjs';
import { NgxSpinnerService } from "ngx-spinner";



@Component({
  selector: 'app-pizza-ingradients',
  templateUrl: './pizza-ingradients.component.html',
  styleUrls: ['./pizza-ingradients.component.css']
})
export class PizzaIngradientsComponent implements OnInit {

  finalOrder: finalOrder;
  ingradients: ingradients[] = [];
  pizzaIngradients: pizzaIngradients[] = [];
  tempPizzaIngradients: pizzaIngradients[] = [];
  pizzaIngradient: pizzaIngradients = <pizzaIngradients>{};
  pizzaId: number;

  constructor(private pizzaService: PizzaService, private activatedRoute: ActivatedRoute, private SpinnerService: NgxSpinnerService) {
  }

  ngOnInit(): void {
    let pizzaIngradient: pizzaIngradients = {
      id: 0,
      pizzaId: 0,
      name: '',
      prize: 0,
      ingradientId: 0
    };
    this.pizzaId = +this.activatedRoute.snapshot.paramMap.get('pizzaId');
    this.pizzaService.getAllIngradients().subscribe(data => this.ingradients = data);
    this.pizzaService.getAllPizzaIngradients(this.pizzaId).subscribe(data => {
      this.pizzaIngradients = data
      this.pizzaService.finalOrder.subscribe(data => this.finalOrder = data);
      if (this.finalOrder == null) {
        this.finalOrder = { pizzaDetails: [], finalPrize: 0 }
      } else {
        let finalPizzaDetail = this.finalOrder.pizzaDetails.find(p => p.pizzaId == this.pizzaId);
        if (finalPizzaDetail.pizzaIngradients == null || finalPizzaDetail.pizzaIngradients == undefined) {
          finalPizzaDetail.pizzaIngradients = [];
        }
        finalPizzaDetail.pizzaIngradients = finalPizzaDetail.pizzaIngradients.concat(this.pizzaIngradients);
      }
      this.pizzaService.setFinalOrder(this.finalOrder);
    });


  }

  addIngadient(id: number, event) {
    if (event.target.checked) {
      let ingradient = this.ingradients.filter(i => i.ingradientId === id)[0];
      // this.pizzaIngradient.pizzaId = this.pizzaId;
      // this.pizzaIngradient.id = id;
      // this.pizzaIngradient.name = ingradient.name;
      // this.pizzaIngradient.prize = ingradient.prize;

      this.pizzaIngradient = Object.assign(ingradient);
      this.pizzaIngradient.pizzaId = this.pizzaId;

      this.tempPizzaIngradients.push(this.pizzaIngradient);
      console.log(this.tempPizzaIngradients.values);
    } else {
      let ingradient = this.tempPizzaIngradients.filter(i => i.ingradientId === id)[0];
      let index = this.tempPizzaIngradients.indexOf(ingradient);
      this.tempPizzaIngradients.splice(index, 1);
    }
  }

  removeIngadient(id: number, event) {
    if (event.target.checked) {
      let ingradient = this.pizzaIngradients.find(i => i.ingradientId === id);
      this.tempPizzaIngradients.push(ingradient);
      console.log(this.tempPizzaIngradients.values);
    } else {
      let ingradient = this.tempPizzaIngradients.filter(i => i.ingradientId === id)[0];
      let index = this.tempPizzaIngradients.indexOf(ingradient);
      this.tempPizzaIngradients.splice(index, 1);
    }
  }

  addSelected() {

    let tpi = Object.assign(this.tempPizzaIngradients);
    let finalPizzaDetail = this.finalOrder.pizzaDetails.find(p => p.pizzaId == this.pizzaId);
    this.pizzaIngradients = this.pizzaIngradients.concat(tpi);
    tpi.forEach(item => {
      let ing = this.ingradients.find(data => data.ingradientId === item.ingradientId);
      let index = this.ingradients.indexOf(ing);
      finalPizzaDetail.pizzaIngradients.push(item);
    });

    tpi.forEach(item => {
      let ing = this.ingradients.find(data => data.ingradientId === item.ingradientId);
      let index = this.ingradients.indexOf(ing);
      this.ingradients.splice(index, 1);
    });



    let ingradiantsTotal = finalPizzaDetail.pizzaIngradients.reduce(function (prev, cur) {
      return prev + cur.prize;
    }, 0);
    this.finalOrder.finalPrize = +(finalPizzaDetail.pizzaPrize + ingradiantsTotal);
    this.pizzaService.setFinalOrder(this.finalOrder);


    this.tempPizzaIngradients = [];


  }

  removeSelected() {
    let tpi = Object.assign(this.tempPizzaIngradients);
    let finalPizzaDetail = this.finalOrder.pizzaDetails.find(p => p.pizzaId == this.pizzaId);
    tpi.forEach(item => {
      let ing = this.pizzaIngradients.find(data => data.ingradientId === item.ingradientId);
      let index = this.pizzaIngradients.indexOf(ing);
      this.pizzaIngradients.splice(index, 1);
      this.ingradients.push(ing);
      finalPizzaDetail.pizzaIngradients.splice(index, 1);
    });

    let ingradiantsTotal = finalPizzaDetail.pizzaIngradients.reduce(function (prev, cur) {
      return prev + cur.prize;
    }, 0);
    this.finalOrder.finalPrize = +(finalPizzaDetail.pizzaPrize + ingradiantsTotal);
    this.pizzaService.setFinalOrder(this.finalOrder);

    this.tempPizzaIngradients = [];

  }


}
