import CompareModule from "../../modules/Profile/CompareModule/CompareModule.tsx";
import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";

const ComparePage = () => {
    return (
        <>
            <BlockTitle className="mt-4" title="Таблица сравнения"/>
            <CompareModule className="mt-3"/>
        </>
    );
};

export default ComparePage;