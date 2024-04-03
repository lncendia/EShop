import {Outlet} from "react-router-dom";
import Container from "../../UI/Container/Container.tsx";
import NavbarModule from "../../modules/Home/NavbarModule/NavbarModule.tsx";

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