import React, {useState} from "react";
import styles from "./ProductSearch.module.css"
import ProductSearchElement from "../ProductSearchElement/ProductSearchElement.tsx";
import Form from "react-bootstrap/Form";
import {ProductElementData} from "../ProductSearchElement/ProductElementData.ts";

interface ProductSearchProps {
    products: ProductElementData[],
    onSearch: (value: string) => void,
    onClick: (product: ProductElementData) => void
}

const ProductSearch = ({onSearch, products, onClick}: ProductSearchProps) => {

    const [value, setValue] = useState('')
    const [timeoutId, setTimeoutId] = useState<NodeJS.Timeout>()
    const [showProducts, setShowProducts] = useState(false)

    const onInput = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValue(e.target.value)
        setShowProducts(true)
        clearTimeout(timeoutId);
        const thread = setTimeout(async () => {
            onSearch(e.target.value)
        }, 500);

        setTimeoutId(thread)
    }

    const onBlur = () => {
        setTimeout(() =>
            setShowProducts(false), 400
        )
    }

    return (
        <>
            <Form.Control value={value} type="text" placeholder="Поиск" onInput={onInput}
                          onClick={() => setShowProducts(true)} onBlur={onBlur}/>
            {showProducts && products.length !== 0 && <div className={styles.search}>
                {products.map(f => <ProductSearchElement key={f.id} product={f} onClick={() => onClick(f)}/>)}
            </div>}
        </>
    );
};

export default ProductSearch;