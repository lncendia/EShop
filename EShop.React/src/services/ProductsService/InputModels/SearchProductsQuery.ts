export interface SearchProductsQuery {
    categoryId?: string;
    attributes?: AttributeQuery[],
    query?: string;
    minPrice?: number;
    maxPrice?: number;
    order?: ProductOrder;
    page?: number;
    countPerPage?: number;
}

interface AttributeQuery {
    name: string;
    values: string[];
}

export enum ProductOrder {
    Alphabet,
    AlphabetDesc,
    Price,
    PriceDesc
}