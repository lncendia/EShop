import styles from './FormSubtext.module.css'

const FormSubtext = ({text, className = ''}: { text: string, className?: string }) => {
    return (
        <span className={`${className} ${styles.text}`}>
            {text}
        </span>
    );
};

export default FormSubtext;