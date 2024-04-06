import {UserProduct, UserProductCount} from "./Models/UserProducts.ts";

export interface IProfileService {
    addToFavorite(id: string): Promise<void>;

    addToShoppingCart(id: string, count: number): Promise<void>;

    removeFromFavorite(id: string): Promise<void>;

    removeFromShoppingCart(id: string): Promise<void>;

    favorite(): Promise<UserProduct[]>

    shoppingCart(): Promise<UserProductCount[]>
}