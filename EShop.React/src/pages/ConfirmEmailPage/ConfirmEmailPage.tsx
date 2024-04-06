import ConfirmEmailModule from "../../modules/Authorization/ConfirmEmailModule/ConfirmEmailModule.tsx";
import {useLocation} from "react-router-dom";

// Страница входа пользователя
const ConfirmEmailPage = () => {

    const location = useLocation();
    const params = new URLSearchParams(location.search);
    const userId = params.get('userId') ?? '';
    const code = params.get('code') ?? ''

    return <ConfirmEmailModule className="mt-5" code={code} userId={userId}/>
};

export default ConfirmEmailPage;