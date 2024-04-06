import ContentBlock from "../../../UI/ContentBlock/ContentBlock.tsx";
import ProductCard from "../../../UI/ProductCard/ProductCard.tsx";
import {CartItemData} from "./CartItemData.ts";
import {Button} from "react-bootstrap";
import styles from './CartItem.module.css'

interface FavoriteItemProps {
    data: CartItemData,
    className?: string
    onProduct: () => void
    onRemove: () => void
    onIncrement: () => void
    onDecrement: () => void
}

const CartItem = ({data, className, onProduct, onRemove, onIncrement, onDecrement}: FavoriteItemProps) => {
    return (
        <ContentBlock className={className}>
            <ProductCard {...data}>
                <Button onClick={onDecrement} variant="light" className={`shadow-0 me-1 ${styles.btn}`}>
                    -
                </Button>
                {data.count}
                <Button onClick={onIncrement} variant="light" className={`shadow-0 mx-1 ${styles.btn}`}>
                    +
                </Button>
                <Button onClick={onProduct} variant="outline-primary" className="shadow-0 me-1">
                    Перейти к товару
                </Button>
                <Button onClick={onRemove} variant="outline-danger" className="shadow-0 me-1">
                    Убрать из корзины
                </Button>
            </ProductCard>
        </ContentBlock>
    );
};

export default CartItem;