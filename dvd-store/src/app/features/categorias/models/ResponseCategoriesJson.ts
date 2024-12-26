import { Category } from "./Category";

export interface ResponseCategoriesJson {
    categories: Category[];
    totalItems: number;
    pageNumber: number;
    pageSize: number;
  }