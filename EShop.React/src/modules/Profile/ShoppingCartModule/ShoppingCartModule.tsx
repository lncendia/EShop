import {useCallback, useEffect, useState} from "react";
import {useInjection} from "inversify-react";
import {useNavigate} from "react-router-dom";
import TextBlock from "../../../UI/TextBlock/TextBlock.tsx";
import {IProfileService} from "../../../services/ProfileService/IProfileService.ts";
import {UserProductCount} from "../../../services/ProfileService/Models/UserProducts.ts";
import CartList from "../../../components/Profile/CartList/CartList.tsx";
import {CartItemData} from "../../../components/Profile/CartItem/CartItemData.ts";

const ShoppingCartModule = ({className}: { className?: string }) => {

    const [items, setItems] = useState<UserProductCount[]>([]);
    const profileService = useInjection<IProfileService>('ProfileService');

    const navigate = useNavigate();

    useEffect(() => {
        profileService.shoppingCart().then(p => setItems(p))
    }, []);

    const onProduct = useCallback((product: CartItemData) => {
        navigate('/product', {state: {id: product.id}})
    }, [navigate])

    const onRemove = useCallback(async (product: CartItemData) => {
        await profileService.removeFromShoppingCart(product.id)
        setItems(prev => prev.filter(p => p.id != product.id))
    }, [profileService])

    const onIncrement = useCallback(async (product: CartItemData) => {
        if (product.count == 255) return
        await profileService.addToShoppingCart(product.id, product.count + 1)
        setItems(prev => prev.map(p => {
            if (p.id != product.id) return p
            return {...p, count: p.count + 1}
        }))
    }, [profileService])

    const onDecrement = useCallback(async (product: CartItemData) => {
        if (product.count == 1) return
        await profileService.addToShoppingCart(product.id, product.count - 1)
        setItems(prev => prev.map(p => {
            if (p.id != product.id) return p
            return {...p, count: p.count - 1}
        }))
    }, [profileService])

    if (items.length == 0) return <TextBlock className={className} text="Пусто"/>

    return <CartList onRemove={onRemove} onIncrement={onIncrement} onDecrement={onDecrement} onProduct={onProduct}
                     items={items} className={className}/>
};

export default ShoppingCartModule;