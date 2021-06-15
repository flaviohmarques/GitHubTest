import { Component, OnInit } from '@angular/core';
import { Product } from '@app/models/Product';
import { ShoppingCart, ShoppingCartItem } from '@app/models/ShoppingCart';
import { finalize } from 'rxjs/operators';
import { ShoppingService } from './shopping.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public ShoppingCart: ShoppingCart = new ShoppingCart();
  Products: Product[];
  isLoading = true;
  

  constructor(private shoppingService: ShoppingService) {}

  ngOnInit() {
    this.isLoading = true;
    this.shoppingService
      .getAllProducts()
      .pipe(
        finalize(() => {
          this.isLoading = false;
        })
      )
      .subscribe((products: Product[]) => {
        console.log(products);
        this.Products = products;
      });
  }


}
