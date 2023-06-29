public enum Plec
{
    Kobieta,
    Mezczyzna
}

public struct Student
{
    public string Nazwisko { get; set; }
    public int NrAlbumu { get; set; }
    private double ocena;

    public double Ocena
    {
        get { return ocena; }
        set
        {
            if (value < 2.0)
                ocena = 2.0;
            else if (value > 5.0)
                ocena = 5.0;
            else
                ocena = value;
        }
    }

    public Plec Plec { get; set; }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Nazwisko: {Nazwisko}, Nr albumu: {NrAlbumu}, Ocena: {Ocena}, Płeć: {Plec}");
    }
}

public static class GrupaStudencka
{
    public static double ObliczSrednia(Student[] studenci)
    {
        double sumaOcen = 0.0;

        foreach (var student in studenci)
        {
            sumaOcen += student.Ocena;
        }

        return sumaOcen / studenci.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] grupa = new Student[5]
        {
            new Student { Nazwisko = "Kowalski", NrAlbumu = 1, Ocena = 2.5, Plec = Plec.Mezczyzna },
            new Student { Nazwisko = "Nowak", NrAlbumu = 2, Ocena = 3.5, Plec = Plec.Kobieta },
            new Student { Nazwisko = "Wiśniewski", NrAlbumu = 3, Ocena = 4.0, Plec = Plec.Mezczyzna },
            new Student { Nazwisko = "Dąbrowski", NrAlbumu = 4, Ocena = 5.5, Plec = Plec.Mezczyzna }, // Ocena powinna zostać ograniczona do 5.0
            new Student { Nazwisko = "Lewandowski", NrAlbumu = 5, Ocena = 1.5, Plec = Plec.Mezczyzna }, // Ocena powinna zostać ograniczona do 2.0
        };

        foreach (var student in grupa)
        {
            student.WyswietlInformacje();
        }

        double sredniaGrupy = GrupaStudencka.ObliczSrednia(grupa);
        Console.WriteLine($"Średnia ocen grupy: {sredniaGrupy}");
    }
}
