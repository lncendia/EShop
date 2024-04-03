export interface AttributeOption {
    readonly name: string;
    readonly values: ValueSelectOption[];
}


export interface ValueSelectOption {
    readonly value: string;
    readonly count: number;
    readonly checked: boolean;
}