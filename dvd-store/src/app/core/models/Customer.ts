import { Address } from "./Address";
import { Store } from "./Store";

export interface Customer {
    customerId: number;
    firstName: string;
    lastName: string;
    email: string;
    activebool: boolean;
    createDate: string;
    lastUpdate: string;
    active: number;
    storeId: number;
    store: Store;
    addressId: number;
    address: Address;
}
