using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dosya = "veri.txt";

        // --- 1. YAZMA ÝÞLEMÝ ---
        using (StreamWriter yazici = new StreamWriter(dosya))
        {
            // Ýstenilen deðiþiklik burada yapýldý
            string ad = "Nazlý Karnal";
            bool korumaVarMi = true; // Sorudaki bool alaný

            // Dosyaya þu þekilde yazar: Nazlý Karnal,True
            yazici.WriteLine(ad + "," + korumaVarMi);
            Console.WriteLine("Veri dosyaya yazýldý.");
        }

        // --- 2. OKUMA ÝÞLEMÝ ---
        using (StreamReader okuyucu = new StreamReader(dosya))
        {
            string satir = okuyucu.ReadLine();
            // Satýrý virgülden parçala: ["Nazlý Karnal", "True"]
            string[] parcalar = satir.Split(',');

            string gelenAd = parcalar[0];
            bool gelenKoruma = bool.Parse(parcalar[1]);

            Console.WriteLine("\n--- DOSYADAN OKUNAN ---");
            Console.WriteLine("Ýsim: " + gelenAd);
            Console.WriteLine("Koruma Var mý: " + gelenKoruma);
        }

        Console.ReadLine();
    }
}