import {CartItemData} from "../CartItem/CartItemData.ts";
import CartItem from "../CartItem/CartItem.tsx";

interface CartListProps {
    items: CartItemData[],
    className?: string,
    onProduct: (product: CartItemData) => void
    onRemove: (product: CartItemData) => void
    onIncrement: (product: CartItemData) => void
    onDecrement: (product: CartItemData) => void
}

const CartList = ({items, className = '', onProduct, onRemove, onIncrement, onDecrement}: CartListProps) => {
    return (
        <div className={className}>
            {items.map(i =>
                <CartItem className="mb-5" key={i.id} data={i}
                          onProduct={() => onProduct(i)}
                          onRemove={() => onRemove(i)}
                          onIncrement={() => onIncrement(i)}
                          onDecrement={() => onDecrement(i)}
                />)}
        </div>
    );
};

export default CartList;