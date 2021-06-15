import { Promotions } from './Product';

export class ShoppingCart {
  shoppingCartItems: ShoppingCartItem[];
  total: number;
}

export class ShoppingCartItem {
  item: string;
  quantity: number;
  price: number;
  total: number;
  promotion: Promotions;
  promotionApplied: string;
  constructor(item: string, quantity: number, price: number, promotion: Promotions, promotionApplied: string) {
    this.item = item;
    this.quantity = quantity;
    this.price = price;
    this.total = price;
    this.promotion = promotion;
    this.promotionApplied = promotionApplied;
  }
}
