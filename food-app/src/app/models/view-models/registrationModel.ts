import { Account } from "../account";

export class RegistrationModel{
    constructor(
        public account:Account,
        public confirmPassword:string,
        public password:string,
        public confirmCode:number=0
    ){}
}