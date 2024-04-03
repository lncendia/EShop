import Navbar from "../../../components/Menu/Navbar/Navbar.tsx";
import {ICategoriesService} from "../../../services/CategoriesService/ICategoriesService.ts";
import {useInjection} from "inversify-react";
import {useCallback, useEffect, useState} from "react";
import {CategoryItem} from "../../../components/Menu/Navbar/CategoryItem.ts";
import {useNavigate} from "react-router-dom";

const NavbarModule = () => {

    // const [films, setFilms] = useState<FilmShort[]>([]);
    // const filmService = useInjection<IProductsService>('FilmsService');
    // const authService = useInjection<IAuthService>('AuthService');
    // const {authorizedUser} = useUser()
    //
    //
    // const onFilmSearch = useCallback(async (value: string) => {
    //     if (value === '') setFilms([])
    //     else {
    //         const filmsResponse = await filmService.search({query: value})
    //         setFilms(filmsResponse.films)
    //     }
    // }, [filmService])
    //
    //
    // const onLogout = useCallback(authService.signOut.bind(authService), [authService])
    // const onLogin = useCallback(authService.signIn.bind(authService), [authService])
    // const onCatalog = useCallback(() => navigate('/catalog'), [navigate])
    // const onPlaylists = useCallback(() => navigate('/playlists'), [navigate])
    // const onRooms = useCallback(() => navigate('/filmRooms'), [navigate])
    // const onYouTube = useCallback(() => navigate('/youtube'), [navigate])
    // const onProfile = useCallback(() => navigate('/profile'), [navigate])
    // const onHome = useCallback(() => navigate('/'), [navigate])
    //
    // const onFilm = useCallback((film: FilmShort) => {
    //     navigate('/film', {state: {id: film.id}})
    // }, [navigate])

    const [categories, setCategories] = useState<CategoryItem[]>([]);
    const categoryService = useInjection<ICategoriesService>('CategoriesService');

    useEffect(() => {
        categoryService.getAll().then(c => setCategories(c))
    }, []);

    // Навигационный хук
    const navigate = useNavigate();

    const onCategorySelect = useCallback((item: CategoryItem) => {
        navigate('/catalog', {state: {id: item.id}})
    }, [navigate])

    return (
        <Navbar categories={categories} onCategorySelect={onCategorySelect}/>
    );
};

export default NavbarModule;