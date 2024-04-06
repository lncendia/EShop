import BlockTitle from "../../UI/BlockTitle/BlockTitle.tsx";
import FavoriteModule from "../../modules/Profile/FavoriteModule/FavoriteModule.tsx";
import AuthorizeModule from "../../modules/Authorization/AuthorizeModule.tsx";

const FavoritePage = () => {
    return (
        <AuthorizeModule showError>
            <BlockTitle className="mt-4" title="Избранные товары"/>
            <FavoriteModule className="mt-3"/>
        </AuthorizeModule>
    );
};

export default FavoritePage;