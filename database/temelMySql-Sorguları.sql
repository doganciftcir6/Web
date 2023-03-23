-- Select * from shopapp.products
-- Select ile seçme işlemi yapıyoruz bir nevi ve * dediğimizde tüm kolonlar diyoruz
-- From ile den dan nereden bu bilginin geleceğini söylüyoruz hangi tablodan
-- Sadece belli kolonları görüntülemek istiyorsak * eklemeyiz
-- select Name from shopapp.products
-- ikinci bir kolon eklemek istersek
-- select Name, Price from shopapp.products
-- gelen kolonlara bir isim vermek istersek as bu durumda gelen kolon isimi ProductName oldu
-- select Name as ProductName, Price as Fiyat from shopapp.products
-- where ile belli kritere göre kayıt filtreleme yapabiliirz
-- Id değeri 1 olan kaydı getir dedik
-- select * from shopapp.products where Id = 1
-- veya fiyatı 2000 olan kayıt gelir
-- select * from shopapp.products where Price = 2000
-- ya da fiyatı 2000 den büyük olan kayıtları getirebiliriz = diyerek 2000 i de buna dahil edebiliriz
-- select Name,Price from shopapp.products where Price >= 2000
-- peki belirli bir aralık seçmek istersek and ile 2 koşulu birbirine bağlayabiliriz and operatoru 2 koşuluda doğru olmak zorunda
-- select Name,Price from shopapp.products where Price >= 2000 And Price <= 4000
-- and yerine or operatorunu kullanırsak 2000 den büyük olan kayıtlar doğru olur ayrıca 4000 den küçük olan kayıtlarda doğru olur koşulların sadece bir tanesnini true olması yeterli
 -- select Name,Price from shopapp.products where Price >= 2000 or Price <= 4000
 -- select Name,Price from shopapp.products where Id = 1 or Id = 2
 -- string ifade de '' kullanıyoruz
 -- select *from shopapp.products where Name = 'Samsung S5'
 -- burada = kullanmak yerine != yani değil operatorunu kullanabiliriz Namemsi 'Samsung S5' e eşit olmayan kayıtları getir
 -- select *from shopapp.products where Name != 'Samsung S5'
 -- != operatorune alternatif olarak not operatorunu de kullanabiliriz
 -- select *from shopapp.products where not Name = 'Samsung S5'
 -- 2 tane Samsung S5 kayıdı var fiyatı sadece 2000 olanı getirebiliirz
