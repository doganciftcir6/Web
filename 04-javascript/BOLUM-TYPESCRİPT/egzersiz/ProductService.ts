import { IProductService } from "./IProductService";
import {Product} from './Product';
import { SimpleDataSource } from "./SimpleDataSource";
// bu sunıf IproductServiceste interfacete oluşturduğumuz metotların içlerinin doldurlacak halidir
// yani interface yapısını class yapısı implement edecek

export class ProductService implements IProductService{
    // private bir üye oluşturalım DataSourceu kullanalım
    private dataSoruce: SimpleDataSource;
    // PorductService e özel bir liste oluşturalım
    private products: Array<Product>;
    // konstraktır
    constructor(){
        this.dataSoruce = new SimpleDataSource();
        this.products = new Array<Product>();
        this.dataSoruce.getProducs().forEach(p=> this.products.push(p));
        // data kaynağındaki bütün elemanları gelip ProductService içerisindeki productsa atmış olduk
    }



    // interface içerisinde olan metotların hepsi buraya eklendi ve gövdeleride oluşacak
    getById(id: number): Product {
        // bir filter aracılığıyla istediğimiz bir bilgiyi alalım yukarıdan gönderdiğimiz id ye karşılık gelen ilk elemanı alalım
        return this.products.filter(p=>p.id === id)[0]
    }
    getProducts(): Product[] {
        // bize bütün listeyi döndürsün
        return this.products;
    }
    saveProduct(product: Product): void {
        // kayıt işlemi yapalım
        // yeni ürün ekleme
        if(product.id == 0 || product.id == null){
            product.id = this.generateId();
            this.products.push(product);
        } // güncelleme
        else{
            let index;
            for(let i = 0;i<this.products.length;i++){
                if(this.products[i].id === product.id){
                    index = i;
                }
            }
            // eğer varsa bunu listenin üzerine tkerar ekleriz verlien indexten itibaren 1 elemanı sileriz yerine aldığımız producağı eklicez
            this.products.splice(index,1,product);
        }
    }
    deleteProduct(product: Product): void {
        // silme yapıcaz
        // yine aynı şekilde gönderdiğimiz prodcutın liste içerisindeki indeks numarasını alalım 
        let index = this.products.indexOf(product);
        if(index > 0){
            // verilen indexten itibaren 1 ürünü sileriz
            this.products.splice(index,1);
        }
    }

    // generateId metotunu oluşturalım bu metot bize rastgele eleman getirsin
    private generateId():number{
        let key = 1;
        // eşleşme olursa key bilgisi bir artsın
        while(this.getById(key) != null){
            key++;
        }
        // eşleşme olmazsa key bilgisi direkt artmadan gelsin
        return key;
    }
    
}
