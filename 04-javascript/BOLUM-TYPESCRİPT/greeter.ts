// typescript ile yazdığımız kodlar .js dosyasına çevirilirken es5 standartında çevrilir mesela burada let ile bir tanımlama yaptık .js dosyasında bu var olarak geldi çünkü let es6 da gedli es5te var vardı yani her taraycının anlacağı bir dile dönüştürüyor compailer yaparken.

// bir metot hazırlayalım
function greeter(name){
    console.log('hello ' + name);
}

// kullanalım
let user = 'Sadık';
greeter(user);