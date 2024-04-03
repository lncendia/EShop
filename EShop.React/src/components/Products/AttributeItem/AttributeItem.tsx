import React from 'react';
import {Button} from "react-bootstrap";
import styles from "./AttributeItem.module.css"

interface AttributeItemProps {
    name: string,
    isOpened: boolean,
    onClick: () => void,
    children: React.ReactNode
}

const AttributeItem = (props: AttributeItemProps) => {
    return (
        <>
            <Button className="w-100" onClick={props.onClick} variant="outline-primary">
                {props.name}
            </Button>
            <div className={`position-relative ${props.isOpened ? '' : 'd-none'}`}>
                <div className={styles.list}>
                    {props.children}
                </div>
            </div>
        </>
    );
};

export default AttributeItem;