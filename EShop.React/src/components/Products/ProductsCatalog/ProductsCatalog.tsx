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
                    <Col lg={3} md={4} sm={6} xl={2} key={product.id}>
                        <ProductItem product={product} onAddToCart={() => props.onAddToCart(product)}
                                     onAddToFavorite={() => props.onAddToCart(product)}/>
                    </Col>
                )}
            </Row>
        </InfiniteScroll>
    );
};

export default ProductsCatalog;