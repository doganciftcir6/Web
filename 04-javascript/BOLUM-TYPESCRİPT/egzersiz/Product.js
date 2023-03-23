"use strict";
exports.__esModule = true;
exports.Product = void 0;
// class oluşturucaz dışarıca açıcaz export
var Product = /** @class */ (function () {
    // konstraktır ve içinde değişken tanımları aynı zamanda
    function Product(id, name, category, price) {
        this.id = id;
        this.name = name;
        this.category = category;
        this.price = price;
    }
    return Product;
}());
exports.Product = Product;
// nesne üretimi
var p = new Product();
