// bir fonksiyon oluşturalım bu fonksiyon hesaplama yapsın
// fonksiyon sonuna : diyerek geri dönecek olan değerin tipini yazabiliyoruz geriye string bir değer dönsün dedik eğer return yoksa geri dönüş tipi yerine void yazabiliriz yani geri dönüşü olmayan fonksiyon
// fonksiyon parametre isimlerinin yanına ? koyarak birden fazla değer alabileceğini söylüyoruz opsiyonel bir hale geliyor
// ...a: number[] gibi bir parametre tanımlaması yaparsak istenilen kadar değer alan bir parametre yapmış oluruz 
function getAverage(a:number, b:number, c?: number):string{
    let total = a+b;
    let count = 2;
    if(typeof c !== 'undefined'){
        total += c;
        count++;
    }
    // ortalamayı tutan bir değişken
    const result = total/count;
    // geriye döndürsün
    return 'result: ' + result;
}

// fonksiyonu çağıralım
getAverage(10,20,30);
// ? eklediğimiz için 2 parametre bile verebiliyoruz c parametresini vermek zorunda değiliz veya fazla parametre de verebiliirz c ye 
getAverage(10,20);