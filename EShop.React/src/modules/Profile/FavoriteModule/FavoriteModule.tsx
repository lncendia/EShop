import FavoriteList from "../../../components/Profile/FavoriteList/FavoriteList.tsx";
import {useCallback, useEffect, useState} from "react";
import {useInjection} from "inversify-react";
import {useNavigate} from "react-router-dom";
import TextBlock from "../../../UI/TextBlock/TextBlock.tsx";
import {IProfileService} from "../../../services/ProfileService/IProfileService.ts";
import {UserProduct} from "../../../services/ProfileService/Models/UserProducts.ts";
import {FavoriteItemData} from "../../../components/Profile/FavoriteItem/FavoriteItemData.ts";

const FavoriteModule = ({className}: { className?: string }) => {

    const [items, setItems] = useState<UserProduct[]>([]);
    const profileService = useInjection<IProfileService>('ProfileService');

    const navigate = useNavigate();

    useEffect(() => {
        profileService.favorite().then(p => setItems(p))
    }, []);

    const onProduct = useCallback((product: FavoriteItemData) => {
        navigate('/product', {state: {id: product.id}})
    }, [navigate])

    const onRemove = useCallback(async (product: FavoriteItemData) => {
        await profileService.removeFromFavorite(product.id)
        setItems(prev => prev.filter(p => p.id != product.id))
    }, [profileService])

    if (items.length == 0) return <TextBlock className={className} text="Пусто"/>

    return <FavoriteList onRemove={onRemove} onProduct={onProduct} items={items} className={className}/>
};

export default FavoriteModule;