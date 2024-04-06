import ContentBlock from "../../../UI/ContentBlock/ContentBlock.tsx";
import ProductCard from "../../../UI/ProductCard/ProductCard.tsx";
import {FavoriteItemData} from "./FavoriteItemData.ts";
import {Button} from "react-bootstrap";

interface FavoriteItemProps {
    data: FavoriteItemData,
    className?: string
    onProduct: () => void
    onRemove: () => void
}

const FavoriteItem = ({data, className, onProduct, onRemove}: FavoriteItemProps) => {
    return (
        <ContentBlock className={className}>
            <ProductCard {...data}>
                <Button onClick={onProduct} variant="outline-primary" className="shadow-0 me-1">
                    Перейти к товару
                </Button>
                <Button onClick={onRemove} variant="outline-danger" className="shadow-0 me-1">
                    Убрать из избранного
                </Button>
            </ProductCard>
        </ContentBlock>
    );
};

export default FavoriteItem;