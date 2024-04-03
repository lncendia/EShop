import {Navbar} from "react-bootstrap";
import styles from "./NavLogo.module.css"

const NavLogo = ({onClick}: { onClick?: () => void }) => {
    return (
        <Navbar.Brand className={styles.text} onClick={onClick}>
            EShop
        </Navbar.Brand>
    );
};

export default NavLogo;