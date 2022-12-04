export class Food{
  
   constructor(
               public name:string,
               public composition?:string,
               public photoName?:string,
               public photoBase64?:string,
               public categoryId?:number,
               public subcategoryId?:number,
               public id:number=0,
               public price:number=0
              ){}
}