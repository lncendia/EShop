import {Container} from "inversify";
import {AuthService} from "../services/AuthService/AuthService.ts";
import {ProductsService} from "../services/FilmsService/ProductsService.ts";
import axios from "axios";
import {IAuthService} from "../services/AuthService/IAuthService.ts";
import {IProductsService} from "../services/FilmsService/IProductsService.ts";
import {ICategoriesService} from "../services/CategoriesService/ICategoriesService.ts";
import {CategoriesService} from "../services/CategoriesService/CategoriesService.ts";


// const config: UserManagerSettings = {
//
//     // URL-адрес OpenID Connect провайдера
//     authority: "https://localhost:10001",
//
//     // Идентификатор клиента
//     client_id: "overoom_react",
//
//     // URI перенаправления после успешной аутентификации
//     redirect_uri: "https://localhost:5173/signin-oidc",
//
//     // Тип ответа при аутентификации
//     response_type: "code",
//
//     // Запрашиваемые области доступа
//     scope: "openid profile roles Films Rooms",
//
//     // URI перенаправления после выхода из системы
//     post_logout_redirect_uri: "https://localhost:5173/signout-oidc",
//
//     // Флаг автоматического тихого обновления токена доступа
//     automaticSilentRenew: true,
//
//     // URI перенаправления для тихого обновления токена доступа
//     silent_redirect_uri: "https://localhost:5173/signin-silent-oidc",
//
//     // Хранилище состояния пользователя
//     userStore: new WebStorageStateStore({store: localStorage}),
// };

// Создаем контейнер
const container = new Container();

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7193/api/'
});

container.bind<IAuthService>('AuthService')
    .to(AuthService)
    .inSingletonScope();

container.bind<IProductsService>('ProductsService')
    .toDynamicValue(() => new ProductsService(axiosInstance))
    .inSingletonScope();

container.bind<ICategoriesService>('CategoriesService')
    .toDynamicValue(() => new CategoriesService(axiosInstance))
    .inSingletonScope();

// configureAxiosAuthorization(axiosInstance, container)

export default container;

// function configureAxiosAuthorization(axiosInstance: AxiosInstance, container: Container): void {
//     axiosInstance.interceptors.request.use(async config => {
//         const userManager = container.get<UserManager>('UserManager');
//         const user = await userManager.getUser();
//         if (user && user.access_token) {
//             config.headers.Authorization = `Bearer ${user.access_token}`;
//         }
//         return config;
//     });
// }