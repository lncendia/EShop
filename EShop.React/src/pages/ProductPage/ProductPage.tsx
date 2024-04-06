import {useLocation} from "react-router-dom";
import ProductInfoModule from "../../modules/Product/ProductInfoModule/ProductInfoModule.tsx";
import {useCallback, useEffect, useState} from "react";
import {Product} from "../../services/ProductsService/Models/Products.ts";
import {useInjection} from "inversify-react";
import {IProductsService} from "../../services/ProductsService/IProductsService.ts";
import TextBlock from "../../UI/TextBlock/TextBlock.tsx";
import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";
import ProductAttributesModule from "../../modules/Product/ProductAttributesModule/ProductAttributesModule.tsx";

const ProductPage = () => {

    const {state} = useLocation();

    const [product, setProduct] = useState<Product>();
    const productsService = useInjection<IProductsService>('ProductsService');

    useEffect(() => {
        if (!state?.id) return
        productsService.get(state.id).then(setProduct)
    }, [state, productsService]);

    const addToFavorite = useCallback(() => {
        setProduct(prev => {
            if (!prev) return prev
            return {...prev, inFavorite: true}
        })
    }, []);

    const onAddToCart = useCallback(() => {
        setProduct(prev => {
            if (!prev) return prev
            return {...prev, inShoppingCart: true}
        })
    }, [])


    if (!product) return <TextBlock className="mt-5" text="Товар не найден"/>

    return (
        <>
            <ProductInfoModule className="mt-5" product={product} addToFavorite={addToFavorite} addToCart={onAddToCart}/>
            <BlockTitle className="mt-5" title='Характеристики'/>
            <ProductAttributesModule attributes={product.attributes}/>
        </>
    )
};

export default ProductPage;