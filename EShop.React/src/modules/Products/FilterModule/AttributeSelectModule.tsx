import {useCallback, useState} from 'react';
import AttributeItem from "../../../components/Products/AttributeItem/AttributeItem.tsx";
import ValuesList from "../../../components/Products/ValuesList/ValuesList.tsx";
import {AttributeOption} from "./AttributeSelectOption.ts";

interface AttributeSelectModuleProps {
    attribute: AttributeOption,
    onChecked: (attribute: string, value: string, checked: boolean) => void
}

const AttributeSelectModule = ({attribute, onChecked}: AttributeSelectModuleProps) => {

    const [open, setOpen] = useState(false)

    const handleChecked = useCallback((value: string, checked: boolean) => {
        onChecked(attribute.name, value, checked)
    }, [onChecked, attribute.name])

    return (
        <AttributeItem name={attribute.name} isOpened={open} onClick={() => setOpen(prev => !prev)}>
            <ValuesList onChecked={handleChecked} values={attribute.values}/>
        </AttributeItem>
    )
};

export default AttributeSelectModule;