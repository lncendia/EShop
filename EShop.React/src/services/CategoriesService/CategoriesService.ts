import {AxiosInstance} from "axios";
import {ICategoriesService} from "./ICategoriesService.ts";
import {Category, CategoryShort} from "./Models/Categories.ts";

export class CategoriesService implements ICategoriesService {

    // Сервис для отправки запросов по API
    private axiosInstance: AxiosInstance

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    public async get(id: string): Promise<Category> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.get<Category>(`api/category/${id}`);

        // Возвращаем данные
        return response.data
    }

    public async getAll(): Promise<CategoryShort[]> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.get<CategoryShort[]>(`api/category`);

        // Возвращаем данные
        return response.data
    }
}

