import {useState} from "react";
import RegistrationModule from "../../modules/Authorization/RegistrationModule/RegistrationModule.tsx";
import SignInModule from "../../modules/Authorization/SignInModule/SignInModule.tsx";
import {Col} from "react-bootstrap";
import ContentBlock from "../../UI/ContentBlock/ContentBlock.tsx";
import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";

// Страница входа пользователя
const SignInPage = () => {

    const [module, setModule] = useState(1)

    return (
        <Col md={6} className="m-auto mt-4">
            <ContentBlock>
                {module == 1 &&
                    <>
                        <BlockTitle className="mb-4" title="Вход"/>
                        <SignInModule onRegistration={() => setModule(2)} onRecoverPassword={() => setModule(3)}/>
                    </>
                }
                {module == 2 &&
                    <>
                        <BlockTitle className="mb-4" title="Регистрация"/>
                        <RegistrationModule onLogin={() => setModule(1)}/>
                    </>
                }
            </ContentBlock>
        </Col>
    )
};

export default SignInPage;