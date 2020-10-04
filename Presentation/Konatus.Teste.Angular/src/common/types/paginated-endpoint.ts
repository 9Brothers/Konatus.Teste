import { Observable } from 'rxjs';
import { Page } from '../interfaces/page';
import { PageRequest } from '../interfaces/page-request';

export type PaginatedEndpoint<T> = (req: PageRequest<T>) => Observable<Page<T>>