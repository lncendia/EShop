import {Badge, Col, Row} from "react-bootstrap";
import styles from "./ProductCard.module.css"
import Divider from "../Divider/Divider.tsx";
import React from "react";

interface ProductCardProps {
    id: string
    name: string
    description: string,
    price: number
    photoUrl: string
    className?: string
    categoryName: string,
    countType: number,
    children: React.ReactNode
}

function GetCount(countType: number) {
    if (countType == 0) return <Badge bg="success">Есть в наличии</Badge>
    if (countType == 1) return <Badge bg="warning">Заканчивается</Badge>
    return <Badge bg="danger">Нет в наличии</Badge>
}

const ProductCard = (props: ProductCardProps) => {
    return (
        <Row className="gy-5">
            <Col lg={4} className="text-center">
                <img className={styles.photo} src={props.photoUrl} alt="Фото"/>
            </Col>
            <Col lg={8}>
                <div className="d-flex align-items-center">
                    <div className={styles.title}>{props.name}</div>
                    {GetCount(props.countType)}
                </div>
                <div className={styles.category}>{props.categoryName}</div>
                <Divider/>
                <div className={styles.description}>{props.description}</div>
                <Divider/>
                <div className="mb-3">Цена: {props.price} ₽</div>
                {props.children}
            </Col>
        </Row>
    );
};

export default ProductCard;