import {Button} from "react-bootstrap";
import styles from "./ProductActions.module.css";

interface ProductActionsProps {
    onAddToCart: () => void
    onAddToFavorite: () => void
    onAddToCompare: () => void
    inShoppingCart: boolean
    inFavorite: boolean
    inCompare: boolean
}

const ProductActions = (props: ProductActionsProps) => {
    return (
        <>
            <Button disabled={props.inShoppingCart} onClick={props.onAddToCart} variant="primary"
                    className="shadow-0 me-1">
                В корзину
            </Button>
            <Button disabled={props.inFavorite} onClick={props.onAddToFavorite} variant="light"
                    className={`px-2 py-1 ${styles.btn}`}>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                     viewBox="0 0 16 16">
                    <path fillRule="evenodd"
                          d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314"/>
                </svg>
            </Button>
            <Button disabled={props.inCompare} onClick={props.onAddToCompare} variant="light"
                    className={`px-2 py-1 ms-1 ${styles.btn}`}>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                     viewBox="0 0 16 16">
                    <path fillRule="evenodd"
                          d="M1 11.5a.5.5 0 0 0 .5.5h11.793l-3.147 3.146a.5.5 0 0 0 .708.708l4-4a.5.5 0 0 0 0-.708l-4-4a.5.5 0 0 0-.708.708L13.293 11H1.5a.5.5 0 0 0-.5.5m14-7a.5.5 0 0 1-.5.5H2.707l3.147 3.146a.5.5 0 1 1-.708.708l-4-4a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 4H14.5a.5.5 0 0 1 .5.5"/>
                </svg>
            </Button>
        </>
    );
};

export default ProductActions;