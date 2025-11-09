using System;
using System.Linq;
using _1_praktiskais.Data;
using _1_praktiskais.Models;

class Program
{
    static void Main(string[] args)
    {
        using var db = new Praktiskais1Context();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1 - Lietotajs");
            Console.WriteLine("2 - BMI");
            Console.WriteLine("3 - Hobiji");
            Console.WriteLine("4 - Skaitliskie dati");
            Console.WriteLine("5 - Login");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("7 - Izvadit visus datus");
            Console.Write("Izvele: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("ID: ");
                    string lid = Console.ReadLine();
                    Console.Write("Vards: ");
                    string vards = Console.ReadLine();
                    Console.Write("Uzvards: ");
                    string uzvards = Console.ReadLine();
                    var lietotajs = new Lietotaj { Id = lid, Vards = vards, Uzvards = uzvards };
                    db.Lietotajs.Add(lietotajs);
                    db.SaveChanges();
                    break;

                case "2":
                    Console.Write("ID: ");
                    string bid = Console.ReadLine();
                    Console.Write("Augums: ");
                    decimal augums = decimal.Parse(Console.ReadLine());
                    Console.Write("Svars: ");
                    decimal svars = decimal.Parse(Console.ReadLine());
                    var bmi = new Bmi { Id = bid, Augums = augums, Svars = svars };
                    db.Bmis.Add(bmi);
                    db.SaveChanges();
                    break;

                case "3":
                    Console.Write("ID: ");
                    string hid = Console.ReadLine();
                    Console.Write("Hobijs: ");
                    string hobijs = Console.ReadLine();
                    Console.Write("Skola: ");
                    string skola = Console.ReadLine();
                    var hobiji = new Hobiji { Id = hid, Hobijs = hobijs, Skola = skola };
                    db.Hobijis.Add(hobiji);
                    db.SaveChanges();
                    break;

                case "4":
                    Console.Write("ID: ");
                    string sid = Console.ReadLine();
                    Console.Write("Telefons: ");
                    decimal telefons = decimal.Parse(Console.ReadLine());
                    Console.Write("Perskods: ");
                    decimal perskods = decimal.Parse(Console.ReadLine());
                    var sk = new Skaitliskidati { Id = sid, Telefons = telefons, Perskods = perskods };
                    db.Skaitliskidatis.Add(sk);
                    db.SaveChanges();
                    break;

                case "5":
                    Console.Write("ID: ");
                    string logid = Console.ReadLine();
                    Console.Write("Epasts: ");
                    string epasts = Console.ReadLine();
                    Console.Write("Parole: ");
                    string parole = Console.ReadLine();
                    var login = new Login { Id = logid, Epasts = epasts, Parole = parole };
                    db.Logins.Add(login);
                    db.SaveChanges();
                    break;

                case "6":
                    running = false;
                    break;

                case "7":
                    Console.WriteLine(" Lietotaji ");
                    foreach (var l in db.Lietotajs) Console.WriteLine($"{l.Id} {l.Vards} {l.Uzvards}");
                    Console.WriteLine(" BMI ");
                    foreach (var b in db.Bmis) Console.WriteLine($"{b.Id} {b.Augums} {b.Svars}");
                    Console.WriteLine(" Hobiji ");
                    foreach (var h in db.Hobijis) Console.WriteLine($"{h.Id} {h.Hobijs} {h.Skola}");
                    Console.WriteLine(" Skaitliskie dati ");
                    foreach (var s in db.Skaitliskidatis) Console.WriteLine($"{s.Id} {s.Telefons} {s.Perskods}");
                    Console.WriteLine(" Login ");
                    foreach (var lo in db.Logins) Console.WriteLine($"{lo.Id} {lo.Epasts} {lo.Parole}");
                    break;

                default:
                    Console.WriteLine("Nepareiza izvele");
                    break;
            }
        }
    }
}
