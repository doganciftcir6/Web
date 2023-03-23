import { Product } from "./Product";

// bu bana tamen bir ürün listesi getirecek data kaynağım olacak
export class SimpleDataSource{
    private products: Array<Product>;
    // konstraktır
    constructor(){
        this.products = new Array<Product>(
            new Product(1,"Samsung S5", "Telefon", 1000),
            new Product(2,"Samsung S6", "Telefon", 2000),
            new Product(3,"Samsung S7", "Telefon", 3000),
            new Product(4,"Samsung S8", "Telefon", 4000),
        );
    }
    // private olarak Product sınıfından tanımladığımız listeyi konstraktır ile dolduruyoruz dışarıdan değiştirmenin önüne geçtik ve bu listeye dışarıdan ulaşmak için bir get metot tanımladık
    // bu listeye dışarıdan ulaşmak için metot geriye Products dizisi gönderecek dedik
    getProducs(): Product[]{
        return this.products;
    }
}