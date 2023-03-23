// BİRİNCİ
var sayi = 35;

if(sayi > 10 && sayi < 50){
    console.log("evet adamım sayı 10 ve 50 arasında");
}else{
    console.log("hayır adamım sayı 10 ve 50 arasında değil");
}

// İKİNCİ
var sayi2 = 43;
if(sayi2 % 2 == 1 && sayi2 > 0){
    console.log("evet adamım sayı tek ve pozitif");
}if(sayi2 % 2 == 0 && sayi2 < 0){
    console.log("hayır adamım sayı çift ve negatif");
}

// ÜÇÜNCÜ
var x = 4;
var y = 3;
var z = 6;

if(x > y && x > z) {
    console.log("x, y ve z den büyük")
}else if(y > x && y > z){
    console.log("y, x ve z den büyük")
}else if(z > x && z > y){
    console.log("z, x ve y den büyük")
}else{
    console.log("sayılar eşit")
}

//DÖRDÜNCÜ
var vize1 = 55;
var vize2 = 20;
var final = 70;
var ortalama = (((vize1 + vize2) / 2) * 0.4) + (final * 0.6);

if(ortalama >= 50){
    console.log("GEÇTİNİZ")
}else{
    console.log("KALDINIZ")
}

if(ortalama >= 50 && final >= 50){
    console.log("GEÇTİNİZ")
}else{
    console.log("KALDINIZ")
}

if(ortalama >= 50 || final >= 70){
    console.log("GEÇTİNİZ")
}else{
    console.log("KALDINIZ")
}