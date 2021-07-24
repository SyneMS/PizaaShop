import { pizzaIngradients } from "./pizzaIngradients.model";

export interface pizzaDetails {
    pizzaId: number,
    pizzaName?: string,
    pizzaPic?: string,
    pizzaPrize?: number,
    pizzaIngradients?: pizzaIngradients[]
}