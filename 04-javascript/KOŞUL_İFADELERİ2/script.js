// yas >= 18 ve
// mezuniyet == "lise" ya da mezuniyer == "üniversite"

let yas = 20;
let mezuniyet = "üniversite"

if(yas >= 18 && (mezuniyet == "lise" || mezuniyet == "üniversite")){
    console.log("ehliyet alabilir")
} else{
    console.log("ehliyet şartları tutmuyor.")
}




// and  && çalışma mantığı  
// true , true => true
// true, false => false

// or  || çalışma mantığı  yani bir tane koşul tutsa yeter yine true verir
// true , true => true
// true, false => true
// false, false => false