-- select *from shopapp.products where Name = 'Samsung S5' and Price = 2000
-- fiyatı 2000 ile 3000 arasında olan kaydı getir desem sol taraf mutlaka Samsung S5 olacak ama sağ taraf 2000 veya 3000 olabilir diyebiliirz
-- select *from shopapp.products where not Name = 'Samsung S5' and (Price = 2000 or Price = 3000)
-- WHERE İÇİN KULLANDIĞIMIZ OPERATÖRLER DERS3: WHERE-FİLTRELEME OPERATÖRLERİ
-- Between operatorü arasında demek fiyatı 2000 ve 4000 arasında olan kayıtlar gelir
-- select *from shopapp.products where Price between 2000 and 4000 
-- yada ıd si 1 olanla 4 olan arasındaki kayıtları getir
-- select *from shopapp.products where Id between 1 and 4 
-- bu değerlerin not operatorüyle tam tersini de alabiliriz ıd si 1 2 arasında olmayanları getir
-- select *from shopapp.products where Id not between 1 and 2 
-- In operatorü ile Telefon ve Bilgisayar kategorisi içerisinde olan kayıtlar getirilir mantığı bu
-- select * from shopapp.products where Category IN ('Telefon', 'Bilgisayar')
-- not operatoru ile de bir kullanım var not in diyerek kateogrisi telefon ve bilgisayar içinde olamayanlar
-- select * from shopapp.products where Category not IN ('Telefon', 'Bilgisayar')
-- veya ıd si 1 ve 2 olmayan kayıtları getir diyebiliyoruz
-- select * from shopapp.products where Id not IN (1,2)
-- LİKE operatoru mesela içerisinde sadece Samsung geçen kayıtları görmek istiyorum ille Samsung S5 yazmak zorunda bırakmıyor yani
-- arama yapıyoruz yani Like operatoru ile içinde Samsung kelimesi geçen kayıtları getir
-- %Samsung% dersem Samsung ifadesinin başında ya da sonunda ne olduğu önemli olmaz
-- select * from shopapp.products where Name LIKE '%Samsung%'
-- %a dersem bu durumda ifadenin başında ne olduğu önemli değil ancak sonunda mutlaka a karakteriyle bitecek diyoruz
-- select * from shopapp.products where Name LIKE '%a'
-- a% şeklinde bir kullanım yaparsak bu durumda a karakteriyle başlayan ancak sonrasında ne olduğu önemli olmayan bir arama yaparız
-- select * from shopapp.products where Name LIKE 'a%'
-- _a% kullanımında ise birinci karakterin yani başında ne olduğu önemli değil ancak ikinci karakterin mutlaka a ile başlamasını söyleriz 
-- select * from shopapp.products where Name LIKE '_a%'
-- S_m% ile S ile başlasın ikinci karakterin ne olduğu önemli değil üçünkü karakter mutlaka m olsun diyebiliriz gerisi önemli değil % ile
-- select * from shopapp.products where Name LIKE 'S_m%'
-- NOT LIKE dersek bu durumda tam tersini almış oluruz içeriisnde IPhone geçmeyen kayıtlar gelir
-- select * from shopapp.products where Name NOT LIKE '%IPhone%'
-- bu şekilde dersek içerisinde IPhone geçen ve fiyatı 2000 ve büyük olan kayıtları getiririz
-- select * from shopapp.products where Name LIKE '%IPhone%' and Price >= 2000
-- isminde Samsung geçen ve description kısmında çift sim kart geçen kayıtları getirdik
-- select * from shopapp.products where Name LIKE '%Samsung%' and Description LIKE '%çift sim kart%'
-- YENİ DERS ORDER İLE KAYIT SIRALAMA
-- ben bana gelen kayıtları belli bir kritere göre sıralayabilrim
-- bu durumda fiyatı küçükten büyüğe doğru sıralar
-- select *from shopapp.products order by Price
-- string ifade olursa alfabetik olarak a dan z ye şekilde sıralanır
-- select *from shopapp.products order by Name
-- son tarafa desc eklersek tam tersi z den a ya büyükten küçüğe sıralama olur
-- select *from shopapp.products order by Name desc
-- bu şekilde fiyatı yüksekten aşağıya sıralanır desc ile
-- select *from shopapp.products order by Price desc
-- kategorisi a dan z ye şekilde sıralanır
-- select *from shopapp.products order by Category 
-- aynı anda birden fazla kolon bilgisi verebiliriz category bilgisi a dan z ye ve fiyat bilgisi küçükten büyüğe şekilde
-- select *from shopapp.products order by Category,Price
-- aynı anda verdiğimiz kolonlara farklı asc desc işlemi uygulayabiliriz
-- select *from shopapp.products order by Category desc ,Price asc
-- YENİ DERS SQL FONKSİYONLARI HESAPLAMA
-- min(price) bana minimum fiyat bilgisini getirecektir 
-- select min(price) as 'minimum fiyat' from shopapp.products
-- max(price) bana maksimum fiyat bilgisini getirecektir 
-- select max(price) from shopapp.products
 -- peki ben fiyatı minimum olan ürünün ismi ile ilgineiyorsam limit 1 dersem bana en baştaki kayıt gelir
 -- select name from shopapp.products order by price limit 1
 -- count() ile kayıt sayısını alabiliriz * ile bütün kolon bilgilerini gönderiyoruz o kolonların satırlarını sayıyor
