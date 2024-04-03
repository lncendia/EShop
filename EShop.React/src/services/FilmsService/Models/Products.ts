export interface ProductShort {
    readonly id: string,
    readonly photoUrl: string,
    readonly name: string,
    readonly price: number,
    readonly countType: CountType
}

export enum CountType {
    Available = 0,
    Close = 1,
    OutOfStock = 2
}

export interface Product extends ProductShort {
    readonly attributes: Readonly<Record<string, string>>;
    readonly categoryId: string;
}
