import { Subject, Observable } from 'rxjs';
import { startWith, switchMap, share, pluck } from 'rxjs/operators';
import { Page } from './interfaces/page';
import { SimpleDataSource } from './interfaces/simple-datasource';
import { Sort } from './interfaces/sort';
import { PaginatedEndpoint } from './types/paginated-endpoint';

export class PaginatedDataSource<T> implements SimpleDataSource<T> {
    private pageNumber = new Subject<number>();
    private sort = new Subject<Sort<T>>();
  
    public page$: Observable<Page<T>>;
  
    constructor(
      endpoint: PaginatedEndpoint<T>,
      initialSort: Sort<T>,
      size = 20) {
        this.page$ = this.sort.pipe(
          startWith(initialSort),
          switchMap(sort => this.pageNumber.pipe(
            startWith(0),
            switchMap(page => endpoint({page, sort, size}))
          )),
          share()
        )
    }
  
    sortBy(sort: Sort<T>): void {
      this.sort.next(sort);
    }
  
    fetch(page: number): void {
      this.pageNumber.next(page);
    }
  
    connect(): Observable<T[]> {
      return this.page$.pipe(pluck('content'));
    }
  
    disconnect(): void {}
  }
