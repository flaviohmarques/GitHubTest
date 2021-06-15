export interface Product {
  id: number;
  name: string;
  price: number;
  promotion: string;
  promotionType: Promotions;
}

export enum Promotions {
  None,
  BuyOneGetOneFree,
  TreeForTenEuro,
}
