export interface Product {
    id: string,
    photoUrl: string,
    name: string,
    description: string,
    price: number,
    countType: CountType
    categoryId: string;
    categoryName: string;
    inFavorite: boolean,
    inShoppingCart: boolean,
    attributes: Attribute;
}

export enum CountType {
    Available = 0,
    Close = 1,
    OutOfStock = 2
}

export interface Attribute {
    [key: string]: string;
}