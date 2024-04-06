import styles from "./AuthorizationLink.module.css"

interface AuthorizationLinkProps {
    text: string,
    link: string,
    className?: string
    onClick: () => void
}

const AuthorizationLink = ({text, link, className = '', onClick}: AuthorizationLinkProps) => {
    return (
        <div className={className}>
            <span className={styles.text}>{text} </span>
            <a className={styles.link} href="#" onClick={(e)=>{e.preventDefault(); onClick()}}>{link}</a>
        </div>
    );
};

export default AuthorizationLink;