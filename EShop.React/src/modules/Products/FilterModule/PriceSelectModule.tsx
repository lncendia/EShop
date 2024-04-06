import {useCallback, useState} from 'react';
import AttributeItem from "../../../components/Catalog/AttributeItem/AttributeItem.tsx";
import PriceForm from "./PriceForm.tsx";
import {number} from "yup";

interface PriceSelectModuleProps {
    onChange: (minPrice?: number, maxPrice?: number) => void
}

const PriceSelectModule = ({onChange}: PriceSelectModuleProps) => {

    const [open, setOpen] = useState(false)

    const handleChange = useCallback((minPrice: string, maxPrice: string) => {
        const min = minPrice == '' ? undefined: Number(minPrice)
        const max = maxPrice == '' ? undefined: Number(maxPrice)
        onChange(min, max)
    }, [onChange]);

    return (
        <AttributeItem name='Цена' isOpened={open} onClick={() => setOpen(prev => !prev)}>
            <PriceForm onChange={handleChange}/>
        </AttributeItem>
    )
};

export default PriceSelectModule;