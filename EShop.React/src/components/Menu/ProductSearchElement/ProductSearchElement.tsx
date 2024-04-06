import styles from './ProductSearchElement.module.css'
import {ProductElementData} from "./ProductElementData.ts";

const ProductSearchElement = ({product, onClick}: { product: ProductElementData, onClick: () => void }) => {
    return (
        <div className={styles.element} onClick={onClick}>
            <img className={styles.poster} src={product.photoUrl} alt="Фото"/>
            <div className={styles.title}>
                {product.name}
                <div className={styles.category}>{product.categoryName}</div>
                <div className={styles.price}>{product.price} ₽</div>
            </div>
        </div>
    );
};

export default ProductSearchElement;