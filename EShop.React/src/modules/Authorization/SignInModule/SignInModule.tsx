import {useCallback, useState} from 'react';
import {useNavigate} from "react-router-dom";
import {useInjection} from 'inversify-react';
import {IAccountService} from "../../../services/AccountService/IAccountService.ts";
import {useUser} from "../../../contexts/UserContext/UserContext.tsx";
import SignInForm from "./SignInForm.tsx";
import AuthorizationLink from "../../../UI/AuthorizationLink/AuthorizationLink.tsx";

interface SignInModuleProps {
    onRegistration: () => void
    onRecoverPassword: () => void
}

const SignInModule = ({onRegistration, onRecoverPassword}: SignInModuleProps) => {

    const [error, setError] = useState<string>()
    const {setTokens} = useUser()
    const navigate = useNavigate();
    const accountService = useInjection<IAccountService>('AccountService');

    const authenticate = useCallback(async (email: string, password: string) => {

        try {
            const tokens = await accountService.token({email, password})
            setTokens(tokens)
            navigate("/")
        } catch (e) {
            setError(e)
        }
    }, [accountService, navigate, setTokens]);

    return (
        <>
            <SignInForm onSubmit={authenticate}/>
            <AuthorizationLink className="mt-2" text="Нет аккаунта?" link="Зарегистрироваться" onClick={onRegistration}/>
            <AuthorizationLink className="mt-2" text="Забыли пароль?" link="Восстановить доступ" onClick={onRecoverPassword}/>
        </>
    )
};

export default SignInModule;