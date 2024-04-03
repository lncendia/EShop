import {ProductShort, Product} from "./Models/Products.ts";
import {SearchProductsQuery} from "./InputModels/SearchProductsQuery.ts";
import {List} from "../Common/Models/List.ts";

export interface IProductsService {
    search(query: SearchProductsQuery): Promise<List<ProductShort>>

    popular(count?: number): Promise<ProductShort[]>

    get(id: string): Promise<Product>
}