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
                        // TODO
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);
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
                    Console.WriteLine("[BERLET_ID, MEGNEVEZES, AR, ERVENYESSEGI_IDO, KEDVEZMENY_TIPUS, BERLET_FORMATUM]");
                    Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
                    berlet.BERLET_ID = int.Parse(Console.ReadLine());
                    berlet.MEGNEVEZES = Console.ReadLine();
                    berlet.AR = int.Parse(Console.ReadLine());
                    berlet.ERVENYESSEG_IDO = int.Parse(Console.ReadLine());
                    berlet.KEDVEZMENY_TIPUS = Console.ReadLine();
                    berlet.BERLET_FORMATUM = Console.ReadLine();
                    l.CreateBerlet(berlet);
                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    foreach (var item in l.ReadBerlet())
                    {
                        Console.WriteLine(item.BERLET_ID + "\t" + item.MEGNEVEZES + "\t" + item.AR + "\t" +
                            item.ERVENYESSEG_IDO + "\t" + item.KEDVEZMENY_TIPUS + "\t" + item.BERLET_FORMATUM);
                    }

                    Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                    int id = int.Parse(Console.ReadLine());
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
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Törlendő ID-je: ");
                    berlet.BERLET_ID = int.Parse(Console.ReadLine());
                    l.DeleteBerlet(berlet);
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
                    Console.WriteLine("[dolgozo_id,ceg_id,nev ,nem ,szuletesi_hely ,szuletesi_ev ,igazolvany_szam ]");
                    Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
                    dolgozo.DOLGOZO_ID = int.Parse(Console.ReadLine());
                    dolgozo.CEG_ID = int.Parse(Console.ReadLine());
                    dolgozo.NEV = Console.ReadLine();
                    dolgozo.NEM = Console.ReadLine();
                    dolgozo.SZULETESI_HELY = Console.ReadLine();
                    dolgozo.SZULETESI_EV = int.Parse(Console.ReadLine());
                    dolgozo.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                    l.CreateDolgozo(dolgozo);
                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    foreach (var item in l.ReadDolgozo())
                    {
                        Console.WriteLine(item.DOLGOZO_ID + "\t" + item.CEG_ID + "\t" + item.NEV + "\t" +
                            item.NEM + "\t" + item.SZULETESI_HELY + "\t" + item.SZULETESI_EV + "\t" + item.IGAZOLVANY_SZAM);
                    }

                    Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                    int id = int.Parse(Console.ReadLine());
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
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Törlendő ID-je: ");
                    dolgozo.DOLGOZO_ID = int.Parse(Console.ReadLine());
                    l.DeleteDolgozo(dolgozo);
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
                    Console.WriteLine("[ceg_id, cegnev, szekhely, adoszam, alapitas_datuma, jegyzett_toke]");
                    Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
                    ceg.CEG_ID = int.Parse(Console.ReadLine());
                    ceg.CEGNEV = Console.ReadLine();
                    ceg.SZEKHELY = Console.ReadLine();
                    ceg.ADOSZAM = int.Parse(Console.ReadLine());
                    ceg.ALAPITAS_DATUMA = DateTime.Parse(Console.ReadLine());
                    ceg.JEGYZETT_TOKE = int.Parse(Console.ReadLine());
                    l.CreateCeg(ceg);
                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    foreach (var item in l.ReadCeg())
                    {
                        Console.WriteLine(item.CEG_ID + "\t" + item.CEGNEV + "\t" + item.SZEKHELY + "\t" +
                        item.ADOSZAM + "\t" + item.ALAPITAS_DATUMA + "\t" + item.JEGYZETT_TOKE);
                    }

                    bool van = false;
                    Console.WriteLine("Adja meg a módosítani kívánt tétel 'ID'-jét:");
                    int id = int.Parse(Console.ReadLine());
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
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Törlendő ID-je: ");
                    ceg.CEG_ID = int.Parse(Console.ReadLine());
                    l.DeleteCeg(ceg);
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
                    Console.WriteLine("vasarlas_id, dolgozo_id, berlet_id, berlet_megnevezes, igazolvany_szam, ervenyesseg_kezdete");
                    Console.WriteLine("Ebben a sorrendben kérem írja be az adatokat, minden adat után 'enter' leütése szükséges.");
                    vasarlas.VASARLAS_ID = int.Parse(Console.ReadLine());
                    vasarlas.DOLGOZO_ID = int.Parse(Console.ReadLine());
                    vasarlas.BERLET_ID = int.Parse(Console.ReadLine());
                    vasarlas.BERLET_MEGNEVEZES = Console.ReadLine();
                    vasarlas.IGAZOLVANY_SZAM = int.Parse(Console.ReadLine());
                    vasarlas.ERVENYESSEG_KEZDETE = DateTime.Parse(Console.ReadLine());
                    l.CreateVasarlas(vasarlas);
                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "3":
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
                        else
                        {
                            Console.WriteLine("Nincs ilyen ID.");
                        }
                    }

                    if (van)
                    {
                        Console.Write("Vásárlás ID: ");
                        vasarlas.VASARLAS_ID = id;
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
                    }

                    Console.WriteLine("Hit an 'ENTER' to go back to main menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Törlendő ID-je: ");
                    vasarlas.VASARLAS_ID = int.Parse(Console.ReadLine());
                    l.DeleteVasarlas(vasarlas);
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
