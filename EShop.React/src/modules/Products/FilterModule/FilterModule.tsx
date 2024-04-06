import AttributeSelectModule from "./AttributeSelectModule.tsx";
import {Button, Col, Row} from "react-bootstrap";
import {AttributeOption} from "./AttributeSelectOption.ts";
import PriceSelectModule from "./PriceSelectModule.tsx";

interface FilterModuleProps {
    readonly attributes: AttributeOption[],
    readonly onChecked: (attribute: string, value: string, checked: boolean) => void
    readonly onPriceChange: (minPrice?: number, maxPrice?: number) => void
    readonly onReset: () => void,
    readonly className?: string
}

const FilterModule = ({className, attributes, onChecked, onPriceChange, onReset}: FilterModuleProps) => {

    return (
        <Row className={`${className} gy-2`}>
            <Col sm={6} lg={4} xl={3}>
                <PriceSelectModule onChange={onPriceChange}/>
            </Col>
            {attributes.map(a => {
                return (
                    <Col key={a.name} sm={6} lg={4} xl={3}>
                        <AttributeSelectModule onChecked={onChecked} attribute={a}/>
                    </Col>
                )
            })}
            <Col sm={6} lg={4} xl={3}>
                <Button variant="danger" className="w-100" onClick={onReset}>Сбросить</Button>
            </Col>
        </Row>
    );
};

export default FilterModule;