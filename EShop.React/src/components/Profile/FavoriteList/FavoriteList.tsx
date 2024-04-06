import {FavoriteItemData} from "../FavoriteItem/FavoriteItemData.ts";
import FavoriteItem from "../FavoriteItem/FavoriteItem.tsx";

interface FavoriteListProps {
    items: FavoriteItemData[],
    className?: string,
    onProduct: (product: FavoriteItemData) => void
    onRemove: (product: FavoriteItemData) => void
}

const FavoriteList = ({items, className = '', onProduct, onRemove}: FavoriteListProps) => {
    return (
        <div className={className}>
            {items.map(i => <FavoriteItem onProduct={() => onProduct(i)} onRemove={() => onRemove(i)} className="mb-5"
                                          key={i.id} data={i}/>)}
        </div>
    );
};

export default FavoriteList;