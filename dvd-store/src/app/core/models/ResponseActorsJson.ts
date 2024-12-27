import { Actor } from './Actor';

export interface ResponseActorsJson {
  actors: Actor[];
  totalItems: number;
  pageNumber: number;
  pageSize: number;
}
