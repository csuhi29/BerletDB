// <copyright file="Menu.cs" company="CsuhajCompany">
// Copyright (c) CsuhajCompany. All rights reserved.
// </copyright>

namespace PassRegister.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PassRegister.Logic;

    public class Menu
    {
        private Logic logic;

        public Menu()
        {
            this.MainMenu();
            this.logic = new Logic();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("| ( 0 )                     Exit                               |");
            Console.WriteLine("| ( 1 )            Bérletek tábla műveletek                    |");
            Console.WriteLine("| ( 2 )             Dolgozó tábla műveletek                    |");
            Console.WriteLine("| ( 3 )               Cég tábla műveletek                      |");
            Console.WriteLine("| ( 4 )            Vásárlás tábla műveletek                    |");
            Console.WriteLine("| ( 5 )         Adott bérletet vevő emberek neve               |");
            Console.WriteLine("| ( 6 )         Legalabb 2en megvették bérletek                |");
            Console.WriteLine("| ( 7 ) Kedvezmény nélküli bérletet vett emberek születési éve |");
            Console.WriteLine("| ( 8 )                    JAVA                                |");
            Console.WriteLine("----------------------------------------------------------------");
            int valasztas = int.Parse(Console.ReadLine());
            switch (valasztas)
            {
                case 0:
                    Console.Clear();
                    this.MainMenu();
                    break;
                case 1:
                    Console.Clear();
                    this.CRUD("Bérletek tábla műveletek");
                    break;
                case 2:
                    Console.Clear();
                    this.CRUD("Dolgozó tábla műveletek");
                    break;
                case 3:
                    Console.Clear();
                    this.CRUD("Cég tábla műveletek");
                    break;
                case 4:
                    Console.Clear();
                    this.CRUD("Vásárlás tábla műveletek");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("nincs kész");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("nincs kész");
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("nincs kész");
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("nincs kész");
                    break;
            }
        }

        public void CRUD(string whichOne)
        {
            Console.WriteLine(whichOne + "\n");
            Console.WriteLine("0) Back");
            Console.WriteLine("1) Listázás");
            Console.WriteLine("2) Hozzáadás");
            Console.WriteLine("3) Módosítás");
            Console.WriteLine("4) Törlés");
            int valasztas = int.Parse(Console.ReadLine());
            switch (valasztas)
            {
                case 0:
                    Console.Clear();
                    this.MainMenu();
                    break;
                case 1:
                    this.logic.ReadBerlet();

                    // Console.WriteLine("nincs kész");
                    break;
                case 2:
                    Console.WriteLine("nincs kész");
                    break;
                case 3:
                    Console.WriteLine("nincs kész");
                    break;
                case 4:
                    Console.WriteLine("nincs kész");
                    break;
            }
        }
    }
}