-- select count(*) from shopapp.products
-- * yerine herhangi bir kolon ismini gönderebiliyoruz o kolonun satırlarını sayar
-- select count(price) as adet from shopapp.products
-- avg() metotu ise ortalama fonksiyonu ben buraya price gönderirsem bütün ürünlerin fiyatını alıp ortalamasını gösterecek
-- select avg(price) as ortalama from shopapp.products
-- sum() metotu ise toplam alır buraya price gönderirsem tüm fiyatların toplamını verir 
-- select sum(price) as toplam from shopapp.products
-- burada her bir üründen 1 adet fiyat bilgisi geliyordu bu bilgiyi bizim stok miktarı ile çarpıyor olmamız gerekiyor doğru bilgi için
-- select sum(price * stock) as toplam from shopapp.products
-- YENİ DERS SQL FONKSYİONLARI STRİNG
-- length() içine girilen string ifadenin karakter sayısını söyler
-- select length('Sadık Turan') as karaktersayisi 
-- bu durumda name alanının karakter uzunluğunu yazdırır
-- select name,length(name) as karakteruzunluğu from shopapp.products
-- left() ile name bilgilerinin soldan ilk 3 karakterlernin getirilmesini sağladık sadece ve sonuna da ... ekledik string ifadelerde birleştirme
-- yaparken concat ismindeki metotu kullanırız sonuna ... eklemek için
-- select name, concat(left(name,3), +'...')  from shopapp.products
-- right () ile name bilgilerinin sağdan son 2 karakterlerinin gertirilmesini sağlarız
-- select right(name,2) from shopapp.products
-- lower() metotu içine girilen bilginin küçük harfle yazılmasını sağlar name bilgileri küçük harfle gelir
-- select lower(nane) from shopapp.products
-- upper() metotu içine girilen bilginin büyük harfle yazılmasını sağlar name bilgileri büyük harfle gelir
-- select upper(nane) from shopapp.products
-- ya da ben istemediğim karakteri silmek istiyorsa replace() metotu kullanılabilir burda name içerisinde geçen boşluk karakterlerini
-- - ile değiştirmiş oluruz
-- select replace(name, ' ', '-') from shopapp.products
-- trim() fonksyonu ile baştaki ve sondaki boşlukları siler 
-- select trim('    Sadık Turan    ') from shopapp.products
-- kendi tablomuzda kullanalım name içerisindeki bilgilerde sonda ve başta boşluk varsa siler
-- select trim(name) from shopapp.products
-- bunun alternatifi olarak ltrim() soldan boşlukları siler rtrim ise sağdan boşlukları siler
-- select ltrim(name) from shopapp.products
-- select rtrim(name) from shopapp.products
-- YENİ DERS GROUPBY İLE GRUPLAMA
-- ben Category kolonunda tekrarlayan alanları sadece 1 kere almak istiyorsam distinct kullanırım yani burda categoryleri gruplamış olduk
-- ancak bu gruplama ayrı bir liste içerisinde olmuyor bu yüzden toplama ortalama gibi işlemleri yapamayız
-- select distinct Category from shopapp.products
-- bu gibi işlemlerde ise GroupBy kulllanmamız gerekiyor çünkü grupladığımız kolonun altında farklı farklı listeler oluşturur
-- bu durumda category içindeki elemanlarda telefon diyelim 5 kere tekrarlanıyor count ile bunun 5 kere tekrarlandığı bilgisini alabiliyoruz
-- select category, Count(*) as adet from shopapp.products group by category
-- sum() ile categoryi aynı olan kayıtların fiyat bilgilerini toplar ve verir
-- select category, Sum(price) as toplam from shopapp.products group by category
-- bu durumda ise category içerisinde aynı olan kayıtları birleştirip fiyat bilgilerinin ortalamasını verir
-- select category, Avg(price) as ortalama from shopapp.products group by category
-- fiyatı 2000 den büyük olan ürünleri işin içine kat grupla ve ortalamarını al da diyebiliyoruz
-- select category, Avg(price) as ortalama from shopapp.products where price > 2000 group by category
-- peki biz bunu her bir elemana değilde grup seviyesinde yapmak istersek
-- bu durumda gruplamış olduğum listede category sayısı yani tekrar eden bilgi sayısı 1 den fazla olanları işin içine kat diyebiliyoruz
-- Bilgisayarda 1 tane kayıt olduğu için o işin içine dahil edilmeyecektir
-- bu şekilde grubu ilgilendiren bir olay varsa having keywordını kullanıyoruz
-- select category, Count(*) as adet from shopapp.products group by category having Count(*) > 1
-- YENİ DERS INSERT KAYIT EKLEME
-- önce hangi kolonlara ekleme yapmak istediğimizi söyleriz sonra VALUES ekleyip sırasıyla bu alanlara göre ekleceğimiz bilgileri yazarız
-- INSERT INTO shopapp.products (Name,Price,ImageUrl,Category,Description,Stock) VALUES ('Samsung S10',7000,'1.JPG','Telefon','Çok iyi telefon',10);
-- zorunlu olmayan yani nutnull olmayan alanlar için bilgi göndermeden ekleme yapalım
-- INSERT INTO shopapp.products (Name,Price,Category) VALUES ('Samsung S11',8000,'Telefon');
-- count içersine gönderdiğimiz kolon içersisinde null bir bilgi varsa count metotu bu null bilgiyi işin için katmaz
-- select count(ImgUrl) as adet from shopapp.products
-- YENİ DERS KAYIT GÜNCELLEME UPDATE
-- önce hangi tabloda güncelleme yapacağımızı söylüyoruz sonra SET ile güncelleme yapmak istediğiöiz kolonları söylüyoruz
-- daha sonra WHERE ile filrteleme yapmazsak tüm kayıtların name alanlarını Samsung S7 ile günceller 
-- where ekleyerek ıd si 1 numaralı olan elemanı güncelleriz sadece
-- UPDATE shopapp.products SET Name = 'Samsung S7' WHERE Id = 1
-- bütün ürünlerin fiyat alanına 1000 tl ekliyor olalım
-- Where olmadan soruguyu çalıştırırsak önlem amaçlı tüm veriler değişmesin diye çalışmaz bunu ekliyor olmamız lazım biliçli yapıldığını söylemek için
-- SET SQL_SAFE_UPDATES = 0;
-- SET SQL_SAFE_UPDATES = 0; UPDATE shopapp.products SET Price = Price + 1000
-- resim kısmı boş olanlara resim eklemek istiyorsam IS NULL ile ImageUrl alanı null değere eşit olanlar demiş oluyoruz
-- NULL olmayanları aramak istiyorsakta IS NOT NULL kullanırız
-- UPDATE shopapp.products SET ImageUrl = 'noproduct.jpg' where ImageUrl IS NULL
-- YENİ DERS DELEYE KAYIT SİLMEK
-- eğer where ile filtreleme yapmazsak product tablosundan bütün kayıtları silmiş oluruz
-- 1 numaralı Id ye sahip elemanı silmiş olalım
-- DELETE FROM shopapp.products where Id = 1
-- bir kaç kriter de ekleyebiliriz fiyatı 2000 den büyük olan ve bilgisayar kategorisinde olan bütün kayıtlar silinir
-- DELETE FROM shopapp.products where price > 2000 and category = 'Bilgisayar'
-- peki açıklaması olmayan bir ürünü silmek istersek description alanı null olan kayıtları silmiş oluruz
-- DELETE FROM shopapp.products where description IS NULL
