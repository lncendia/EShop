import {ProductItemData} from "./ProductItemData.ts";
import {Card} from "react-bootstrap";
import styles from "./ProductItem.module.css"
import ProductActions from "../../../UI/ProductActions/ProductActions.tsx";

export interface ProductItemProps {
    product: ProductItemData,
    onAddToCart: () => void
    onAddToFavorite: () => void
    onAddToCompare: () => void
    onClick: () => void
}

const ProductItem = ({product, onAddToCart, onAddToFavorite, onAddToCompare, onClick}: ProductItemProps) => {

    return (
        <Card className="card w-100 h-100 shadow">
            <Card.Img className={styles.photo} onClick={onClick} src={product.photoUrl}/>
            <Card.Body className={styles.pointer} onClick={onClick}>
                <Card.Title>{product.name}</Card.Title>
                <Card.Text>{product.price} ₽</Card.Text>
            </Card.Body>
            <Card.Footer className="d-flex p-3">
                <ProductActions {...product} onAddToCompare={onAddToCompare} onAddToCart={onAddToCart} onAddToFavorite={onAddToFavorite}/>
            </Card.Footer>
        </Card>
    );
}

export default ProductItem;