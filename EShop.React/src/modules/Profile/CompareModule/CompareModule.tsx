import {useInjection} from "inversify-react";
import {IProductsService} from "../../../services/ProductsService/IProductsService.ts";
import {useCallback, useEffect, useState} from "react";
import {Product} from "../../../services/ProductsService/Models/Products.ts";
import {useCompare} from "../../../contexts/CompareContext/CompareContext.tsx";
import CompareTable from "../../../components/Profile/CompareTable/CompareTable.tsx";
import TextBlock from "../../../UI/TextBlock/TextBlock.tsx";
import {CompareItemData} from "../../../components/Profile/CompareTable/CompareItemData.ts";
import {useNavigate} from "react-router-dom";

const CompareModule = ({className}: { className?: string }) => {
    const [items, setItems] = useState<Product[]>([]);
    const productsService = useInjection<IProductsService>('ProductsService');
    const {products, removeProduct} = useCompare()

    const navigate = useNavigate();

    useEffect(() => {
        if (products.length == 0) {
            setItems([])
            return
        }
        productsService.getByIds(products).then(p => setItems(p))
    }, [products]);

    const onClick = useCallback((product: CompareItemData) => {
        navigate('/product', {state: {id: product.id}})
    }, [navigate])

    const onRemove = useCallback((item: CompareItemData) => {
        removeProduct(item.id)
    }, [removeProduct]);

    if (items.length == 0) return <TextBlock className={className} text="Пусто"/>

    return <CompareTable className={className} items={items} onRemove={onRemove} onClick={onClick}/>
};

export default CompareModule;