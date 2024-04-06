import {ValueItemData} from "../ValueItem/ValueItemData.ts";
import ValueItem from "../ValueItem/ValueItem.tsx";

interface ValuesListProps {
    readonly values: ValueItemData[]
    onChecked: (value: string, checked: boolean) => void
}

const ValuesList = ({values, onChecked}: ValuesListProps) => {
    return (
        <>
            {values.map(v => {
                return (
                    <ValueItem key={v.value} value={v} onChanged={(checked) => onChecked(v.value, checked)}/>
                )
            })}
        </>
    );
};

export default ValuesList;