// <copyright file="Program.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Data;
    using PassRegister.Logic;

    /// <summary>
    /// The Main Program that will use all Projects.
    /// </summary>
    public class Program
    {
        private static Logic l = new Logic();

        /// <summary>
        /// Main Method.
        /// </summary>
        /// <param name="args">Basic arguments.</param>
        public static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                DisplayMenu();
                cki = Console.ReadKey(true);
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        BerletCRUDs();
                        break;
                    case "2":
                        DolgozoCRUDs();
                        break;
                    case "3":
                        CegCRUDs();
                        break;
                    case "4":
                        VasarlasCRUDs();
                        break;
                    case "5":
                        GivenNamedPass();
                        break;
                    case "6":
                        AtLeast2Bought();
                        break;
                    case "7":
                        NoSalePasses();

                        break;
                    case "8":
                        JavaEndPoint();
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Calls the Logic's WebRequest method to get data form the JAVA endpoint.
        /// </summary>
        public static void JavaEndPoint()
        {
            l.WebRequest();
        }

        /// <summary>
        /// Uses a Logic method that will return a List containing the DOLGOZO names who bought a pass of the given name.
        /// </summary>
        public static void GivenNamedPass()
        {
            Console.Clear();
            Console.Write("Adja meg a keresni kívánt bérlet nevét: ");
            string nev = Console.ReadLine();
            l.GivenName(nev);
            Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Uses a Logic method what will return a List containing the names of the passes that has been bought at least twice.
        /// </summary>
        public static void AtLeast2Bought()
        {
            Console.Clear();
            l.AtLeast2();
            Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Uses a Logic method what will return a List containing the names of the people who bought a pass without Sale.
        /// </summary>
        public static void NoSalePasses()
        {
            Console.Clear();
            l.NoSale();
            Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Represents a list of the CRUD methods of the Passes.
        /// </summary>
        public static void BerletCRUDs()
        {
            Console.Clear();
            Console.WriteLine("0) Back");
            Console.WriteLine("1) Listázás");
            Console.WriteLine("2) Hozzáadás");
            Console.WriteLine("3) Módosítás");
            Console.WriteLine("4) Törlés");
            BERLET berlet = new BERLET();
            ConsoleKeyInfo cki;

            cki = Console.ReadKey(true);
            switch (cki.KeyChar.ToString())
            {
                case "1":
                    foreach (var item in l.ReadBerlet())
                    {
                        Console.WriteLine(item.BERLET_ID + "\t" + item.MEGNEVEZES + "\t" + item.AR + "\t" +
                            item.ERVENYESSEG_IDO + "\t" + item.KEDVEZMENY_TIPUS + "\t" + item.BERLET_FORMATUM);
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "2":
                    bool jo = true;
                    while (jo)
                    {
                        try
                        {
                            Console.Write("Bérlet ID: ");
                            berlet.BERLET_ID = int.Parse(Console.ReadLine());
                            Console.Write("Megnevezés: ");
                            berlet.MEGNEVEZES = Console.ReadLine();
                            Console.Write("Ár: ");
                            berlet.AR = int.Parse(Console.ReadLine());
                            Console.Write("Érvényességi idő: ");
                            berlet.ERVENYESSEG_IDO = int.Parse(Console.ReadLine());
                            Console.Write("Kedvezmény típus: ");
                            berlet.KEDVEZMENY_TIPUS = Console.ReadLine();
                            Console.Write("Bérlet formátum: ");
                            berlet.BERLET_FORMATUM = Console.ReadLine();
                            l.CreateBerlet(berlet);
                            jo = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                jo = true;
                            }
                            else
                            {
                                jo = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    foreach (var item in l.ReadBerlet())
                    {
                        Console.WriteLine(item.BERLET_ID + "\t" + item.MEGNEVEZES + "\t" + item.AR + "\t" +
                            item.ERVENYESSEG_IDO + "\t" + item.KEDVEZMENY_TIPUS + "\t" + item.BERLET_FORMATUM);
                    }

                    bool ok = true;
                    while (ok)
                    {
                        try
                        {
                            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                            int id = int.Parse(Console.ReadLine());
                            ok = false;
                            bool van = false;

                            foreach (var item in l.ReadBerlet())
                            {
                                if (item.BERLET_ID == id)
                                {
                                    Console.WriteLine(item.BERLET_ID + "\t" + item.MEGNEVEZES + "\t" + item.AR + "\t" +
                                    item.ERVENYESSEG_IDO + "\t" + item.KEDVEZMENY_TIPUS + "\t" + item.BERLET_FORMATUM);
                                    van = true;
                                }
                            }

                            if (van)
                            {
                                Console.Write("Bérlet ID: ");
                                berlet.BERLET_ID = int.Parse(Console.ReadLine());
                                Console.Write("Bérlet megnevezése: ");
                                berlet.MEGNEVEZES = Console.ReadLine();
                                Console.Write("Bérlet ára: ");
                                berlet.AR = int.Parse(Console.ReadLine());
                                Console.Write("Érvényességi ideje: ");
                                berlet.ERVENYESSEG_IDO = int.Parse(Console.ReadLine());
                                Console.Write("Kedvezmény típusa: ");
                                berlet.KEDVEZMENY_TIPUS = Console.ReadLine();
                                Console.Write("Bérlet formátuma: ");
                                berlet.BERLET_FORMATUM = Console.ReadLine();
                                l.UpdateBerlet(berlet);
                                ok = false;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ok = true;
                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    bool ex = true;
                    while (ex)
                    {
                        try
                        {
                            Console.WriteLine("Törlendő ID-je: ");
                            berlet.BERLET_ID = int.Parse(Console.ReadLine());
                            l.DeleteBerlet(berlet);

                            ex = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ex = true;
                            }
                            else
                            {
                                ex = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "0":
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Represents a list of the CRUD methods of the Workers.
        /// </summary>
        public static void DolgozoCRUDs()
        {
            Console.Clear();
            Console.WriteLine("0) Back");
            Console.WriteLine("1) Listázás");
            Console.WriteLine("2) Hozzáadás");
            Console.WriteLine("3) Módosítás");
            Console.WriteLine("4) Törlés");

            ConsoleKeyInfo cki;
            DOLGOZO dolgozo = new DOLGOZO();

            cki = Console.ReadKey(true);
            switch (cki.KeyChar.ToString())
            {
                case "1":
                    foreach (var item in l.ReadDolgozo())
                    {
                        Console.WriteLine(item.DOLGOZO_ID + "\t" + item.CEG_ID + "\t" + item.NEV + "\t" +
                            item.NEM + "\t" + item.SZULETESI_HELY + "\t" + item.SZULETESI_EV + "\t" + item.IGAZOLVANY_SZAM);
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "2":
                    bool jo = true;
                    while (jo)
                    {
                        try
                        {
                            Console.Write("Dolgozó ID: ");
                            dolgozo.DOLGOZO_ID = int.Parse(Console.ReadLine());
                            Console.Write("Cég ID: ");
                            dolgozo.CEG_ID = int.Parse(Console.ReadLine());
                            Console.Write("Dolgozó neve: ");
                            dolgozo.NEV = Console.ReadLine();
                            Console.Write("Dolgozó neme: [f/l] ");
                            dolgozo.NEM = Console.ReadLine();
                            Console.Write("Születési hely: ");
                            dolgozo.SZULETESI_HELY = Console.ReadLine();
                            Console.Write("Születési év [yyyy]: ");
                            dolgozo.SZULETESI_EV = int.Parse(Console.ReadLine());
                            Console.Write("Igazolvány szám: ");
                            dolgozo.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                            l.CreateDolgozo(dolgozo);
                            jo = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                jo = true;
                            }
                            else
                            {
                                jo = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    foreach (var item in l.ReadDolgozo())
                    {
                        Console.WriteLine(item.DOLGOZO_ID + "\t" + item.CEG_ID + "\t" + item.NEV + "\t" +
                            item.NEM + "\t" + item.SZULETESI_HELY + "\t" + item.SZULETESI_EV + "\t" + item.IGAZOLVANY_SZAM);
                    }

                    bool ok = true;
                    while (ok)
                    {
                        try
                        {
                            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                            int id = int.Parse(Console.ReadLine());
                            ok = false;
                            bool van = false;
                            foreach (var item in l.ReadDolgozo())
                            {
                                if (item.DOLGOZO_ID == id)
                                {
                                    Console.WriteLine(item.DOLGOZO_ID + "\t" + item.CEG_ID + "\t" + item.NEV + "\t" +
                                    item.NEM + "\t" + item.SZULETESI_HELY + "\t" + item.SZULETESI_EV + "\t" + item.IGAZOLVANY_SZAM);
                                    van = true;
                                }
                            }

                            if (van)
                            {
                                Console.Write("Dolgozo ID: ");
                                dolgozo.DOLGOZO_ID = int.Parse(Console.ReadLine());
                                Console.Write("Ceg ID: ");
                                dolgozo.CEG_ID = int.Parse(Console.ReadLine());
                                Console.Write("Dolgozó neve: ");
                                dolgozo.NEV = Console.ReadLine();
                                Console.Write("Dolgozó neme: ");
                                dolgozo.NEM = Console.ReadLine();
                                Console.Write("Születési helye: ");
                                dolgozo.SZULETESI_HELY = Console.ReadLine();
                                Console.Write("Születési éve: ");
                                dolgozo.SZULETESI_EV = int.Parse(Console.ReadLine());
                                Console.Write("Igazolvány száma: ");
                                dolgozo.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                                l.UpdateDolgozo(dolgozo);
                                ok = false;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ok = true;
                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    bool ex = true;
                    while (ex)
                    {
                        try
                        {
                            Console.WriteLine("Törlendő ID-je: ");
                            dolgozo.DOLGOZO_ID = int.Parse(Console.ReadLine());
                            l.DeleteDolgozo(dolgozo);

                            ex = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ex = true;
                            }
                            else
                            {
                                ex = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    return;
                case "0":
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Represents a list of the CRUD methods of the Companies.
        /// </summary>
        public static void CegCRUDs()
        {
            Console.Clear();
            Console.WriteLine("0) Back");
            Console.WriteLine("1) Listázás");
            Console.WriteLine("2) Hozzáadás");
            Console.WriteLine("3) Módosítás");
            Console.WriteLine("4) Törlés");

            ConsoleKeyInfo cki;
            CEG ceg = new CEG();

            cki = Console.ReadKey(true);
            switch (cki.KeyChar.ToString())
            {
                case "1":
                    foreach (var item in l.ReadCeg())
                    {
                        Console.WriteLine(item.CEG_ID + "\t" + item.CEGNEV + "\t" + item.SZEKHELY + "\t" +
                            item.ADOSZAM + "\t" + item.ALAPITAS_DATUMA + "\t" + item.JEGYZETT_TOKE);
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "2":
                    bool jo = true;
                    while (jo)
                    {
                        try
                        {
                            Console.Write("Cég_ID: ");
                            ceg.CEG_ID = int.Parse(Console.ReadLine());
                            Console.Write("Cégnév: ");
                            ceg.CEGNEV = Console.ReadLine();
                            Console.Write("Székhely: ");
                            ceg.SZEKHELY = Console.ReadLine();
                            Console.Write("Adószám: ");
                            ceg.ADOSZAM = int.Parse(Console.ReadLine());
                            Console.Write("Alapítás dátuma [yyyy.mm.dd.]");
                            ceg.ALAPITAS_DATUMA = DateTime.Parse(Console.ReadLine());
                            Console.Write("Jegyzett tőke: ");
                            ceg.JEGYZETT_TOKE = int.Parse(Console.ReadLine());
                            l.CreateCeg(ceg);
                            jo = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                jo = true;
                            }
                            else
                            {
                                jo = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    bool ok = true;
                    while (ok)
                    {
                        try
                        {
                            foreach (var item in l.ReadCeg())
                            {
                                Console.WriteLine(item.CEG_ID + "\t" + item.CEGNEV + "\t" + item.SZEKHELY + "\t" +
                                item.ADOSZAM + "\t" + item.ALAPITAS_DATUMA + "\t" + item.JEGYZETT_TOKE);
                            }

                            bool van = false;
                            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                            int id = int.Parse(Console.ReadLine());
                            ok = false;
                            foreach (var item in l.ReadCeg())
                            {
                                if (item.CEG_ID == id)
                                {
                                    Console.WriteLine(item.CEG_ID + "\t" + item.CEGNEV + "\t" + item.SZEKHELY + "\t" +
                                    item.ADOSZAM + "\t" + item.ALAPITAS_DATUMA + "\t" + item.JEGYZETT_TOKE);
                                    van = true;
                                }
                            }

                            if (van)
                            {
                                Console.Write("Cég ID: ");
                                ceg.CEG_ID = int.Parse(Console.ReadLine());
                                Console.Write("Cégnév: ");
                                ceg.CEGNEV = Console.ReadLine();
                                Console.Write("Székhely: ");
                                ceg.SZEKHELY = Console.ReadLine();
                                Console.Write("Adószám: ");
                                ceg.ADOSZAM = int.Parse(Console.ReadLine());
                                Console.Write("Alapítás Dátuma: ");
                                ceg.ALAPITAS_DATUMA = DateTime.Parse(Console.ReadLine());
                                Console.Write("Jegyzett tőke: ");
                                ceg.JEGYZETT_TOKE = int.Parse(Console.ReadLine());
                                l.UpdateCeg(ceg);
                                ok = false;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ok = true;
                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    bool ex = true;
                    while (ex)
                    {
                        try
                        {
                            Console.WriteLine("Törlendő ID-je: ");
                            ceg.CEG_ID = int.Parse(Console.ReadLine());
                            l.DeleteCeg(ceg);

                            ex = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ex = true;
                            }
                            else
                            {
                                ex = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "0":
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Represents a list of the CRUD methods of the Sale.
        /// </summary>
        public static void VasarlasCRUDs()
        {
            Console.Clear();
            Console.WriteLine("0) Back");
            Console.WriteLine("1) Listázás");
            Console.WriteLine("2) Hozzáadás");
            Console.WriteLine("3) Módosítás");
            Console.WriteLine("4) Törlés");

            ConsoleKeyInfo cki;
            VASARLAS vasarlas = new VASARLAS();

            cki = Console.ReadKey(true);
            switch (cki.KeyChar.ToString())
            {
                case "1":
                    foreach (var item in l.ReadVasarlas())
                    {
                        Console.WriteLine(item.VASARLAS_ID + "\t" + item.DOLGOZO_ID + "\t" + item.BERLET_ID + "\t" +
                            item.BERLET_MEGNEVEZES + "\t" + item.IGAZOLVANY_SZAM + "\t" + item.ERVENYESSEG_KEZDETE);
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "2":
                    bool jo = true;
                    while (jo)
                    {
                        try
                        {
                            Console.Write("Vásárlás ID: ");
                            vasarlas.VASARLAS_ID = int.Parse(Console.ReadLine());
                            Console.Write("Dolgozo ID: ");
                            vasarlas.DOLGOZO_ID = int.Parse(Console.ReadLine());
                            Console.Write("Bérlet ID: ");
                            vasarlas.BERLET_ID = int.Parse(Console.ReadLine());
                            Console.Write("Megnevezése: ");
                            vasarlas.BERLET_MEGNEVEZES = Console.ReadLine();
                            Console.Write("Igazolván száma: ");
                            vasarlas.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                            Console.Write("Érvényesség kezdete: ");
                            vasarlas.ERVENYESSEG_KEZDETE = DateTime.Parse(Console.ReadLine());
                            l.CreateVasarlas(vasarlas);
                            jo = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                jo = true;
                            }
                            else
                            {
                                jo = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    bool ok = true;
                    while (ok)
                    {
                        try
                        {
                            foreach (var item in l.ReadVasarlas())
                            {
                                Console.WriteLine(item.VASARLAS_ID + "\t" + item.DOLGOZO_ID + "\t" + item.BERLET_ID + "\t" +
                                    item.BERLET_MEGNEVEZES + "\t" + item.IGAZOLVANY_SZAM + "\t" + item.ERVENYESSEG_KEZDETE);
                            }

                            bool van = false;
                            Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                            int id = int.Parse(Console.ReadLine());
                            foreach (var item in l.ReadVasarlas())
                            {
                                if (item.VASARLAS_ID == id)
                                {
                                    Console.WriteLine(item.VASARLAS_ID + "\t" + item.DOLGOZO_ID + "\t" + item.BERLET_ID + "\t" +
                                    item.BERLET_MEGNEVEZES + "\t" + item.IGAZOLVANY_SZAM + "\t" + item.ERVENYESSEG_KEZDETE);
                                    van = true;
                                }
                            }

                            if (van)
                            {
                                Console.Write("Vásárlás ID: ");
                                vasarlas.VASARLAS_ID = int.Parse(Console.ReadLine());
                                Console.Write("Dolgozó ID: ");
                                vasarlas.DOLGOZO_ID = int.Parse(Console.ReadLine());
                                Console.Write("Bérlet ID: ");
                                vasarlas.BERLET_ID = int.Parse(Console.ReadLine());
                                Console.Write("Bérlet megnevezése: ");
                                vasarlas.BERLET_MEGNEVEZES = Console.ReadLine();
                                Console.WriteLine("Igazolvány szám: ");
                                vasarlas.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                                Console.WriteLine("Érvényesség kezdete: ");
                                vasarlas.ERVENYESSEG_KEZDETE = DateTime.Parse(Console.ReadLine());
                                l.UpdateVasarlas(vasarlas);
                                ok = false;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ok = true;
                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    bool ex = true;
                    while (ex)
                    {
                        try
                        {
                            Console.WriteLine("Törlendő ID-je: ");
                            vasarlas.VASARLAS_ID = int.Parse(Console.ReadLine());
                            l.DeleteVasarlas(vasarlas);

                            ex = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adta meg az adatokat. ÚjraPróbálkozik? [y / n]:");
                            if (Console.ReadLine() == "y")
                            {
                                ex = true;
                            }
                            else
                            {
                                ex = false;
                            }
                        }
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "0":
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Displays the Menu.
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("|( Esc )                   Exit                                |");
            Console.WriteLine("| ( 1 )            Bérletek tábla műveletek                    |");
            Console.WriteLine("| ( 2 )             Dolgozó tábla műveletek                    |");
            Console.WriteLine("| ( 3 )               Cég tábla műveletek                      |");
            Console.WriteLine("| ( 4 )            Vásárlás tábla műveletek                    |");
            Console.WriteLine("| ( 5 )         Adott bérletet vevő emberek neve               |");
            Console.WriteLine("| ( 6 )         Legalabb 2en megvették bérletek                |");
            Console.WriteLine("| ( 7 ) Kedvezmény nélküli bérletet vett emberek születési éve |");
            Console.WriteLine("| ( 8 )                    JAVA                                |");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
