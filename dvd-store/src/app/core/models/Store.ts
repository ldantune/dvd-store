import { Address } from "./Address";

export interface Store {
    storeId: number;
    managerStaffId: number;
    addressId: number;
    lastUpdate: string;
    address: Address;
}
