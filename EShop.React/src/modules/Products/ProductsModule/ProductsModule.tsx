import {SearchProductsQuery} from "../../../services/ProductsService/InputModels/SearchProductsQuery.ts";
import {Product} from "../../../services/ProductsService/Models/Products.ts";
import {useCallback, useEffect, useMemo, useState} from "react";
import {useInjection} from "inversify-react";
import {IProductsService} from "../../../services/ProductsService/IProductsService.ts";
import {useCompare} from "../../../contexts/CompareContext/CompareContext.tsx";
import {useNavigate} from "react-router-dom";
import {ProductItemData} from "../../../components/Catalog/ProductItem/ProductItemData.ts";
import TextBlock from "../../../UI/TextBlock/TextBlock.tsx";
import ProductsCatalog from "../../../components/Catalog/ProductsCatalog/ProductsCatalog.tsx";
import {IProfileService} from "../../../services/ProfileService/IProfileService.ts";

interface ProductsModuleProps extends SearchProductsQuery {
    className?: string
}

const ProductsModule = (props: ProductsModuleProps) => {

    const [catalog, setCatalog] = useState<Product[]>([]);
    const [page, setPage] = useState(1);
    const [hasMore, setHasMore] = useState(false);
    const {products, addProduct} = useCompare()

    const productsService = useInjection<IProductsService>('ProductsService');
    const profileService = useInjection<IProfileService>('ProfileService');

    // Навигационный хук
    const navigate = useNavigate();

    useEffect(() => {
        const processProducts = async () => {
            const response = await productsService.search({
                ...props
            })

            setPage(2);
            setHasMore(response.totalPages > 1)
            setCatalog(response.list)
        };

        processProducts().then()
    }, [props, productsService]);

    const next = useCallback(async () => {
        const response = await productsService.search({
            ...props,
            page: page
        })
        setPage(page + 1);
        setHasMore(response.totalPages !== page)
        setCatalog(prev => [...prev, ...response.list])
    }, [props, page, productsService])

    const items = useMemo(() => {
        return catalog.map<ProductItemData>(p => {
            return {...p, inCompare: products.some(c => c == p.id)}
        })
    }, [catalog, products])

    const onClick = useCallback((product: ProductItemData) => {
        navigate('/product', {state: {id: product.id}})
    }, [navigate])

    const onAddToCompare = useCallback((product: ProductItemData) => {
        addProduct(product.id)
    }, [addProduct])

    const onAddToCart = useCallback(async (product: ProductItemData) => {
        await profileService.addToShoppingCart(product.id, 1)
        setCatalog(prev => prev.map(p => {
            if (p.id == product.id) {
                return {...p, inShoppingCart: true}
            }
            return p
        }))
    }, [profileService])

    const onAddToFavorite = useCallback(async (product: ProductItemData) => {
        await profileService.addToFavorite(product.id)
        setCatalog(prev => prev.map(p => {
            if (p.id == product.id) {
                return {...p, inFavorite: true}
            }
            return p
        }))
    }, [profileService])

    if (items.length === 0) return <TextBlock className="mt-5" text="Товары не найдены"/>

    return (
        <ProductsCatalog hasMore={hasMore} next={next} products={items} onAddToCart={onAddToCart}
                         onAddToFavorite={onAddToFavorite} onAddToCompare={onAddToCompare} onClick={onClick}/>
    );
};

export default ProductsModule;