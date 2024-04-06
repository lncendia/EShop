import {CompareItemData} from "./CompareItemData.ts";
import {Button, Table} from "react-bootstrap";

interface CompareTableProps {
    items: CompareItemData[],
    className?: string,
    onClick: (item: CompareItemData) => void
    onRemove: (item: CompareItemData) => void
}

const CompareTable = ({items, className = '', onClick, onRemove}: CompareTableProps) => {

    const attributes = Array.from(new Set(items.flatMap(item => Object.keys(item.attributes))))

    return (
        <Table striped responsive bordered hover className={className}>
            <thead>
            <tr>
                <th>Название</th>
                {items.map(i => <th key={`${i.id}_${i.name}`}>{i.name}</th>)}
            </tr>
            </thead>
            <tbody>
            <tr>
                <td>Фото</td>
                {items.map(i =>
                    <td key={`${i.id}_${i.photoUrl}`} className="text-center">
                        <img className="img-thumbnail rounded-2" width={120} height={120} src={i.photoUrl} alt="Фото"/>
                    </td>
                )}
            </tr>
            <tr>
                <td>Категория</td>
                {items.map(i => <td key={`${i.id}_${i.categoryName}`}>{i.categoryName}</td>)}
            </tr>
            <tr>
                <td>Описание</td>
                {items.map(i => <td key={`${i.id}_${i.description}`}>{i.description}</td>)}
            </tr>
            <tr>
                <td>Цена</td>
                {items.map(i => <td key={`${i.id}_${i.price}`}>{i.price} ₽</td>)}
            </tr>

            {attributes.map(a => {
                return (
                    <tr>
                        <td>{a}</td>
                        {items.map(i => <td key={`${i.id}_${i.attributes[a]}`}>{i.attributes[a] ?? '-'}</td>)}
                    </tr>
                )
            })}

            <tr>
                <td>Навигация</td>
                {items.map(i =>
                    <td key={`${i.id}_nav`}>
                        <Button className="w-100" variant="outline-primary" onClick={() => onClick(i)}>Перейти к
                            товару</Button>
                    </td>
                )}
            </tr>

            <tr>
                <td>Действия</td>
                {items.map(i =>
                    <td key={`${i.id}_delete`}>
                        <Button className="w-100" variant="outline-danger" onClick={() => onRemove(i)}>Удалить</Button>
                    </td>
                )}
            </tr>

            </tbody>
        </Table>
    );
};

export default CompareTable;