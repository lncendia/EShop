import {AxiosInstance} from "axios";
import {IProfileService} from "./IProfileService.ts";
import {UserProduct, UserProductCount} from "./Models/UserProducts.ts";

export class ProfileService implements IProfileService {

    private axiosInstance: AxiosInstance;

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    async addToFavorite(id: string): Promise<void> {
        await this.axiosInstance.post('api/profile/addToFavorite', {id});
    }

    async addToShoppingCart(id: string, count: number): Promise<void> {
        await this.axiosInstance.post('api/profile/addToShoppingCart', {id, count});
    }

    async removeFromFavorite(id: string): Promise<void> {
        await this.axiosInstance.post('api/profile/removeFromFavorite', {id});
    }

    async removeFromShoppingCart(id: string): Promise<void> {
        await this.axiosInstance.post('api/profile/removeFromShoppingCart', {id});
    }


    async favorite(): Promise<UserProduct[]> {
        const response = await this.axiosInstance.get<UserProduct[]>('api/profile/favorite');
        return response.data

    }

    async shoppingCart(): Promise<UserProductCount[]> {
        const response = await this.axiosInstance.get<UserProductCount[]>('api/profile/shoppingCart');
        return response.data
    }
}