import { Language } from "./Language";

export interface Film {
    filmId: number;
    title: string;
    description: string;
    releaseYear: number;
    languageId: number;
    rentalDuration: number;
    rentalRate: number;
    length: number;
    replacementCost: number;
    rating: string;
    specialFeatures: string;
    lastUpdate: string;
    fullText: string;
    language: Language;
}
