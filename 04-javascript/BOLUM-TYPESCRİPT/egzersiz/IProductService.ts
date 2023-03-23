import{Product} from "./Product";

// inteface oluşturalım
export interface IProductService{
    // bir metot number türünde veri alacak ve geriye product türünde döndürecek
    getById(id: number):Product;
    // bir metot bütün ürünleri bize gtirecek geriye Product türünde bir dizi döndürecek
    getProducts():Array<Product>;
    // bir metot prdoct türünde veri alacak ver geriye bir şey döndürmeyecek ürün eklemesi yapacak
    saveProduct(product: Product):void;
    // bir metot prdoct türünde veri alacak ver geriye bir şey döndürmeyecek ürün silmesi yapacak
    deleteProduct(product: Product):void;
}