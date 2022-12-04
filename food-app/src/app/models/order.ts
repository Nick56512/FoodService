export class Order{
    constructor(public name:string='',
                public lastname:string='',
                public email:string='',
                public numberPhone:string='',
                public address:string='',
                public comment:string='',
                public id:number=0,
                public totalPrice:number=0,){

    }
}