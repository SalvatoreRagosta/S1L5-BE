using System;

enum Sesso
{
    Maschio,
    Femmina
}

class Contribuente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }
    public string CodiceFiscale { get; set; }
    public Sesso Sesso { get; set; }
    public string ComuneResidenza { get; set; }
    public double RedditoAnnuale { get; set; }

    public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, Sesso sesso, string comuneResidenza, double redditoAnnuale)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        CodiceFiscale = codiceFiscale;
        Sesso = sesso;
        ComuneResidenza = comuneResidenza;
        RedditoAnnuale = redditoAnnuale;
    }
}

class CalcolatoreImposta
{
    public double CalcolaImposta(double reddito)
    {
        if (reddito <= 15000)
        {
            return reddito * 0.23;
        }
        else if (reddito <= 28000)
        {
            return 3450 + (reddito - 15000) * 0.27;
        }
        else if (reddito <= 55000)
        {
            return 6960 + (reddito - 28000) * 0.38;
        }
        else if (reddito <= 75000)
        {
            return 17220 + (reddito - 55000) * 0.41;
        }
        else
        {
            return 25420 + (reddito - 75000) * 0.43;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Inserisci il nome del contribuente: ");
        string nome = Console.ReadLine();

        Console.Write("Inserisci il cognome del contribuente: ");
        string cognome = Console.ReadLine();

        Console.Write("Inserisci la data di nascita del contribuente (formato dd/MM/yyyy): ");
        DateTime dataNascita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Inserisci il codice fiscale del contribuente: ");
        string codiceFiscale = Console.ReadLine();

        Console.Write("Inserisci il sesso del contribuente (Maschio/Femmina): ");
        Sesso sesso = (Sesso)Enum.Parse(typeof(Sesso), Console.ReadLine(), true);

        Console.Write("Inserisci il comune di residenza del contribuente: ");
        string comuneResidenza = Console.ReadLine();

        Console.Write("Inserisci il reddito annuale del contribuente: ");
        double redditoAnnuale;
        while (!double.TryParse(Console.ReadLine(), out redditoAnnuale) || redditoAnnuale < 0)
        {
            Console.WriteLine("Inserisci un valore numerico positivo per il reddito annuale.");
        }

        Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

        CalcolatoreImposta calcolatoreImposta = new CalcolatoreImposta();
        double imposta = calcolatoreImposta.CalcolaImposta(contribuente.RedditoAnnuale);

        StampareRiepilogo(contribuente, imposta);
    }

    static void StampareRiepilogo(Contribuente contribuente, double imposta)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
        Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
        Console.WriteLine($"nato il {contribuente.DataNascita:dd/MM/yyyy} ({contribuente.Sesso}),");
        Console.WriteLine($"residente in {contribuente.ComuneResidenza},");
        Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato: € {contribuente.RedditoAnnuale:F2}");
        Console.WriteLine($"IMPOSTA DA VERSARE: € {imposta:F2}");
    }
}
