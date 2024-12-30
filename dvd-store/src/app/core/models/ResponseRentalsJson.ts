import { Rental } from "./Rental";

export interface ResponseRentalsJson {
    rentals: Rental[];
    totalItems: number;
    pageNumber: number;
    pageSize: number;
}
