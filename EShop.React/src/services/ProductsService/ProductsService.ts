import {AxiosInstance} from "axios";
import {IProductsService} from "./IProductsService.ts";
import {Product} from "./Models/Products.ts";
import {SearchProductsQuery} from "./InputModels/SearchProductsQuery.ts";
import {List} from "../Common/Models/List.ts";


// Экспорт класса ProductsService для его использования из других модулей
export class ProductsService implements IProductsService {

    // Сервис для отправки запросов по API
    private axiosInstance: AxiosInstance

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    // Возвращает Promise, который содержит массив объектов EmployeeModel
    async search(query: SearchProductsQuery): Promise<List<Product>> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.post<List<Product>>('api/product/search', query);

        // Возвращаем данные
        return response.data
    }

    async get(id: string): Promise<Product> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.get<Product>(`api/product/get/${id}`);

        // Возвращаем данные
        return response.data
    }

    async getByIds(ids: string[]): Promise<Product[]> {

        const response = await this.axiosInstance.get<Product[]>(`api/product/getByIds`, {params: {ids}});

        // Возвращаем данные
        return response.data
    }
}

