export interface ICustomer {
    id?: number;
    fullName: string;
    identification: string;
}

export interface IPolicy{
    id?: number;
    name: string;
    description: string;
    typePolicy: string;
    coverage: number;
    beginDate: Date;
    coveragePeriod: number;
    policyCost: number;
    typeRisk: string;
}
