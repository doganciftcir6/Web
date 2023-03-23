"use strict";
exports.__esModule = true;
exports.ProductService = void 0;
var SimpleDataSource_1 = require("./SimpleDataSource");
// bu sunıf IproductServiceste interfacete oluşturduğumuz metotların içlerinin doldurlacak halidir
// yani interface yapısını class yapısı implement edecek
var ProductService = /** @class */ (function () {
    // konstraktır
    function ProductService() {
        var _this = this;
        this.dataSoruce = new SimpleDataSource_1.SimpleDataSource();
        this.products = new Array();
        this.dataSoruce.getProducs().forEach(function (p) { return _this.products.push(p); });
        // data kaynağındaki bütün elemanları gelip ProductService içerisindeki productsa atmış olduk
    }
    // interface içerisinde olan metotların hepsi buraya eklendi ve gövdeleride oluşacak
    ProductService.prototype.getById = function (id) {
        // bir filter aracılığıyla istediğimiz bir bilgiyi alalım yukarıdan gönderdiğimiz id ye karşılık gelen ilk elemanı alalım
        return this.products.filter(function (p) { return p.id === id; })[0];
    };
    ProductService.prototype.getProducts = function () {
        // bize bütün listeyi döndürsün
        return this.products;
    };
    ProductService.prototype.saveProduct = function (product) {
        // kayıt işlemi yapalım
        // yeni ürün ekleme
        if (product.id == 0 || product.id == null) {
            product.id = this.generateId();
            this.products.push(product);
        } // güncelleme
        else {
            var index = void 0;
            for (var i = 0; i < this.products.length; i++) {
                if (this.products[i].id === product.id) {
                    index = i;
                }
            }
            // eğer varsa bunu listenin üzerine tkerar ekleriz verlien indexten itibaren 1 elemanı sileriz yerine aldığımız producağı eklicez
            this.products.splice(index, 1, product);
        }
    };
    ProductService.prototype.deleteProduct = function (product) {
        // silme yapıcaz
        // yine aynı şekilde gönderdiğimiz prodcutın liste içerisindeki indeks numarasını alalım 
        var index = this.products.indexOf(product);
        if (index > 0) {
            // verilen indexten itibaren 1 ürünü sileriz
            this.products.splice(index, 1);
        }
    };
    // generateId metotunu oluşturalım bu metot bize rastgele eleman getirsin
    ProductService.prototype.generateId = function () {
        var key = 1;
        // eşleşme olursa key bilgisi bir artsın
        while (this.getById(key) != null) {
            key++;
        }
        // eşleşme olmazsa key bilgisi direkt artmadan gelsin
        return key;
    };
    return ProductService;
}());
exports.ProductService = ProductService;
