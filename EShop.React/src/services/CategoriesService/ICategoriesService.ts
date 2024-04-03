import {Category, CategoryShort} from "./Models/Categories.ts";

export interface ICategoriesService {

    get(id: string): Promise<Category>
    getAll(): Promise<CategoryShort[]>
}