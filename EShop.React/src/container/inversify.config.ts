import {Container} from "inversify";
import {AccountService} from "../services/AccountService/AccountService.ts";
import {ProductsService} from "../services/ProductsService/ProductsService.ts";
import axios, {AxiosInstance} from "axios";
import {IAccountService} from "../services/AccountService/IAccountService.ts";
import {IProductsService} from "../services/ProductsService/IProductsService.ts";
import {ICategoriesService} from "../services/CategoriesService/ICategoriesService.ts";
import {CategoriesService} from "../services/CategoriesService/CategoriesService.ts";
import {IRegistrationService} from "../services/RegistrationService/IRegistrationService.ts";
import {RegistrationService} from "../services/RegistrationService/RegistrationService.ts";
import {IProfileService} from "../services/ProfileService/IProfileService.ts";
import {ProfileService} from "../services/ProfileService/ProfileService.ts";

// Создаем контейнер
const container = new Container();

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7193',
    paramsSerializer: params => {
        return Object.entries(params)
            .map(([key, value]) => {
                if (Array.isArray(value)) {
                    return value.map(v => `${key}=${encodeURIComponent(v)}`).join('&');
                }
                return `${key}=${encodeURIComponent(value)}`;
            })
            .join('&');
    },
});

container.bind<AxiosInstance>('AxiosInstance')
    .toDynamicValue(() => axiosInstance)
    .inSingletonScope();

container.bind<IAccountService>('AccountService')
    .toDynamicValue(() => new AccountService(axiosInstance))
    .inSingletonScope();

container.bind<IRegistrationService>('RegistrationService')
    .toDynamicValue(() => new RegistrationService(axiosInstance))
    .inSingletonScope();

container.bind<IProductsService>('ProductsService')
    .toDynamicValue(() => new ProductsService(axiosInstance))
    .inSingletonScope();

container.bind<ICategoriesService>('CategoriesService')
    .toDynamicValue(() => new CategoriesService(axiosInstance))
    .inSingletonScope();

container.bind<IProfileService>('ProfileService')
    .toDynamicValue(() => new ProfileService(axiosInstance))
    .inSingletonScope();

export default container;