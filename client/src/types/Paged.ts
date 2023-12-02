export interface Paged<T> {
  items: T[];
  pageSize: number;
  totalCount: number;
  currentPage: number;
}
