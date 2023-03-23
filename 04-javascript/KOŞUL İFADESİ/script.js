// kullanıcı uygulamaya giriş yapmış mı yapmamış mı
// isloggedin true değer eşitse ekrana uygulamya giriş yapıldı yazdırılır
// isloggedin true değere eşit değilse ekrana uygulamaya giriş yapılmadı yazdrılır else bloğu çalışmaya başlar
let isLoggedin = true;
if(isLoggedin){
    console.log("uygulamaya giriş yapıldı");
}
else{
    console.log("uygulamaya giriş yapılmadı");
}



// uygulamayı biraz daha geliştirelim
let username = "sadikturan";
let password = "1234"

if(username == "sadikturan"){
    if(password == "1234"){
        console.log("uygulamaya giriş yapıldı");
    } else{
        console.log("şifre yanlış")
    }
}
// eğer username sadikturana eşitse ve password 1234 e eşitse if bloğu çalışacak ekrana uygulamaya giriş yapıldı yazılacak
else{
    console.log("Kullanıcı adı yanlış");
}







// eğer 3 2 den büyükse true değer döndürülür ve ekrana merhaba yazdırılır
// eğer 3 2 den büyük değilse false değer döndürülür ve ekrana merhaba yazdırılmaz
if(3 > 2){
    console.log("merhaba")
}