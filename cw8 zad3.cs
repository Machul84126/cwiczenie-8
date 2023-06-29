public enum KlasaRzadkosci
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

public enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

public struct Przedmiot
{
    public double Waga { get; set; }
    public int Wartosc { get; set; }
    public KlasaRzadkosci Rzadkosc { get; set; }
    public TypPrzedmiotu Typ { get; set; }
    public string Nazwa { get; set; }

    public Przedmiot(double waga, int wartosc, KlasaRzadkosci rzadkosc, TypPrzedmiotu typ, string nazwa) : this()
    {
        Waga = waga;
        Wartosc = wartosc;
        Rzadkosc = rzadkosc;
        Typ = typ;
        Nazwa = nazwa;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Nazwa: {Nazwa}");
        Console.WriteLine($"Typ: {Typ}");
        Console.WriteLine($"Klasa rzadkości: {Rzadkosc}");
        Console.WriteLine($"Waga: {Waga}");
        Console.WriteLine($"Wartość: {Wartosc} sztuk złota");
    }
}

public class Gra
{
    public static Przedmiot LosujPrzedmiot(Przedmiot[] przedmioty)
    {
        Random random = new Random();
        int szansa = random.Next(100);
        KlasaRzadkosci wylosowanaRzadkosc;

        if (szansa < 50) // 50% szans na przedmiot powszechny
        {
            wylosowanaRzadkosc = KlasaRzadkosci.Powszechny;
        }
        else if (szansa < 75) // 25% szans na rzadki przedmiot
        {
            wylosowanaRzadkosc = KlasaRzadkosci.Rzadki;
        }
        else if (szansa < 90) // 15% szans na unikalny przedmiot
        {
            wylosowanaRzadkosc = KlasaRzadkosci.Unikalny;
        }
        else // 10% szans na epicki przedmiot
        {
            wylosowanaRzadkosc = KlasaRzadkosci.Epicki;
        }

        // Tworzymy nową tablicę tylko z przedmiotami o wylosowanej rzadkości
        Przedmiot[] wyfiltrowanePrzedmioty = przedmioty.Where(przedmiot => przedmiot.Rzadkosc == wylosowanaRzadkosc).ToArray();

        // Losujemy jeden przedmiot z wyfiltrowanej tablicy
        return wyfiltrowanePrzedmioty[random.Next(wyfiltrowanePrzedmioty.Length)];
    }
}

class Program
{
    static void Main()
    {
        Przedmiot[] przedmioty = new Przedmiot[]
        {
            new Przedmiot(1.0, 100, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Bron, "Miecz żołnierza"),
            new Przedmiot(0.5, 200, KlasaRzadkosci.Rzadki, TypPrzedmiotu.Amulet, "Amulet zęba smoka"),
            new Przedmiot(1.5, 500, KlasaRzadkosci.Epicki, TypPrzedmiotu.Tarcza, "Tarcza Niezwyciężonych"),
            // dodaj więcej przedmiotów...
        };

        Przedmiot wylosowanyPrzedmiot = Gra.LosujPrzedmiot(przedmioty);
        wylosowanyPrzedmiot.WyswietlInformacje();
    }
}
