import {useEffect, useState} from 'react';
import {useNavigate} from "react-router-dom";
import {useInjection} from 'inversify-react';
import {IRegistrationService} from "../../../services/RegistrationService/IRegistrationService.ts";
import TextBlock from "../../../UI/TextBlock/TextBlock.tsx";
import {AxiosError} from "axios";

const ConfirmEmailModule = ({className, code, userId}: { className?: string, code: string, userId: string }) => {

    const [error, setError] = useState<string>()
    const navigate = useNavigate();
    const registrationService = useInjection<IRegistrationService>('RegistrationService');

    useEffect(() => {

        const confirm = async () => {

            try {
                await registrationService.confirmEmail({code: code, userId: userId})
                navigate("/")
            } catch (e) {

                if (e instanceof AxiosError) {
                    setError("fddffddfdf")
                }
            }
        }

        confirm().then()
    }, [registrationService, navigate]);

    return <TextBlock className={className} text={error ?? 'Перенаправление...'}/>
};

export default ConfirmEmailModule;