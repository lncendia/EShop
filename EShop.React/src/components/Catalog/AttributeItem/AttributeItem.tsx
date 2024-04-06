import React from 'react';
import {Button} from "react-bootstrap";
import styles from "./AttributeItem.module.css"
import Svg from "../../../UI/Svg/Svg.tsx";

interface AttributeItemProps {
    name: string,
    isOpened: boolean,
    onClick: () => void,
    children: React.ReactNode
}

const getSvg = (open: boolean) => {
    if (!open) return (
        <Svg width={12} height={12} fill="currentColor" className="ms-1" viewBox="0 0 16 16">
            <path
                d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
        </Svg>
    )

    return (
        <Svg width={12} height={12} fill="currentColor" className="ms-1" viewBox="0 0 16 16">
            <path
                d="m7.247 4.86-4.796 5.481c-.566.647-.106 1.659.753 1.659h9.592a1 1 0 0 0 .753-1.659l-4.796-5.48a1 1 0 0 0-1.506 0z"/>
        </Svg>
    )
}

const AttributeItem = (props: AttributeItemProps) => {
    return (
        <>
            <Button className="w-100 h-100" onClick={props.onClick} variant="outline-primary">
                {props.name}
                {getSvg(props.isOpened)}
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