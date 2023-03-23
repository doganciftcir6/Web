"use strict";
exports.__esModule = true;
var Product_1 = require("./Product");
var ProductService_1 = require("./ProductService");
var _productService = new ProductService_1.ProductService();
var result;
// bütün liste karşımıza gelir
result = _productService.getProducts();
// tek bir ürün sadece 2 numaralı ürün gelir
result = _productService.getById(2);
// yeni bir ürün oluşturalım
var p = new Product_1.Product();
p.id = 2;
p.name = "Iphone 6";
p.price = 4000;
p.category = "Telefon";
// bunu listeye ekleyelim
_productService.saveProduct(p);
// tekrar tüm listeye bakalım burada tanımlama yaparken id belirtmedik otomatikmen kendisi id ataması yaptı önemli nokta
result = _productService.getProducts();
// // ürün silelim
// _productService.deleteProduct(p);
// // tekrar tüm listeye bakalım 
// result = _productService.getProducts();
console.log(result);
