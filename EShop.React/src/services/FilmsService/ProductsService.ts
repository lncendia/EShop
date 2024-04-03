import {AxiosInstance} from "axios";
import {IProductsService} from "./IProductsService.ts";
import {Product, ProductShort} from "./Models/Products.ts";
import {SearchProductsQuery} from "./InputModels/SearchProductsQuery.ts";
import {List} from "../Common/Models/List.ts";


// Экспорт класса FilmsService для его использования из других модулей
export class ProductsService implements IProductsService {

    // Сервис для отправки запросов по API
    private axiosInstance: AxiosInstance

    constructor(axiosInstance: AxiosInstance) {
        this.axiosInstance = axiosInstance;
    }

    // Возвращает Promise, который содержит массив объектов EmployeeModel
    public async search(query: SearchProductsQuery): Promise<List<ProductShort>> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.post<List<ProductShort>>('product', query);

        // Возвращаем данные
        return response.data
    }

    public async popular(count?: number): Promise<ProductShort[]> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.get<ProductShort[]>('films/popular', {params: {count: count}});

        // Возвращаем данные
        return response.data;
    }

    public async get(id: string): Promise<Product> {

        // Отправка запроса к серверу для получения списка фильмов
        const response = await this.axiosInstance.get<Product>(`product/${id}`);

        // Возвращаем данные
        return response.data
    }
}

