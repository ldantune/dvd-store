import { Film } from "./Film";
import { Store } from "./Store";

export interface Inventory {
    inventoryId: number;
    filmId: number;
    storeId: number;
    store: Store;
    lastUpdate: string;
    film: Film;
}
