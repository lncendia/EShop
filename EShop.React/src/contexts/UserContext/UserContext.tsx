import React, {createContext, useContext, useState, useEffect, ReactNode, useCallback} from 'react';
import {jwtDecode} from "jwt-decode";
import {useInjection} from "inversify-react";
import {IAuthorizedUser} from "./AuthorizedUser.ts";
import {IAccountService} from "../../services/AccountService/IAccountService.ts";
import {Tokens} from "../../services/Common/Models/Tokens.ts";
import {AxiosInstance} from "axios";


// Создайте интерфейс для контекста
interface UserContextType {
    authorizedUser?: IAuthorizedUser;
    setTokens: (tokens?: Tokens) => void
}

// Создайте сам контекст
const UserContext = createContext<UserContextType | undefined>(undefined);

// Создайте провайдер
interface UserContextProviderProps {
    children: ReactNode;
}

export const UserContextProvider: React.FC<UserContextProviderProps> = ({children}) => {

    const [tokens, setTokens] = useState<Tokens | undefined>(() => {
        const storedTokens = localStorage.getItem("tokens");
        return storedTokens ? JSON.parse(storedTokens) : undefined;
    });

    const [authorizedUser, setAuthorizedUser] = useState<IAuthorizedUser>();

    const accountService = useInjection<IAccountService>('AccountService');

    const axiosInstance = useInjection<AxiosInstance>('AxiosInstance');

    axiosInstance.interceptors.request.use(async config => {
        if (tokens) config.headers.Authorization = `Bearer ${tokens.accessToken}`;
        else config.headers.Authorization = undefined
        return config;
    });


    const clear = useCallback(() => {
        setAuthorizedUser(undefined);
        setTokens(undefined);
        localStorage.removeItem("tokens");
    }, []);

    const refreshToken = useCallback(async () => {
        if (!tokens) return;
        console.log("обновляю")
        const refreshTokenExpiration = new Date(tokens.refreshTokenExpiration).getTime()
        if (refreshTokenExpiration < Date.now()) {
            clear();
            return;
        }
        try {
            const newTokens = await accountService.refreshToken(tokens.refreshToken)
            console.log(newTokens)
            setTokens(newTokens);
        } catch {
            clear()
        }
    }, [accountService, tokens, clear]);

    useEffect(() => {
        if (!tokens) clear();
        else {
            localStorage.setItem("tokens", JSON.stringify(tokens));
            const parsed = jwtDecode(tokens.accessToken) as any;
            setAuthorizedUser(mapUser(parsed));
            const difference = new Date((parsed.exp - 60) * 1000).getTime() - Date.now();

            if (difference < 0) refreshToken().then();
            else {
                const timeoutId = setTimeout(refreshToken, difference);
                return () => clearTimeout(timeoutId);
            }
        }
    }, [tokens, clear, refreshToken]);


    return (
        <UserContext.Provider value={{authorizedUser, setTokens}}>
            {children}
        </UserContext.Provider>
    );
}

// Хук для использования контекста
export const useUser = () => {
    const context = useContext(UserContext);
    if (context === undefined) {
        throw new Error('useUser must be used within a UserContextProvider');
    }
    return context;
};

function mapUser(profile: any): IAuthorizedUser {

    console.log(profile)
    return {
        email: profile.email,
        id: profile.sub,
        name: profile.name,
    }
}
