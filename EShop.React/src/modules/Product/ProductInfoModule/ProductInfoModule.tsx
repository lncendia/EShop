import {useCallback, useMemo} from "react";
import {Product} from "../../../services/ProductsService/Models/Products.ts";
import {useCompare} from "../../../contexts/CompareContext/CompareContext.tsx";
import ProductInfo from "../../../components/Product/ProductInfo/ProductInfo.tsx";
import {useInjection} from "inversify-react";
import {IProfileService} from "../../../services/ProfileService/IProfileService.ts";

interface ProductInfoModuleProps {
    product: Product,
    className?: string,
    addToFavorite: () => void
    addToCart: () => void
}

const ProductInfoModule = ({product, addToFavorite, addToCart, className = ''}: ProductInfoModuleProps) => {

    const {products, addProduct} = useCompare()
    const profileService = useInjection<IProfileService>('ProfileService');

    const onAddToCompare = useCallback(() => {
        addProduct(product.id)
    }, [addProduct, product.id])

    const onAddToCart = useCallback(async () => {
        await profileService.addToShoppingCart(product.id, 1)
        addToCart()
    }, [profileService, product.id, addToCart])

    const onAddToFavorite = useCallback(async () => {
        await profileService.addToFavorite(product.id)
        addToFavorite()
    }, [profileService, product.id, addToFavorite])

    const item = useMemo(() => {
        return {...product, inCompare: products.some(c => c == product.id)}
    }, [product, products])

    return <ProductInfo className={className} {...item} onAddToFavorite={onAddToFavorite}
                        onAddToCompare={onAddToCompare} onAddToCart={onAddToCart}/>
};

export default ProductInfoModule;