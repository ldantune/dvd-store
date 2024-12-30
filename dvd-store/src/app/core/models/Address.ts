import { City } from "./City";

export interface Address {
    addressId: number;
    address1: string;
    address2: string;
    district: string;
    postalCode: string;
    phone: string;
    lastUpdate: string;
    cityId: number;
    city: City;
}
