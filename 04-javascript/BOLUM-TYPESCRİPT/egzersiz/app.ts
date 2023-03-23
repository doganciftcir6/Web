import { Product } from './Product';
import{ProductService} from './ProductService';


let _productService = new ProductService();
let result;
// bütün liste karşımıza gelir
result = _productService.getProducts();
// tek bir ürün sadece 2 numaralı ürün gelir
result = _productService.getById(2);
// yeni bir ürün oluşturalım
let p = new Product();
p.id = 2;
p.name = "Iphone 6";
p.price = 4000;
p.category = "Telefon";
// bunu listeye ekleyelim
_productService.saveProduct(p);
// tekrar tüm listeye bakalım burada tanımlama yaparken id belirtmedik otomatikmen kendisi id ataması yaptı önemli nokta eğer olan bir id numarası eklersek 2 gibi güncelleme işlemi yapıalcaktır
result = _productService.getProducts();
// // ürün silelim
// _productService.deleteProduct(p);
// // tekrar tüm listeye bakalım 
// result = _productService.getProducts();


console.log(result);
