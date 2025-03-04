import { Token } from "@angular/compiler"

export interface User {
    statusCode: number,
    isSuccess:boolean,
    result: Result;
}

export interface Result {
    token: string;
}