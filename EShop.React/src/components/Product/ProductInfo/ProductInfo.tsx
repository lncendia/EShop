import ContentBlock from "../../../UI/ContentBlock/ContentBlock.tsx";
import ProductActions from "../../../UI/ProductActions/ProductActions.tsx";
import ProductCard from "../../../UI/ProductCard/ProductCard.tsx";

interface ProductInfoProps {
    id: string
    name: string
    description: string,
    price: number
    photoUrl: string
    inCompare: boolean
    inFavorite: boolean
    inShoppingCart: boolean
    className: string
    categoryName: string,
    countType: number
    onAddToCart: () => void
    onAddToFavorite: () => void
    onAddToCompare: () => void
}

const ProductInfo = (props: ProductInfoProps) => {
    return (
        <ContentBlock className={props.className}>
            <ProductCard {...props}>
                <ProductActions {...props}/>
            </ProductCard>
        </ContentBlock>
    );
};

export default ProductInfo;