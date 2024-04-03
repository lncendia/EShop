import Svg from "../../../UI/Svg/Svg.tsx";
import styles from "./BadgesList.module.css"

interface BadgeListProps {
    name: string
    values: string[]
    onRemove: (value: string) => void,
    className?: string
}

const BadgesList = ({className = '', name, values, onRemove}: BadgeListProps) => {
    return (
        <div className={`${className} d-flex align-items-center`}>
            <span>{name}:</span>
            {values.map(v => {
                return (
                    <span className={styles.badge}>
                        <Svg className={styles.svg} onClick={() => onRemove(v)} width={16} height={16}
                             fill="currentColor" viewBox="0 0 16 16">
                            <path
                                d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
                        </Svg>
                        {v}
                    </span>
                )
            })}
        </div>
    );
};

export default BadgesList;