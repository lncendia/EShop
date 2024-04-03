import {useCallback, useEffect, useState} from 'react';
import {useInjection} from "inversify-react";
import {IProductsService} from "../../../services/FilmsService/IProductsService.ts";
import {useNavigate} from "react-router-dom";
import NoData from "../../../UI/NoData/NoData.tsx";
import {ProductItemData} from "../../../components/Products/ProductItem/ProductItemData.ts";
import ProductsCatalog from "../../../components/Products/ProductsCatalog/ProductsCatalog.tsx";
import {SearchProductsQuery} from "../../../services/FilmsService/InputModels/SearchProductsQuery.ts";

interface ProductsModuleProps extends SearchProductsQuery {
    className?: string
}

const ProductsModule = (props: ProductsModuleProps) => {

    const [products, setProducts] = useState<ProductItemData[]>([]);
    const [page, setPage] = useState(1);
    const [hasMore, setHasMore] = useState(false);
    const productsService = useInjection<IProductsService>('ProductsService');

    // Навигационный хук
    const navigate = useNavigate();


    useEffect(() => {
        const processFilms = async () => {
            const response = await productsService.search({
                ...props
            })

            setPage(2);
            setHasMore(response.totalPages > 1)
            setProducts(response.list)
        };

        processFilms().then()
    }, [props]); // Эффект будет вызываться при каждом изменении `genre`

    const next = useCallback(async () => {
        const response = await productsService.search({
            ...props,
            page: page
        })
        setPage(page + 1);
        setHasMore(response.totalPages !== page)
        setProducts(prev => [...prev, ...response.list])
    }, [props, page, productsService])

    const onSelect = useCallback((film: ProductItemData) => {
        navigate('/film', {state: {id: film.id}})
    }, [navigate])

    if (products.length === 0) return <NoData className="mt-5" text="Товары не найдены"/>

    return (
        <ProductsCatalog hasMore={hasMore} next={next} products={products} onAddToCart={onSelect}
                         onAddToFavorite={onSelect}/>
    );
};

export default ProductsModule;