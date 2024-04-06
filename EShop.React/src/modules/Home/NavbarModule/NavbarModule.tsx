import Navbar from "../../../components/Menu/Navbar/Navbar.tsx";
import {ICategoriesService} from "../../../services/CategoriesService/ICategoriesService.ts";
import {useInjection} from "inversify-react";
import {useCallback, useEffect, useState} from "react";
import {CategoryItem} from "../../../components/Menu/Navbar/CategoryItem.ts";
import {useNavigate} from "react-router-dom";
import {IProductsService} from "../../../services/ProductsService/IProductsService.ts";
import {Product} from "../../../services/ProductsService/Models/Products.ts";
import {useUser} from "../../../contexts/UserContext/UserContext.tsx";
import {ProductElementData} from "../../../components/Menu/ProductSearchElement/ProductElementData.ts";

const NavbarModule = () => {

    const [products, setProducts] = useState<Product[]>([]);
    const productsService = useInjection<IProductsService>('ProductsService');
    const {authorizedUser, setTokens} = useUser()


    const onSearch = useCallback(async (value: string) => {
        if (value === '') setProducts([])
        else {
            const products = await productsService.search({query: value})
            setProducts(products.list)
        }
    }, [productsService])


    const [categories, setCategories] = useState<CategoryItem[]>([]);
    const categoryService = useInjection<ICategoriesService>('CategoriesService');

    useEffect(() => {
        categoryService.getAll().then(c => setCategories(c))
    }, []);

    // Навигационный хук
    const navigate = useNavigate();

    const onCategorySelect = useCallback((item: CategoryItem) => {
        navigate('/catalog', {state: {id: item.id}})
    }, [navigate])

    const onHome = useCallback(() => navigate('/'), [navigate])

    const onCatalog = useCallback(() => navigate('/catalog'), [navigate])

    const onLogin = useCallback(() => navigate('/signIn'), [navigate])

    const onCompare = useCallback(() => navigate('/compare'), [navigate])

    const onFavorite = useCallback(() => navigate('/favorite'), [navigate])

    const onCart = useCallback(() => navigate('/cart'), [navigate])

    const onLogout = useCallback(() => setTokens(undefined), [setTokens])

    const onSelect = useCallback((product: ProductElementData) => {
        navigate('/product', {state: {id: product.id}})
    }, [navigate])


    return (
        <Navbar name={authorizedUser?.name} categories={categories} products={products} onSearch={onSearch}
                onCatalog={onCatalog} onCategorySelect={onCategorySelect} onHome={onHome} onLogin={onLogin}
                onLogout={onLogout} onCompare={onCompare} onProduct={onSelect} onFavorite={onFavorite} onCart={onCart}/>
    );
};

export default NavbarModule;