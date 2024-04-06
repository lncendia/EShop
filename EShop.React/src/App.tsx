import {createBrowserRouter, RouterProvider} from "react-router-dom"
import SignInPage from "./pages/SignInPage/SignInPage"
import LayoutPage from "./pages/LayoutPage/LayoutPage"
import CatalogPage from "./pages/CatalogPage/CatalogPage.tsx"
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css'
import ConfirmEmailPage from "./pages/ConfirmEmailPage/ConfirmEmailPage.tsx";
import ComparePage from "./pages/ComparePage/ComparePage.tsx";
import ProductPage from "./pages/ProductPage/ProductPage.tsx";
import FavoritePage from "./pages/FavoritePage/FavoritePage.tsx";
import ShoppingCartPage from "./pages/ShoppingCartPage/ShoppingCartPage.tsx";

// Основной класс приложения
const App = () => {

    // Создаем объект BrowserRouter для маршрутизации страниц
    const router = createBrowserRouter([
        {
            // Основой элемент - шаблонный 
            element: <LayoutPage/>,

            // Массив дочерних элементов
            children: [
                {
                    path: '/catalog',
                    element: <CatalogPage/>
                },
                {
                    path: '/signIn',
                    element: <SignInPage/>
                },
                {
                    path: "/confirmEmail",
                    element: <ConfirmEmailPage/>
                },
                {
                    path: "/compare",
                    element: <ComparePage/>
                },
                {
                    path: "/product",
                    element: <ProductPage/>
                },
                {
                    path: "/favorite",
                    element: <FavoritePage/>
                },
                {
                    path: "/cart",
                    element: <ShoppingCartPage/>
                }
            ]
        }
    ])

    // Возвращаем маршрутизированные страницы
    return (
        <RouterProvider router={router}/>
    )
}

export default App
