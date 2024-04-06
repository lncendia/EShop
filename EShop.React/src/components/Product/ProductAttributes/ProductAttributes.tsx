import {Table} from "react-bootstrap";
import ContentBlock from "../../../UI/ContentBlock/ContentBlock.tsx";

interface Attribute {
    [key: string]: string;
}

interface ProductAttributesProps {
    attributes: Attribute
    className?: string
}

const ProductAttributes = ({attributes, className}: ProductAttributesProps) => {
    return (
        <ContentBlock className={className}>
            <Table striped responsive bordered>
                <tbody>
                {Object.keys(attributes).map(a => {
                    return (
                        <tr key={a}>
                            <td>{a}</td>
                            <td>{attributes[a]}</td>
                        </tr>
                    )
                })}
                </tbody>
            </Table>
        </ContentBlock>
    );
};

export default ProductAttributes;