# .NET-CORE
Net Core projects are included in this repository.


-Bu projeyi çalıştırmak için ;
 1-Proje https://github.com/yldzamine/Blog üzerinden proje indirilir.
 2-Proje de Blog.API kalsörü içerisinde Script klasörü bulunmaktadır.
   Bu scripti Microsoft SQL Server Management Studio üzerinde çalıştırılıp 
   tablolar bolan Blogs ve Category tabloları gelmelidir.
  3-Blog.API içerisinde appsettings.json dosyasında ki ConnectionStrings kısmı kendi bilgilerinize göre güncellenmelidir.
  (data-source,kullanıcı adı şifre ve db adı kendi ortamınızda ki bilgilerlerle güncellenmelidir.)
  4-Projeden bahsetmek gerekirse;
    -Net6.0 ile yazıldı.
	-Dapper kullanıldı.
	-Katmanlı mimari ile geliştirildi.
	-Endpointleri için swagger arayüzü kullanıldı.
	(incelemelerinizi projeyi Blog.API ile çalıştırdığınızda sizi swagger ekranı karşılayacaktır.)
	-Bir blog datamızın,listelenmesi,eklenmesi,güncellenmesi ve silinmesi işlemi yapıldı.
	
  