export interface CompareItemData {
    readonly id: string,
    readonly photoUrl: string,
    readonly name: string,
    readonly price: number,
    readonly categoryName: string;
    readonly description: string
    readonly attributes: Attribute;
}

interface Attribute {
    [key: string]: string;
}