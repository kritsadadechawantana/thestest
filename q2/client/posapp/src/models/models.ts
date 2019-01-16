export class CartVM{
    Id: string;
    CartItems: CartItemVM[];
    TotalPrice: number;
    DiscountPrice: number; 
}

export class CartItemVM{
    ProductId: string;
    Name: string;
    Quantity: number;
    PricePerUnit: number;
    TotalPrice: number;
}