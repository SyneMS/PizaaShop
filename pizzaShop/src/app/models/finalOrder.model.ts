import { ingradients } from "./ingradients.model";
import { pizzaDetails } from "./pizzaDetails.model";

export interface finalOrder {
    pizzaDetails: pizzaDetails[],
    finalPrize: number
}