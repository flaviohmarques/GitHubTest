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

  addToCart(product: Product) {
    if (this.ShoppingCart.shoppingCartItems) {
      let itemFound = this.ShoppingCart.shoppingCartItems.find((x) => x.item == product.name);
      if (itemFound) {
        this.ProcessFoundItem(itemFound);
      } else {
        this.ShoppingCart.shoppingCartItems.push(
          new ShoppingCartItem(product.name, 1, product.price, product.promotionType, product.promotion)
        );
      }
      this.CalculateShoppingCartTotal();
    } else {
      this.NewInstanceOfShoppingCart(product);
    }
  }

  
  clearCart() {
    this.ShoppingCart.shoppingCartItems = new Array<ShoppingCartItem>();
    this.ShoppingCart.total = 0;
  }



  private NewInstanceOfShoppingCart(product: Product) {
    this.ShoppingCart.shoppingCartItems = new Array<ShoppingCartItem>();
    this.ShoppingCart.shoppingCartItems.push(
      new ShoppingCartItem(product.name, 1, product.price, product.promotionType, product.promotion)
    );
    this.ShoppingCart.total = product.price;
  }

  private CalculateShoppingCartTotal() {
    this.ShoppingCart.total = 0;
    this.ShoppingCart.shoppingCartItems.forEach((shoppingCartItem) => {
      this.ShoppingCart.total = this.ShoppingCart.total + shoppingCartItem.total;
    });
  }

  private ProcessFoundItem(itemFound: ShoppingCartItem) {
    itemFound.quantity++;
    if (itemFound.promotion == 1 && itemFound.quantity > 1) {
      this.ApplyPromotion1(itemFound);
    } else if (itemFound.promotion == 2 && itemFound.quantity >= 3) {
      this.ApplyPromotion2(itemFound);
    } else {
      itemFound.total = itemFound.quantity * itemFound.price;
    }
  }

  private ApplyPromotion1(itemFound: ShoppingCartItem) {
    let qtdPromotion1 = itemFound.quantity;
    if (qtdPromotion1 % 2 === 0) {
      itemFound.total = (qtdPromotion1 / 2) * itemFound.price;
    } else {
      qtdPromotion1--;
      itemFound.total = (qtdPromotion1 / 2) * itemFound.price + itemFound.price;
    }
  }

  private ApplyPromotion2(itemFound: ShoppingCartItem) {
    let qtdPromotion2 = itemFound.quantity;
    if (qtdPromotion2 % 3 === 0) {
      let qtd = qtdPromotion2 / 3;
      itemFound.total = qtd * 10;
    } else {
      let quotient = Math.floor(qtdPromotion2 / 3);
      let remainder = qtdPromotion2 % 3;

      itemFound.total = quotient * 10 + remainder * itemFound.price;
    }
  }
}


