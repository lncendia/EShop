import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";
import ProductsModule from "../../modules/Products/ProductsModule/ProductsModule.tsx";
import {useLocation} from "react-router-dom";
import {useCallback, useEffect, useMemo, useState} from "react";
import {Category} from "../../services/CategoriesService/Models/Categories.ts";
import {useInjection} from "inversify-react";
import {ICategoriesService} from "../../services/CategoriesService/ICategoriesService.ts";
import FilterModule from "../../modules/Products/FilterModule/FilterModule.tsx";
import {AttributeOption} from "../../modules/Products/FilterModule/AttributeSelectOption.ts";
import BadgesModule from "../../modules/Products/BadgesModule/BadgesModule.tsx";

const CatalogPage = () => {

    const {state} = useLocation();

    const [category, setCategory] = useState<Category>()

    const [attributes, setAttributes] = useState<AttributeOption[]>([])

    const [price, setPrice] = useState<[number?, number?]>([])

    const categoryService = useInjection<ICategoriesService>('CategoriesService');

    useEffect(() => {
        setCategory(undefined);
        setAttributes([]);
        setPrice([]);
        if (!state?.id) return
        categoryService.get(state.id).then(c => {
            setCategory(c)
            setAttributes(c.attributes.map(a => {
                return {
                    name: a.name,
                    values: a.values.map(v => {
                        return {
                            ...v,
                            checked: false
                        }
                    })
                }
            }))
        })
    }, [state]);

    const handleCheck = useCallback((attribute: string, value: string, checked: boolean) => {
        setAttributes(prevState => prevState.map(p =>
            p.name === attribute
                ? {...p, values: p.values.map(v => v.value === value ? {...v, checked} : v)}
                : p
        ));
    }, []);

    const handleChangePrice = useCallback((min?: number, max?: number) => {
        setPrice([min, max])
    }, []);

    const handleReset = useCallback(() => {
        setAttributes(prevState => prevState.map(p => ({
            name: p.name,
            values: p.values.map(v => ({...v, checked: false}))
        })));
        setPrice([]);
    }, []);

    const attributesQuery = useMemo(() => {
        return attributes
            .filter(a => a.values.some(v => v.checked))
            .map(a => {
                return {
                    name: a.name,
                    values: a.values.filter(v => v.checked).map(v => v.value)
                }
            })
    }, [attributes])


    return (
        <>
            <FilterModule className="mt-4" attributes={attributes} onChecked={handleCheck}
                          onPriceChange={handleChangePrice}
                          onReset={handleReset}/>
            <BadgesModule badges={attributesQuery}
                          onRemove={(attribute, value) => handleCheck(attribute, value, false)}/>
            <BlockTitle title={category?.name ?? "Каталог"} className="mt-5 mb-3"/>
            <ProductsModule className="mt-5" categoryId={state?.id} attributes={attributesQuery} minPrice={price[0]}
                            maxPrice={price[1]}/>
        </>
    );
};

export default CatalogPage;