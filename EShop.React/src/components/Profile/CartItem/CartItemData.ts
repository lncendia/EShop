export interface CartItemData {
    readonly id: string,
    readonly photoUrl: string,
    readonly name: string,
    readonly description: string
    readonly price: number,
    readonly categoryName: string;
    readonly countType: number
    readonly count: number
}