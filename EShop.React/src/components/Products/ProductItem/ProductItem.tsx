import {ProductItemData} from "./ProductItemData.ts";
import {Button, Card} from "react-bootstrap";
import styles from "./ProductItem.module.css"

export interface ProductItemProps {
    product: ProductItemData,
    onAddToCart: () => void
    onAddToFavorite: () => void
}

const ProductItem = ({product, onAddToCart, onAddToFavorite}: ProductItemProps) => {

    return (
        <Card className="card w-100 h-100 shadow">
            <Card.Img className={styles.photo} src={product.photoUrl}/>
            <Card.Body>
                <Card.Title>{product.name}</Card.Title>
                <Card.Text>{product.price} ₽</Card.Text>
            </Card.Body>
            <Card.Footer className="d-flex p-3">
                <Button onClick={onAddToCart} variant="primary" className="shadow-0 me-1">
                    В корзину
                </Button>
                <Button onClick={onAddToFavorite} variant="light" className={`border px-2 py-1 ${styles.iconHover}`}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="text-secondary" viewBox="0 0 16 16">
                        <path fillRule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314"/>
                    </svg>
                </Button>
            </Card.Footer>
        </Card>
    );
}

export default ProductItem;