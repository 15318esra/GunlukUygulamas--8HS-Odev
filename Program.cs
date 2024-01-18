using Günlük_Uygulaması.Controller;
using Günlük_Uygulaması.Models;

namespace Günlük_Uygulaması
{
    internal class Program
    {
        public static bool _isLogin { get; set; } = false;
        static void Main(string[] args)
        {

            Console.WriteLine("Günlük Uygulamasına Hoş Geldin!");

            {
               

                while (true)
                {
                    if(_isLogin)
                    {

                        Console.Clear();
                        Console.WriteLine("1. Yeni Kayıt Ekle");
                        Console.WriteLine("2. Kayıtları Listele");
                        Console.WriteLine("3. Tüm Kayıtları Sil");
                        Console.WriteLine("4. Çıkış Yap");

                        Console.Write("Lütfen bir seçenek girin (1-4): ");
                        string secim = Console.ReadLine();

                        switch (secim)
                        {
                            case "1":
                                YeniKayitEkle();
                                break;
                            case "2":
                                KayitlariListele();
                                break;
                            case "3":
                                TumKayitlariSil();
                                break;
                            case "4":
                                Console.WriteLine("Çıkış yapılıyor...");
                                return;
                            default:
                                Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                                break;
                        }

                        Console.Clear();
                    }
                    else
                    {
                        Giris();
                    }
                }
            }

            static void Giris()
            {
                if (!_isLogin)
                {
                    Console.WriteLine("Lütfen Giriş Yapınız.");
                    Kullanici user = new Kullanici();
                    Console.Write("Kullanıcı Adı: ");
                    user.Username = Console.ReadLine();
                    Console.Write("Şifre: ");
                    user.Password = Console.ReadLine();

                    _isLogin = KullaniciController.Login(user);
                }
                else
                {
                    Console.WriteLine("Yanlış Kullanıcı adı veya şifre girdiniz");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            static void YeniKayitEkle()
            {
                Console.WriteLine("============ Günlük Ekle ============");

                if (!GunlukController.CheckCurrentDateHasDiary())
                    GunlukEkle();
                else
                {
                    Console.WriteLine("Bugün günlük kaydı girdin, aynı tarihte yeni bir kayıt eklemek ister misin? (e)vet/(h)ayır");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "e":
                            GunlukEkle();
                            break;
                        case "h":
                            break;
                    }
                }
            }
            static void GunlukEkle()
            {
                Console.Write("Günlük kaydınızı girin: ");
                string yeniKayit = Console.ReadLine();

                // Tarih ve saati eklemesini buradan yaptım.

                Gunluk gunluk = new Gunluk();
                gunluk.Name = yeniKayit;

                // Veritabanına kaydetme işlemi buradan yapıyorum.
                GunlukController.Add(gunluk);
                Console.WriteLine("Yeni kayıt eklendi!");
                Console.ReadLine();

            }

            static void KayitlariListele()
            {
                List<Gunluk> list = GunlukController.GetAll();
                Console.WriteLine("Kayıtlarınız:\n");
                foreach (Gunluk g in list)
                {


                    Console.WriteLine($"{g.DateCreated.ToString("dd MMMM yyyy")}\n {g.Name}"
                        + "\n-------------");// 
                    Console.WriteLine("(s)onraki kayıt | (d)üzenle | (si)l (a)na menü");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "a":
                            return;
                        case "s":
                            Console.Clear();
                            continue;
                        case "d":
                            DailyUpdate(g);
                            return;
                        case "si":
                            DailyRemoveById(g.Id);
                            return;
                        default:
                            return;
                    }

                } 
                // Kayıtları veritabanından çekme işlemi buradan yapıyorum.

                // Örnek kayıt listesi:
              Thread.Sleep(3000);
            }
            static void DailyRemoveById(int id)
            {
                if (GunlukController.RemoveById(id))
                {
                    Console.WriteLine("Günlük Başarılı ile silindi.");
                }
                else
                {
                    Console.WriteLine("Günlük silinirken bir hata oluştu lütfen yeniden deneyiniz.");
                }
                Thread.Sleep(1000);
            }
            static void DailyUpdate(Gunluk gunluk)
            {
                Console.Write($"\"{gunluk.Name}\" Günlük düzenlemek için yazınız: ");
                gunluk.Name = Console.ReadLine();
                if (GunlukController.Update(gunluk))
                {
                    Console.WriteLine("Günlük Başarılı ile düzenlendi.");
                }
                else
                {
                    Console.WriteLine("Günlük düzenlenirken bir hata oluştu lütfen yeniden deneyiniz.");
                }
                Thread.Sleep(1000);
            }

            static void TumKayitlariSil()
            {
                Console.Write("Tüm kayıtları silmek istediğinizden emin misiniz? (E/H): ");
                string cevap = Console.ReadLine();

                if (cevap.ToUpper() == "E")
                {
                    GunlukController.DeleteAll();
                    // Tüm kayıtları silme işlemi buradan yapıyorum.        

                    Console.WriteLine("Tüm kayıtlar silindi!");
                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi.");
                }

                Console.ReadLine();
            }
        }



    }
}

