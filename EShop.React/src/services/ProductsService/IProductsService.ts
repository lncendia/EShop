import {Product} from "./Models/Products.ts";
import {SearchProductsQuery} from "./InputModels/SearchProductsQuery.ts";
import {List} from "../Common/Models/List.ts";

export interface IProductsService {

    search(query: SearchProductsQuery): Promise<List<Product>>

    get(id: string): Promise<Product>

    getByIds(ids: string[]): Promise<Product[]>
}