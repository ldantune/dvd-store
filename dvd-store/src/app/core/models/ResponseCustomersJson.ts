import { Customer } from './Customer';

export interface ResponseCustomersJson {
  customers: Customer[];
  totalItems: number;
  pageNumber: number;
  pageSize: number;
}
