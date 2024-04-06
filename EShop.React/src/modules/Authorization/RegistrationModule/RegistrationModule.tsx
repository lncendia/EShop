import {useCallback, useState} from 'react';
import {useNavigate} from "react-router-dom";
import {useInjection} from 'inversify-react';
import RegistrationForm from "./RegistrationForm.tsx";
import {useUser} from "../../../contexts/UserContext/UserContext.tsx";
import {IRegistrationService} from "../../../services/RegistrationService/IRegistrationService.ts";
import AuthorizationLink from "../../../UI/AuthorizationLink/AuthorizationLink.tsx";

interface RegistrationModuleProps {
    onLogin: () => void
}

const RegistrationModule = ({onLogin}: RegistrationModuleProps) => {

    const [error, setError] = useState<string>()
    const {setTokens} = useUser()
    const navigate = useNavigate();
    const registrationService = useInjection<IRegistrationService>('RegistrationService');

    const register = useCallback(async (username: string, email: string, password: string) => {

        try {
            const tokens = await registrationService.registration({email, password, username, confirmUrl: "https://localhost:5173/confirmEmail"})
            setTokens(tokens)
            navigate("/")
        } catch (e) {
            setError(e)
        }
    }, [registrationService, navigate, setTokens]);

    return (
        <div>
            <RegistrationForm onSubmit={register}/>
            {error && <span>error</span>}
            <AuthorizationLink className="mt-2" text="Есть аккаунт?" link="Войти" onClick={onLogin}/>
        </div>
    )
};

export default RegistrationModule;