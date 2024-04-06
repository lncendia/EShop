import {Attribute} from "../../../services/ProductsService/Models/Products.ts";
import ProductAttributes from "../../../components/Product/ProductAttributes/ProductAttributes.tsx";

const ProductAttributesModule = ({attributes, className = ''}: { attributes: Attribute, className?: string }) => {

    return <ProductAttributes className={className} attributes={attributes}/>
};

export default ProductAttributesModule;