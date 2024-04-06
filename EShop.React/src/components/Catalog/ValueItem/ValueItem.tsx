import {Form} from "react-bootstrap";
import {ValueItemData} from "./ValueItemData.ts";
import React, {useCallback} from "react";
import {v4} from 'uuid';
import styles from './ValueItem.module.css'

interface ValueItemProps {
    value: ValueItemData,
    onChanged: (value: boolean) => void
}

const ValueItem = ({value, onChanged}: ValueItemProps) => {

    const handleCheck = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
        onChanged(e.currentTarget.checked)
    }, [onChanged]);

    return (
        <Form.Check id={v4()}>
            <Form.Check.Input checked={value.checked} onChange={handleCheck} type="checkbox"/>
            <Form.Check.Label>{value.value}</Form.Check.Label>
            <span className={styles.desc}>({value.count} шт.)</span>
        </Form.Check>
    );
};

export default ValueItem;