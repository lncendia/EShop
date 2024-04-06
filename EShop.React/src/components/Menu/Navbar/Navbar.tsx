import {Button, Container, Nav, Navbar as NavbarBs, NavDropdown} from "react-bootstrap";
import Svg from "../../../UI/Svg/Svg.tsx";
import NavLogo from "../NavLogo/NavLogo.tsx";
import {CategoryItem} from "./CategoryItem.ts";
import ProductSearch from "../ProductSearch/ProductSearch.tsx";
import {ProductElementData} from "../ProductSearchElement/ProductElementData.ts";
import NavUser from "../NavUser/NavUser.tsx";
import styles from "./Navbar.module.css"

export interface MenuProps {
    onLogout: () => void,
    onHome: () => void,
    categories: CategoryItem[]
    onCategorySelect: (item: CategoryItem) => void
    onCatalog: () => void,
    onFavorite: () => void,
    onCart: () => void,
    onLogin: () => void,
    onCompare: () => void,
    products: ProductElementData[],
    onSearch: (value: string) => void,
    onProduct: (product: ProductElementData) => void,
    name?: string
}

const Navbar = (props: MenuProps) => {
    return (
        <>
            <NavbarBs expand="md" bg="primary" className={`border-bottom ${styles.mainbar}`}>
                <Container>
                    <NavLogo/>
                    <Nav>
                        <Nav.Item>
                            <ProductSearch products={props.products} onSearch={props.onSearch}
                                           onClick={props.onProduct}/>
                        </Nav.Item>
                    </Nav>
                    <NavbarBs.Toggle aria-controls="navbarSupportedContent" aria-expanded="false"
                                     aria-label="Переключатель навигации">
                        <span className="navbar-toggler-icon"></span>
                    </NavbarBs.Toggle>
                    <NavbarBs.Collapse id="navbarSupportedContent">
                        <Nav className="flex-grow-1"/>
                        <Nav>
                            {props.name && <NavUser {...props} name={props.name}/>}
                            {!props.name &&
                                <Button onClick={props.onLogin} variant="primary">
                                    <Svg width={16} height={16} fill="currentColor"
                                         className="bi bi-person-fill" viewBox="0 0 16 16">
                                        <path
                                            d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                                    </Svg>
                                    Войти
                                </Button>
                            }
                            <Button onClick={props.onCompare} variant="primary">
                                <Svg width={16} height={16} fill="currentColor" viewBox="0 0 16 16">
                                    <path fillRule="evenodd"
                                          d="M1 11.5a.5.5 0 0 0 .5.5h11.793l-3.147 3.146a.5.5 0 0 0 .708.708l4-4a.5.5 0 0 0 0-.708l-4-4a.5.5 0 0 0-.708.708L13.293 11H1.5a.5.5 0 0 0-.5.5m14-7a.5.5 0 0 1-.5.5H2.707l3.147 3.146a.5.5 0 1 1-.708.708l-4-4a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 4H14.5a.5.5 0 0 1 .5.5"/>
                                </Svg>
                                Сравнения
                            </Button>
                        </Nav>
                    </NavbarBs.Collapse>
                </Container>
            </NavbarBs>

            <NavbarBs expand="sm" className={`border-bottom ${styles.navbar}`}>
                <Container>
                    <Nav className="me-auto">
                        <Nav.Link>Главная</Nav.Link>
                        <Nav.Link onClick={props.onCatalog}>Каталог</Nav.Link>
                        <NavDropdown title="Категории" id="basic-nav-dropdown">
                            {props.categories.map(c =>
                                <NavDropdown.Item onClick={() => props.onCategorySelect(c)}
                                                  key={c.id}>{c.name}</NavDropdown.Item>)
                            }
                        </NavDropdown>
                    </Nav>
                </Container>
            </NavbarBs>
        </>
    );
};

export default Navbar;