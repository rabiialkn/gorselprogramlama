using System;
using System.IO;

class Program
{
    // Tuþ takýmýndaki harfleri tanýmlýyoruz.
    // 0 ve 1 boþ, 2'den itibaren harfler baþlýyor.
    // Kitaptaki matematik (3 üzeri 7) tutsun diye her tuþa 3 harf koyduk.
    static string[] tuslar = {
        "",     // 0
        "",     // 1
        "ABC",  // 2
        "DEF",  // 3
        "GHI",  // 4
        "JKL",  // 5
        "MNO",  // 6
        "PRS",  // 7
        "TUV",  // 8
        "WXY"   // 9
    };

    static StreamWriter yazici; // Dosyaya yazma aracý

    static void Main()
    {
        Console.WriteLine("Lütfen 0 ve 1 içermeyen 7 haneli numara girin (Örn: 2345678):");
        string numara = Console.ReadLine();

        // Basit doðrulama: Uzunluk 7 mi?
        if (numara.Length != 7 || numara.Contains("0") || numara.Contains("1"))
        {
            Console.WriteLine("Hata: Numara 7 haneli olmalý ve 0 veya 1 içermemelidir.");
            return;
        }

        try
        {
            // Dosyayý oluþturuyoruz
            using (yazici = new StreamWriter("nazli_kombinasyonlar.txt"))
            {
                // Kombinasyonlarý baþlatan fonksiyonu çaðýrýyoruz
                Console.WriteLine("Kombinasyonlar hesaplanýyor...");
                KelimeUret(numara, 0, "");
                Console.WriteLine("Ýþlem tamamlandý! 'nazli_kombinasyonlar.txt' dosyasýna bakabilirsin.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }

        Console.ReadLine();
    }

    // --- REKÜRSÝF (KENDÝNÝ ÇAÐIRAN) FONKSÝYON ---
    // Bu fonksiyon her basamak için döngü kurar.
    // index: Þu an kaçýncý rakamdayýz?
    // mevcutKelime: Þu ana kadar oluþturduðumuz kelime.
    static void KelimeUret(string numara, int index, string mevcutKelime)
    {
        // 1. DURMA NOKTASI: Eðer 7 harfe ulaþtýysak, dosyaya yaz ve bitir.
        if (index == 7)
        {
            yazici.WriteLine(mevcutKelime);
            return;
        }

        // 2. ÝÞLEM: Sýradaki rakamý al (Örn: '2')
        // '0' karakterinin ASCII deðerini çýkararak int'e çeviriyoruz.
        int rakam = numara[index] - '0';

        // Bu rakama karþýlýk gelen harfleri al (Örn: "ABC")
        string harfler = tuslar[rakam];

        // 3. DÖNGÜ: Her harf için fonksiyonu tekrar çaðýr
        // Örneðin önce 'A' ekle ve devam et, sonra 'B' ekle ve devam et...
        foreach (char harf in harfler)
        {
            KelimeUret(numara, index + 1, mevcutKelime + harf);
        }
    }
}