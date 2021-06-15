import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Product } from '@app/models/Product';

const routes = {
  quote: (c: RandomQuoteContext) => `/jokes/random?category=${c.category}`,
};

export interface RandomQuoteContext {
  // The quote's category: 'dev', 'explicit'...
  category: string;
}

@Injectable({
  providedIn: 'root',
})
export class ShoppingService {
  constructor(private httpClient: HttpClient) {}

  getAllProducts(): Observable<Product[]> {
    debugger;
    return this.httpClient.get<Product[]>('http://localhost:5000/Shopping');
  }
}
