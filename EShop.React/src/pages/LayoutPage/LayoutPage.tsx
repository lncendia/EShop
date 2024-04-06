import {Outlet} from "react-router-dom";
import NavbarModule from "../../modules/Home/NavbarModule/NavbarModule.tsx";
import {Container} from "react-bootstrap";

// Общая страница с шаблоном для всех остальных страниц
const LayoutPage = () => {

    return (
        <>
            <NavbarModule/>
            <Container>
                <Outlet/>
            </Container>
            {/*<Footer/>*/}
        </>
    )
}

export default LayoutPage;