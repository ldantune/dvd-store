import { Inventory } from "./Inventory";

export interface Rental {
    rentalId: number;
    rentalDate: string;
    inventoryId: number;
    inventory: Inventory;
    customerId: number;
    returnDate: string;
    staffId: number;
    lastUpdate: string;
}
