import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";
import AuthorizeModule from "../../modules/Authorization/AuthorizeModule.tsx";
import ShoppingCartModule from "../../modules/Profile/ShoppingCartModule/ShoppingCartModule.tsx";
import OrderModule from "../../modules/Order/OrderModule/OrderModule.tsx";

const ShoppingCartPage = () => {
    return (
        <AuthorizeModule showError>
            <BlockTitle className="mt-4" title="Оформление заказа"/>
            <OrderModule/>
            <BlockTitle className="mt-4" title="Корзина"/>
            <ShoppingCartModule className="mt-3"/>
        </AuthorizeModule>
    );
};

export default ShoppingCartPage;