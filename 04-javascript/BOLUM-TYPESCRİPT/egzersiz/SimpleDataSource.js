"use strict";
exports.__esModule = true;
exports.SimpleDataSource = void 0;
var Product_1 = require("./Product");
// bu bana tamen bir ürün listesi getirecek data kaynağım olacak
var SimpleDataSource = /** @class */ (function () {
    // konstraktır
    function SimpleDataSource() {
        this.products = new Array(new Product_1.Product(1, "Samsung S5", "Telefon", 1000), new Product_1.Product(2, "Samsung S6", "Telefon", 2000), new Product_1.Product(3, "Samsung S7", "Telefon", 3000), new Product_1.Product(4, "Samsung S8", "Telefon", 4000));
    }
    // private olarak Product sınıfından tanımladığımız listeyi konstraktır ile dolduruyoruz dışarıdan değiştirmenin önüne geçtik ve bu listeye dışarıdan ulaşmak için bir get metot tanımladık
    // bu listeye dışarıdan ulaşmak için metot geriye Products dizisi gönderecek dedik
    SimpleDataSource.prototype.getProducs = function () {
        return this.products;
    };
    return SimpleDataSource;
}());
exports.SimpleDataSource = SimpleDataSource;
