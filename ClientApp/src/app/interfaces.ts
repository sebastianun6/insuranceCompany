export interface ICustomer {
    id?: number;
    fullName: string;
    identification: string;
}

export interface IPolicy{
    id?: number;
    Name: string;
    Description: string;
    TypePolicy: string;
    Coverage: number;
    BeginDate: Date;
    CoveragePeriod: number;
    PolicyCost: number;
    TypeRisk: string;
}
