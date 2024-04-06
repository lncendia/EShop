import OrderForm from "./OrderForm.tsx";
import ContentBlock from "../../../UI/ContentBlock/ContentBlock.tsx";
import {useUser} from "../../../contexts/UserContext/UserContext.tsx";

const OrderModule = () => {

    const {authorizedUser} = useUser()

    return (
        <ContentBlock>
            <OrderForm name={authorizedUser!.name} email={authorizedUser!.email}/>
        </ContentBlock>
    );
};

export default OrderModule;