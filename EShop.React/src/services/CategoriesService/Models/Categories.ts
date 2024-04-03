export interface CategoryShort {
    readonly id: string,
    readonly name: string,
}

export interface Category extends CategoryShort {
    readonly attributes: Attribute[];
}

export interface Attribute {
    readonly name: string;
    readonly values: ReadonlyArray<AttributeValue>;
}

export interface AttributeValue {
    readonly value: string;
    readonly count: number;
}