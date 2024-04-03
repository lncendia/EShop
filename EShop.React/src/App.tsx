import {createBrowserRouter, RouterProvider} from "react-router-dom"
import SignInPage from "./pages/SignInPage/SignInPage"
import LayoutPage from "./pages/LayoutPage/LayoutPage"
import SignOutPage from "./pages/SignOutPage/SignOutPage"
import SignInSilentPage from "./pages/SignInSilentPage/SignInSilentPage.tsx";
import CatalogPage from "./pages/CatalogPage/CatalogPage.tsx"
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css'

// Основной класс приложения
const App = () => {

    // Создаем объект BrowserRouter для маршрутизации страниц
    const router = createBrowserRouter([
        {
            path: '/signin-oidc',
            element: <SignInPage/>
        },
        {
            path: '/signin-silent-oidc',
            element: <SignInSilentPage/>
        },
        {
            path: '/signout-oidc',
            element: <SignOutPage/>
        },
        {
            // Основой элемент - шаблонный 
            element: <LayoutPage/>,

            // Массив дочерних элементов
            children: [
                {
                    path: '/catalog',
                    element: <CatalogPage/>
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
