import {Col, Row} from "react-bootstrap";
import InfiniteScroll from "react-infinite-scroll-component";
import Spinner from "../../../UI/Spinner/Spinner.tsx";
import {ProductItemData} from "../ProductItem/ProductItemData.ts";
import ProductItem from "../ProductItem/ProductItem.tsx";

export interface ProductsCatalogProps {
    products: ProductItemData[],
    className?: string,
    hasMore: boolean,
    next: () => void,
    onAddToCart: (item: ProductItemData) => void
    onAddToFavorite: (item: ProductItemData) => void
    onAddToCompare: (item: ProductItemData) => void,
    onClick: (item: ProductItemData) => void
}

const ProductsCatalog = (props: ProductsCatalogProps) => {

    const scrollProps = {
        dataLength: props.products.length,
        next: props.next,
        hasMore: props.hasMore,
        loader: <Spinner/>,
        className: props.className
    }

    return (
        <InfiniteScroll {...scrollProps}>
            <Row className="m-0 gy-4">
                {props.products.map(product =>
                    <Col lg={4} xl={3} sm={6} key={product.id}>
                        <ProductItem product={product}
                                     onClick={() => props.onClick(product)}
                                     onAddToCart={() => props.onAddToCart(product)}
                                     onAddToFavorite={() => props.onAddToFavorite(product)}
                                     onAddToCompare={() => props.onAddToCompare(product)}/>
                    </Col>
                )}
            </Row>
        </InfiniteScroll>
    );
};

export default ProductsCatalog;