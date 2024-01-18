﻿using Günlük_Uygulaması.Controller;
using Günlük_Uygulaması.Models;

namespace Günlük_Uygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Günlük Uygulamasına Hoş Geldin!");

            {
               

                while (true)
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
            }

            static void YeniKayitEkle()
            {
                if (!GunlukController.CheckCurrentDateHasDiary())
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
                else
                {
                    Console.WriteLine("Daha günlük eklemesi yapıldı");
                    Thread.Sleep(1000);
                }
            }

            static void KayitlariListele()
            {
                List<Gunluk> list = GunlukController.GetAll();
                Console.WriteLine("Kayıtlarınız:\n");
                foreach (Gunluk g in list)
                {


                    Console.WriteLine($"{g.DateCreated.ToString("dd MMMM yyyy")}\n {g.Name}"
                        + "\n-------------");// 
                    Console.WriteLine("(s)onraki kayıt | (a)na menü");
                    string option = Console.ReadLine();
                    if (option == "a")
                        break;
                    else if (option == "s")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                        break;

                } 
                // Kayıtları veritabanından çekme işlemi buradan yapıyorum.

                // Örnek kayıt listesi:
              Thread.Sleep(3000);
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

