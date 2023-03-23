// class oluşturucaz dışarıca açıcaz export
export class Product {
    // konstraktır ve içinde değişken tanımları aynı zamanda
    constructor(public id?: number, public name?:string, public category?: string, public price?: number){
        
    }
}
// nesne üretimi
let p = new Product();