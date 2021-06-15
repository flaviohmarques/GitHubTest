import { Type } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { CoreModule } from '@core';
import { ShoppingService } from './shopping.service';

describe('ShoppingService', () => {
  let shoppingService: ShoppingService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [CoreModule, HttpClientTestingModule],
      providers: [ShoppingService],
    });

    shoppingService = TestBed.inject(ShoppingService);
    httpMock = TestBed.inject(HttpTestingController as Type<HttpTestingController>);
  });

  afterEach(() => {
    httpMock.verify();
  });

  describe('getRandomQuote', () => {
    it('should return an array of products', () => {
      // Act
      const productsSubscription = shoppingService.getAllProducts();

      // Assert
      productsSubscription.subscribe((collection: any[]) => {
        expect(collection).toHaveSize(4);
      });
    });
  });
});
