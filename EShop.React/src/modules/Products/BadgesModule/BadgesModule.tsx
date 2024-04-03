import {BadgeOption} from "./BadgeOption.ts";
import BadgesList from "../../../components/Products/BadgesList/BadgesList.tsx";

interface BadgesModuleProps {
    badges: BadgeOption[],
    onRemove: (attribute: string, value: string) => void,
    className?: string
}

const BadgesModule = ({className = '', badges, onRemove}: BadgesModuleProps) => {
    return (
        <div className={className}>
            {badges.map(b =>
                <BadgesList className="mt-4" key={b.name} name={b.name} values={b.values} onRemove={(value) => onRemove(b.name, value)}/>
            )}
        </div>
    );
};

export default BadgesModule;