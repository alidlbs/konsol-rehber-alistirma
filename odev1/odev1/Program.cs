using System.IO;

using System;

namespace DosyaIslemleri
{
    class Program
    {
        static string[] isimler;
        static string[] soyisimler;
        static string[] tel;
        private static string ad,soyad,telefon;

        static void Main(string[] args)
        {
            
            int secim;
            
            do
            {

                Console.Clear();

                //Menü Yazdırma
                menu();
                
                
                    secim = Convert.ToInt32(Console.ReadLine());
                switch(secim)
                {
                    case 1://ekleme
                        
                        ekleme();
                        
                        break;
                    case 2:
                        //Ara
                        ara();
                        break;
                    case 3:
                        //Oku
                        oku();
                        break;
                    case 4://sil
                        sil();
                        break;
                    case 5://degistir
                        degistir1();
                        break;
                    case 6:
                        Console.WriteLine("Çıkış için enter tuşuna basınız");
                        Console.ReadLine();
                    break;

                    
                        
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız.");
                        Console.ReadLine();
                    break;
                }
                
               
            } while (secim != 6);
            
        }

        static bool dosyayaYaz(string yazilacakSatir)
        {
            try
            {
                StreamWriter dosyaYazici = new StreamWriter(".\\bilgiler.txt", true);
                dosyaYazici.WriteLine(yazilacakSatir);
                dosyaYazici.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static int dosyayiDizilereAktar()
        {
            isimler = new string[100];
            soyisimler = new string[100];
            tel = new string[100];

            string dosyadakiSatir;
            int sayac = 0;
            StreamReader dosyaOkuyucu = new StreamReader(".\\bilgiler.txt");
            while (dosyaOkuyucu.EndOfStream == false)
            {
                dosyadakiSatir = dosyaOkuyucu.ReadLine();
                string[] parca = dosyadakiSatir.Split('#');
                isimler[sayac] = parca[0];
                soyisimler[sayac] = parca[1];
                tel[sayac] = parca[2];
                sayac++;
            }
            dosyaOkuyucu.Close();
            return sayac;
        }
        static void menu()
        {
 Console.WriteLine("1-Ekle"); 
                Console.WriteLine("2-Ara");
                Console.WriteLine("3-göster");
                Console.WriteLine("4-Sil");
                Console.WriteLine("5-degistir");
                Console.WriteLine( "6-cıkıs");
                Console.Write("Seçiminiz: ");
        }
       static void  ekleme()
        {
            //Ekleme
            string ad, soyad, telefon;
            Console.Write("Ad: ");
            ad = Console.ReadLine();
            Console.Write("Soyad: ");
            soyad = Console.ReadLine();
            Console.Write("telefon: ");
            telefon = Console.ReadLine();
            if (dosyayaYaz(ad + "#" + soyad + "#" + telefon) == true)
            {
                Console.WriteLine("Dosyaya ekleme başarılı.");
                Console.Write("Devam etmek için enter tuşuna basınız");
            }
            else
            {
                Console.WriteLine("Dosyaya ekleme başarısız.");
                Console.Write("Devam etmek için enter tuşuna basınız");
            }
            Console.ReadLine();
            return;
        }
        static void ara()
        {
            int satirSayisi = dosyayiDizilereAktar();
            bool kontrol = false;
            Console.Write("Arama yapmak istediğiniz isim: ");
            string aranacakIsim = Console.ReadLine();
            for (int i = 0; i < satirSayisi; i++)
            {
                if (isimler[i] == aranacakIsim)
                {
                    Console.WriteLine("Aranılan kayıt bulundu:");
                    Console.WriteLine("Ad: {0} Soyad: {1} telefon: {2}", isimler[i], soyisimler[i], tel[i]);
                    kontrol = true;
                }
            }
            if (kontrol == false)
            {
                Console.WriteLine("Aranılan kayıt bulunamadı");
            }
            Console.WriteLine("Devam etmek için enter tuşuna basınız.");
            Console.ReadLine();
        }
        static void oku()
            
        {
            int sayac = dosyayiDizilereAktar();
            //Ekrana yazdırma
            for (int i = 0; i < sayac; i++)
            {
                Console.WriteLine("Ad: {0} Soyad: {1} telefon: {2}", isimler[i], soyisimler[i], tel[i]);
            }
            Console.Write("Dosyanın sonuna gelindi menü için enter tuşuna basınız");
            Console.ReadLine();
        }
        static void sil()
        {
            int satirS = dosyayiDizilereAktar();
            bool knt = false;
            Console.Write("Silmek istediğiniz isim: ");
            string silinecekIsim = Console.ReadLine();
            for (int i = 0; i < satirS; i++)
            {

                if (isimler[i] == silinecekIsim)
                {
                    knt = true;
                }
                else
                {
                    StreamWriter yazici = new StreamWriter(".\\bilgiler.txt", false);
                    yazici.WriteLine(isimler[i] + "#" + soyisimler[i] + "#" + tel[i]);
                    yazici.Close();
                }
            }
            if (knt == false)
            {
                Console.WriteLine("Aranılan kayıt bulunamadı");
            }
            else
            {
                Console.WriteLine("Aranılan kayıt silindi");
            }
            Console.WriteLine("Devam etmek için enter tuşuna basınız.");
            Console.ReadLine();
        }
        static void degistir1()
        {
            if (degistir() == true)
            {
                degistir0();
            }
            else
            {
                Console.WriteLine("Aranılan kayıt bulunamadı ");
                Console.WriteLine("Devam etmek için enter tuşuna basınız");
                Console.ReadLine();
            }
        }
        static bool degistir()
        {
           
            int satir = dosyayiDizilereAktar();
            bool kntt = false;
            Console.Write("degiştirmek  istediğiniz isim: ");
            string silinecekIsimi = Console.ReadLine();
            for (int i = 0; i < satir; i++)
            {

                if (isimler[i] == silinecekIsimi)
                {
                    kntt = true;
                }
                else
                {
                    StreamWriter yazici = new StreamWriter(".\\bilgiler.txt", false);
                    yazici.WriteLine(isimler[i] + "#" + soyisimler[i] + "#" + tel[i]);
                    yazici.Close();
                }
            }
            if (kntt == false)
            {
               
                return false;

            }  
            else
            {
                Console.WriteLine("............loading,,,,,,,");return true;
            }
            
           
           
            }
      static void degistir0()
            {
 Console.Write("Ad: ");
            ad = Console.ReadLine();
            Console.Write("Soyad: ");
            soyad = Console.ReadLine();
            Console.Write("telefon: ");
            telefon = Console.ReadLine();
            if (dosyayaYaz(ad + "#" + soyad + "#" + telefon) == true)
            {
                Console.WriteLine("Dosyaya güncelleme başarılı.");
                Console.Write("Devam etmek için enter tuşuna basınız");
            }
            else
            {
                Console.WriteLine("Dosyaya güncelleme başarısız.");
                Console.Write("Devam etmek için enter tuşuna basınız");
            }
            Console.ReadLine();
            }  
    }
}
