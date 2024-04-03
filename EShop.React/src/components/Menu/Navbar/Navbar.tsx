import Container from "../../../UI/Container/Container.tsx";
import {Button, Form, Nav, Navbar as NavbarBs, NavDropdown} from "react-bootstrap";
import Svg from "../../../UI/Svg/Svg.tsx";
import NavLogo from "../NavLogo/NavLogo.tsx";
import {CategoryItem} from "./CategoryItem.ts";

export interface MenuProps {
    onLogout: () => void,
    onHome: () => void,
    categories: CategoryItem[]
    onCategorySelect: (item: CategoryItem) => void
}

const Navbar = (props: MenuProps) => {
    return (
        <>
            <NavbarBs bg="primary" className="border-bottom">
                <Container>
                    <NavLogo/>
                    <Nav>
                        <Form.Control type="text" placeholder="Поиск"/>
                    </Nav>
                    <Nav className="flex-grow-1"/>
                    <Nav>
                        {/*<Nav.Item>*/}
                        {/*    <FilmSearch films={props.films} onFilmSearch={props.onFilmSearch} onClick={props.onFilm}/>*/}
                        {/*</Nav.Item>*/}
                        <Button variant="primary">
                            <Svg width={16} height={16} fill="currentColor"
                                 className="bi bi-person-fill" viewBox="0 0 16 16">
                                <path
                                    d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                            </Svg>
                            Войти
                        </Button>
                        <Button variant="primary">
                            <Svg width={16} height={16} fill="currentColor" viewBox="0 0 16 16">
                                <path
                                    d="M4 1c2.21 0 4 1.755 4 3.92C8 2.755 9.79 1 12 1s4 1.755 4 3.92c0 3.263-3.234 4.414-7.608 9.608a.513.513 0 0 1-.784 0C3.234 9.334 0 8.183 0 4.92 0 2.755 1.79 1 4 1"/>
                            </Svg>
                            Избранное
                        </Button>
                        <Button variant="primary">
                            <Svg width={16} height={16} fill="currentColor" viewBox="0 0 16 16">
                                <path
                                    d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5M5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4m7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4m-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2m7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2"/>
                            </Svg>
                            Корзина
                        </Button>
                    </Nav>
                </Container>
            </NavbarBs>

            <NavbarBs expand="sm" className="border-bottom">
                <Container>
                    <NavbarBs.Toggle className="border py-2">
                        <i className="fas fa-bars"></i>
                    </NavbarBs.Toggle>

                    <NavbarBs.Collapse>
                        <Nav className="me-auto">
                            <Nav.Link>Главная</Nav.Link>
                            <Nav.Link>Каталог</Nav.Link>
                            <NavDropdown title="Категории" id="basic-nav-dropdown">
                                {props.categories.map(c =>
                                    <NavDropdown.Item onClick={() => props.onCategorySelect(c)}
                                                      key={c.id}>{c.name}</NavDropdown.Item>)
                                }
                            </NavDropdown>
                        </Nav>
                    </NavbarBs.Collapse>
                </Container>
            </NavbarBs>
        </>
    );
};

export default Navbar;