import { Country } from "./Country";

export interface City {
    cityId: number;
    cityName: string;
    countryId: number;
    lastUpdate: string;
    country: Country;
}
