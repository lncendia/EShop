import React, {createContext, useContext, useState, ReactNode, useCallback} from 'react';


// Создайте интерфейс для контекста
interface CompareContextType {
    products: string[]
    addProduct: (id: string) => void
    removeProduct: (id: string) => void
}

// Создайте сам контекст
const CompareContext = createContext<CompareContextType | undefined>(undefined);

// Создайте провайдер
interface CompareContextProviderProps {
    children: ReactNode;
}

export const CompareContextProvider: React.FC<CompareContextProviderProps> = ({children}) => {

    const [products, setProducts] = useState<string[]>([]);

    const addProduct = useCallback((id: string) => {
        setProducts(prev => {
            if (prev.length > 5) return prev
            return [...prev, id]
        })
    }, [])

    const removeProduct = useCallback((id: string) => {
        setProducts(prev => prev.filter(p => p != id))
    }, [])

    return (
        <CompareContext.Provider value={{products, addProduct, removeProduct}}>
            {children}
        </CompareContext.Provider>
    );
}

export const useCompare = () => {
    const context = useContext(CompareContext);
    if (context === undefined) {
        throw new Error('useUser must be used within a CompareContext');
    }
    return context;
};