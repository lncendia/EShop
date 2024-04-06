export interface UserProduct {
    id: string,
    photoUrl: string,
    name: string,
    description: string,
    price: number,
    countType: number
    categoryName: string;
}

export interface UserProductCount extends UserProduct {
    count: number
}